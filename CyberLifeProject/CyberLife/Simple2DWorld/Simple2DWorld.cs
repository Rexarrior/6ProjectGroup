using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberLife.Platform.Logging.LogMessages;
using CyberLife.Platform.World_content;
using System.Threading;
using NLog;

namespace CyberLife.Simple2DWorld
{
    public class Simple2DWorld : World
    {

        public const double OrganicZeroEnergyFactor = 0.1;
        public const double OrganicCollapseEnergyFactor = 0.3;
        public const double OutflowEnergyFactor = 0.01;

        #region fields

        private Dictionary<Point, LifeForm> _organic;
        private Dictionary<string, LifeFormState> _states;

        #endregion


        #region properties

        public Dictionary<Point, LifeForm> Organic { get => _organic; set => _organic = value; }
        public Dictionary<string, LifeFormState> States { get => _states; }

        #endregion


        #region methods

        public override void Update()
        {
            foreach (IPhenomen phenomen in _naturalPhenomena.Values)
                phenomen.Update(this);
            foreach (var state in _states.Values)
            {
                state.Update(this);
            }
            _energyReaction();
            _genotypeReaction();
            _colorReaction();
            _visualizer.Update(this);
            _age++;
        }

        /// <summary>
        /// Получает список форм жизни "Бот" для первичной инициализации 
        /// Simple2DWorld
        /// </summary>
        /// <param name="count">Число форм жизни</param>
        /// <param name="width">Ширина карты</param>
        /// <param name="height">Высота карты</param>
        /// <returns></returns>
        private static Dictionary<Point,LifeForm> _getLifeForms(int count, int width, int height)
        {
            MapSize mapsize = new MapSize(width, height);
            Dictionary<Point, LifeForm> lifeForms =new Dictionary<Point, LifeForm>(count);
            for (int i = 0; i < count; i++)
            {
                BotLifeForm bot = new BotLifeForm(mapsize, lifeForms);
                lifeForms.Add(bot.LifeFormPoint,bot);
            }

            return lifeForms;
        }



        /// <summary>
        /// Инициализирует базовые реакции Simple2DWorld
        /// </summary>
        private void _InitReactions()
        {
            if (_reactions == null)
                _reactions = new Dictionary<string, ReactionDelegate>();
            if (_reactions.Count > 0)
                return;

            _reactions.Add("EnergyReaction", _energyReaction);
            _reactions.Add("GenotypeReaction", _genotypeReaction);
            _reactions.Add("ColorReaction", _colorReaction);
        }



        /// <summary>
        /// Реакция, отвечающая за изменение состояния 
        /// EnergyState у форм жизни
        /// </summary>
        /// <param name="world">Обрабатываемый мир</param>
        private void _energyReaction()
        {

            IEnumerable<Point> deadBots = LifeForms
                .Where(
                    x => ((BotLifeForm)x.Value).Dead == true
                ).Select(x => (Point)x.Key).ToArray();
            foreach (var botPoint in deadBots)
            {
                BotLifeForm bot = (BotLifeForm)LifeForms[botPoint];
                Organic.Add(botPoint, bot);
                LifeForms.Remove(botPoint);
                bot.Energy = (int)(EnergyState.MaxEnergy * (
                    bot.EnergyState == EnergyStates.EnergyCollapse ?
                        OrganicCollapseEnergyFactor :
                                      OrganicZeroEnergyFactor));
            }

            foreach (BotLifeForm bot in Organic.Values)
            {
                bot.Energy -= (int)(bot.Energy * OutflowEnergyFactor);
            }

            Point[] rottenOrganic = Organic.Where(x => ((BotLifeForm)x.Value).Energy <= 0)
                .Select(x => x.Key).ToArray();

            foreach (var botId in rottenOrganic)
            {
                Organic.Remove(botId);
            }

        }



        private void _genotypeReaction()
        {
            const int descendantPrice = 500;
            int worldWidth = Size.Width;
            int worldHeight = Size.Height;
            BotLifeForm botOnPlace;
            int X;
            int Y;
            foreach (BotLifeForm bot in LifeForms.Values.ToList())
            {
                bot.Energy -= 10;
                switch (bot.Action)
                {
                    case Actions.Move:
                        X = bot.LifeFormPoint.X;
                        Y = bot.LifeFormPoint.Y;
                        GetXY(ref X, ref Y, bot.Direction);
                        if (IsPlaceEmpty(X, Y, out botOnPlace))
                        {
                            LifeForms.Remove(bot.LifeFormPoint);
                            bot.LifeFormPoint = new Point(X, Y);
                            LifeForms.Add(bot.LifeFormPoint, bot);
                        }
                        break;
                    case Actions.Eat:
                        X = bot.LifeFormPoint.X;
                        Y = bot.LifeFormPoint.Y;
                        GetXY(ref X, ref Y, bot.Direction);
                        if (!IsPlaceEmpty(X, Y, out botOnPlace))
                        {
                            if (botOnPlace.Dead)
                            {
                                bot.Energy += botOnPlace.Energy;
                                _organic.Remove(botOnPlace.LifeFormPoint);
                            }
                            else
                            {
                                bot.Energy += (int)(botOnPlace.Energy * OrganicCollapseEnergyFactor);
                                LifeForms.Remove(botOnPlace.LifeFormPoint);
                            }
                            bot.LastEnergyActions.Enqueue(Actions.Eat);
                        }
                        break;
                    case Actions.DoDescendant:
                        X = bot.LifeFormPoint.X;
                        Y = bot.LifeFormPoint.Y;
                        GetXY(ref X, ref Y, bot.Direction);
                        if (IsPlaceEmpty(X, Y, out botOnPlace) && bot.EnergyState == EnergyStates.CanReproduce)
                        {
                            GenotypeState.DoDescendant(this.LifeForms, bot, X, Y);
                            bot.Energy -= descendantPrice;
                        }
                        break;
                    case Actions.ForsedReproduction:
                        X = bot.LifeFormPoint.X;
                        Y = bot.LifeFormPoint.Y;
                        if (IsAroundEmpty(ref X, ref Y))
                        {
                            GenotypeState.DoDescendant(this.LifeForms, bot, X, Y);
                            bot.Energy -= descendantPrice;
                        }
                        break;
                    case Actions.Photosynthesis:
                        NaturalPhenomena["SunPhenomen"].GetEffects(bot);
                        break;
                    case Actions.Extraction:
                        NaturalPhenomena["MineralsPhenomen"].GetEffects(bot);
                        break;
                    case Actions.CheckEnergy:
                        //todo
                        break;
                }
            }
        }



        private void _colorReaction()
        {

        }

        public void GetXY(ref int X, ref int Y, Directions direction)
        {
            switch (direction)
            {
                case Directions.TopLeft:
                    X--;
                    Y++;
                    break;
                case Directions.Top:
                    Y++;
                    break;
                case Directions.TopRight:
                    X++;
                    Y++;
                    break;
                case Directions.Right:
                    X++;
                    break;
                case Directions.BottomRight:
                    X++;
                    Y--;
                    break;
                case Directions.Bottom:
                    Y--;
                    break;
                case Directions.BottomLeft:
                    X--;
                    Y--;
                    break;
                case Directions.Left:
                    X--;
                    break;
                default:
                    throw new ArgumentException("Неопределенное направление  " + direction);
            }
            if (Y > _size.Height - 1)
                Y = this._size.Height - 1;
            if (Y < 0)
                Y = 0;
            if (X > this._size.Width - 1)
                X = 0;
            if (X < 0)
                X = this._size.Width - 1;
        }

        /// <summary>
        /// Определяет,свободна ли выбранная клетка,и если нет,то возвращает форму жизни в данной клетке
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="botOnPlace"></param>
        /// <returns></returns>
        public bool IsPlaceEmpty(int X, int Y, out BotLifeForm botOnPlace)
        {
            if (LifeForms.ContainsKey(new Point(X, Y)))
            {
                botOnPlace = (BotLifeForm)LifeForms[new Point(X, Y)];
                return false;
            }
            if (Organic.ContainsKey(new Point(X, Y)))
            {
                botOnPlace = (BotLifeForm)Organic[new Point(X, Y)];
                return false;
            }
            botOnPlace = null;
            return true;
        }

        /// <summary>
        /// Определяет,есть ли вокруг данной клетки свободное пространство,возвращает bool и передаёт координаты клетки в ref параметрах,
        /// в противном случае возвращает false и исходные координаты центральной клетки
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public bool IsAroundEmpty(ref int X, ref int Y)
        {
            BotLifeForm bot = null;
            int workX = X;
            int workY = Y;
            workY++;
            workX--;
            for (int i = 1; i < 4; i++)
            {
                if (workY > Size.Height - 1)
                    workY = Size.Height - 1;
                if (workY < 0)
                    workY = 0;
                if (workX > Size.Width - 1)
                    workX = 0;
                if (workX < 0)
                    workX = Size.Width - 1;
                if (IsPlaceEmpty(workX, workY, out bot))
                {
                    X = workX;
                    Y = workY;
                    return true;
                }
                workY--;
            }
            workX++;
            workY--;
            for (int i = 1; i < 4; i++)
            {
                workY++;
                if (i == 2)
                {
                    continue;
                }
                if (workY > Size.Height - 1)
                    workY = Size.Height - 1;
                if (workY < 0)
                    workY = 0;
                if (workX > Size.Width - 1)
                    workX = 0;
                if (workX < 0)
                    workX = Size.Width - 1;
                if (IsPlaceEmpty(workX, workY, out bot))
                {
                    X = workX;
                    Y = workY;
                    return true;
                }
            }
            workX++;
            for (int i = 1; i < 4; i++)
            {
                if (workY > Size.Height - 1)
                    workY = Size.Height - 1;
                if (workY < 0)
                    workY = 0;
                if (workX > Size.Width - 1)
                    workX = 0;
                if (workX < 0)
                    workX = Size.Width - 1;
                if (IsPlaceEmpty(workX, workY, out bot))
                {
                    X = workX;
                    Y = workY;
                    return true;
                }
                workY--;
            }
            return false;
        }

        public static Dictionary<string, IPhenomen> GetPhenomens(MapSize map)
        {
            Dictionary<string, IPhenomen> ret = new Dictionary<string, IPhenomen> { };
            SunPhenomen sun = new SunPhenomen(map);
            MineralsPhenomen minerals = new MineralsPhenomen(map);
            SeasonsPhenomen seasons = new SeasonsPhenomen();
            ret.Add("SunPhenomen", sun);
            ret.Add("MineralsPhenomen", minerals);
            ret.Add("SeasonsPhenomen", seasons);
            return ret;
        }
        #endregion


        #region constructors

        /// <inheritdoc />
        /// <summary>
        /// Инициализирует Simple2DWorld из заданных параметров
        /// </summary>
        /// <param name="name">Название мира</param>
        /// <param name="environment">Окружающая среда мира</param>
        /// <param name="visualizer">Визуализатор для мира</param>
        /// <param name="lifeForms">Формы жизни</param>
        /// <param name="organic">"мертвые" формы жизни, являющиеся органикой</param>
        public Simple2DWorld(string name, IVisualizer visualizer, Dictionary<Point, LifeForm> lifeForms, List<LifeForm> organic, Dictionary<string, IPhenomen> phenomens, MapSize map) :
            base(name, visualizer, lifeForms, phenomens, map)
        {
            log.Trace(LogMetadataMessages.Constructor, "Simple2DWorld");

            _organic = new Dictionary<Point, LifeForm>();
            if (organic != null)
            {
                foreach (var lifeForm in organic)
                {
                    _organic.Add(lifeForm.LifeFormPoint, lifeForm);
                }
            }

            log.Info("Кол-во органики " + _organic.Count.ToString());

            _InitReactions();
            log.Trace(LogMetadataMessages.OkConstructor, "Simple2DWorld");

        }


        /// <summary>
        /// Производит первичную инициализацию мира
        /// </summary>
        /// <param name="width">Ширина карты мира</param>
        /// <param name="height">Высота карты мира</param>
        /// <param name="lifeFormCount">Количество форм жизни</param>
        public Simple2DWorld(int width = 1000, int height = 1000, int lifeFormCount = 100) :
            this("Simple2DWorld", new RemoteVisualizer(), _getLifeForms(lifeFormCount, width, height), null, GetPhenomens(new MapSize(width, height)), new MapSize(width, height))
        {
            _states = new Dictionary<string, LifeFormState> { };
            EnergyState energy = new EnergyState("EnergyState", 0); // по моей задумке доп. параметры во всех состояниях бессмысленны
            GenotypeState genotype = new GenotypeState("GenotypeState", 0);
            ColorState color = new ColorState("ColorState", 0, ColorType.Default);
            _states.Add("EnergyState", energy);
            _states.Add("GenotypeState", genotype);
            _states.Add("ColorState", color);
            log.Trace(LogMetadataMessages.OkConstructor, "Simple2DWorld");
        }
        #endregion
    }
}
