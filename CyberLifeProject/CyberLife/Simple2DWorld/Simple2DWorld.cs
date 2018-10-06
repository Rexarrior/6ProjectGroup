using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberLife.Platform.Logging.LogMessages;
using CyberLife.Platform.World_content;

namespace CyberLife.Simple2DWorld
{
    class Simple2DWorld : World
    {
        public  const double OrganicZeroEnergyFactor = 0.1;
        public  const double OrganicCollapseEnergyFactor = 0.3;
        public const double OutflowEnergyFactor = 0.01; 
        #region fields

        private Dictionary<Int64, LifeForm> _organic;

       

        #endregion


        #region properties
        public Dictionary<long, LifeForm> Organic { get => _organic; set => _organic = value; }

        #endregion


        #region methods

        /// <summary>
        /// Получает окружающую среду для первичной инициализации Simple2DWorld
        /// </summary>
        /// <param name="width">Ширина карты</param>
        /// <param name="height">Высота карты</param>
        /// <returns>Инициализированная окружающая среда</returns>
        private static Environment _getEnvironment(int width, int height)
        {
            MapSize mapsize = new MapSize(width, height);
            SunPhenomen sun = new SunPhenomen(mapsize);
            MineralsPhenomen minerals = new MineralsPhenomen(mapsize);
            SeasonsPhenomen seasons = new SeasonsPhenomen();
            List<IPhenomen> phenomens = new List<IPhenomen>(3) { seasons, minerals, sun };
            return new Environment(phenomens, mapsize);
        }



        /// <summary>
        /// Получает список форм жизни "Бот" для первичной инициализации 
        /// Simple2DWorld
        /// </summary>
        /// <param name="count">Число форм жизни</param>
        /// <param name="width">Ширина карты</param>
        /// <param name="height">Высота карты</param>
        /// <returns></returns>
        private static List<LifeForm> _getLifeForms(int count, int width, int height)
        {
            MapSize mapsize = new MapSize(width, height);
            List<LifeForm> lifeForms = new List<LifeForm>(count);
            for (int i = 0; i < count; i++)
            {
                lifeForms.Add(new BotLifeForm(mapsize));
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

            _reactions.Add("EnergyReaction",_energyReaction);
            _reactions.Add("GenotypeReaction",_genotypeReaction);
            _reactions.Add("ColorReaction", _colorReaction);
        }



        /// <summary>
        /// Реакция, отвечающая за изменение состояния 
        /// EnergyState у форм жизни
        /// </summary>
        /// <param name="world">Обрабатываемый мир</param>
        private static void _energyReaction(World world)
        {
            Simple2DWorld sworld = (Simple2DWorld)world;

            IEnumerable<Int64> deadBots = sworld.LifeForms
                .Where(
                    x => ((EnergyState)x.Value.States["EnergyState"]).IsDead
                ).Select(x => x.Key).ToArray();
            foreach (var botId in deadBots)
            {
                LifeForm bot = sworld.LifeForms[botId];
                sworld.Organic.Add(botId, bot);
                sworld.LifeForms.Remove(botId);
                EnergyState state = (EnergyState)bot.States["EnergyState"];
                state.Value = EnergyState.MaxEnergy * (
                    state.State == Flags.EnergyCollapse ? 
                        OrganicCollapseEnergyFactor:
                                      OrganicZeroEnergyFactor); 
            }

            foreach (var bot in sworld.Organic.Values)
            {
                EnergyState state = (EnergyState)bot.States["EnergyState"];
                state.Value -= state.Value * OutflowEnergyFactor;
            }

            Int64[] rottenOrganic = sworld.Organic.Where(x => x.Value.States["EnergyState"].Value <= 0)
                .Select(x => x.Key).ToArray();

            foreach (var botId in rottenOrganic)
            {
                sworld.Organic.Remove(botId);
            }

        }



        private static void _genotypeReaction(World world)
        {
            const int descendantPrice = 500;
            Simple2DWorld sworld = (Simple2DWorld)world;
            int worldWidth = sworld.Environment.Size.Width;
            int worldHeight = sworld.Environment.Size.Height;
            foreach (var bot in sworld.LifeForms.Values)
            {
                bot.States["EnergyState"].Value -= 10; 
                StateMetadata botMetadata = bot.States["GenotypeState"].GetMetadata();
                BotLifeForm botOnPlace;
                int X = bot.LifeFormPlace.Points[0].X;
                int Y = bot.LifeFormPlace.Points[0].Y;
                if (botMetadata["Action"].Contains('|'))
                {
                    switch (botMetadata["Action"].Split('|')[1])
                    {
                        case "TopLeft":
                            X--;
                            Y++;
                            break;
                        case "Top":
                            Y++;
                            break;
                        case "TopRight":
                            X++;
                            Y++;
                            break;
                        case "Right":
                            X++;
                            break;
                        case "BottomRight":
                            X++;
                            Y--;
                            break;
                        case "Bottom":
                            Y--;
                            break;
                        case "BottomLeft":
                            X--;
                            Y--;
                            break;
                        case "Left":
                            X--;
                            break;
                        default:
                            throw new ArgumentException("Неопределенное направление  " + botMetadata["Action"].Split('|')[1]);
                    }
                    if (Y > worldHeight - 1)
                        Y = worldHeight - 1;
                    if (Y < 0)
                        Y = 0;
                    if (X > worldWidth - 1)
                        X = 0;
                    if (X < 0)
                        X = worldWidth - 1;
                }
                switch (botMetadata["Action"].Split('|')[0])
                {
                    case "Move":
                        if (sworld.IsPlaceEmpty(X, Y, out botOnPlace))
                        {
                            bot.LifeFormPlace.Points[0].X = X;
                            bot.LifeFormPlace.Points[0].Y = Y;
                        }
                        break;
                    case "Eat":
                        if (!sworld.IsPlaceEmpty(X, Y, out botOnPlace))
                        {
                            if (((EnergyState)botOnPlace.States["EnergyState"]).IsDead)
                            {
                                bot.States["EnergyState"].Value += botOnPlace.States["EnergyState"].Value;
                                sworld._organic.Remove(botOnPlace.Id);
                            }
                            else
                            {
                                bot.States["EnergyState"].Value += botOnPlace.States["EnergyState"].Value * OrganicCollapseEnergyFactor;
                                sworld.LifeForms.Remove(botOnPlace.Id);
                            }
                        }
                        break;
                    case "DoDescendant":
                        if (sworld.IsPlaceEmpty(X, Y, out botOnPlace))
                        {
                            GenotypeState.DoDescendant(sworld, bot, X, Y);
                            bot.States["EnergyState"].Value -= descendantPrice;
                        }
                        break;
                    case "ForsedReproduction":
                        if (sworld.IsAroundEmpty(ref X, ref Y))
                        {
                            GenotypeState.DoDescendant(sworld, bot, X, Y);
                            bot.States["EnergyState"].Value -= descendantPrice; 
                        }
                        break;
                    case "Photosynthesis":
                        // получение энергии
                        break;
                    case "Extraction":
                        // получение энергии
                        break;
                    case "CheckEnergy":
                        //todo
                        break;
                }
            }
        }



        private static void _colorReaction(World world)
        {

        }



        /// <summary>
        /// Определяет,свободна ли выбранная клетка,и если нет,то возвращает форму жизни в данной клетке
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="botOnPlace"></param>
        /// <returns></returns>
        public bool IsPlaceEmpty(int X, int Y,out BotLifeForm botOnPlace)
        {
            foreach (var Bot in LifeForms.Values)
            {
                if (Bot.LifeFormPlace.Points[0].X == X &&
                    Bot.LifeFormPlace.Points[0].Y == Y)
                {
                    botOnPlace = (BotLifeForm)Bot;
                    return false;
                }
            }
            foreach(var Bot in Organic.Values)
            {
                if (Bot.LifeFormPlace.Points[0].X == X &&
                    Bot.LifeFormPlace.Points[0].Y == Y)
                {
                    botOnPlace = (BotLifeForm)Bot;
                    return false;
                }
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
        public bool IsAroundEmpty(ref int X,ref int Y)
        {
            BotLifeForm bot = null;
            int workX = X;
            int workY = Y;
            workY++;
            workX--;
            for (int i = 1; i < 4; i++)
            {
                if (workY > Environment.Size.Height - 1)
                    workY = Environment.Size.Height - 1;
                if (workY < 0)
                    workY = 0;
                if (workX > Environment.Size.Width - 1)
                    workX = 0;
                if (workX < 0)
                    workX = Environment.Size.Width - 1;
                if(IsPlaceEmpty(workX,workY,out bot))
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
                if (workY > Environment.Size.Height - 1)
                    workY = Environment.Size.Height - 1;
                if (workY < 0)
                    workY = 0;
                if (workX > Environment.Size.Width - 1)
                    workX = 0;
                if (workX < 0)
                    workX = Environment.Size.Width - 1;
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
                if (workY > Environment.Size.Height - 1)
                    workY = Environment.Size.Height - 1;
                if (workY < 0)
                    workY = 0;
                if (workX > Environment.Size.Width - 1)
                    workX = 0;
                if (workX < 0)
                    workX = Environment.Size.Width - 1;
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
        public Simple2DWorld(string name, Environment environment, IVisualizer visualizer, List<LifeForm> lifeForms, List<LifeForm> organic) :
            base(name, environment, visualizer, lifeForms)
        {
            log.Trace(LogMetadataMessages.Constructor, "Simple2DWorld");

            _organic = new Dictionary<Int64, LifeForm>();
            if (organic != null)
            {
                foreach (var lifeForm in organic)
                {
                    _organic.Add(lifeForm.Id, lifeForm);
                }
            }
                
            log.Info("Кол-во органики " + _organic.Count.ToString());

            _InitReactions();
            log.Trace(LogMetadataMessages.OkConstructor, "Simple2DWorld");

        }


        /// <inheritdoc />
        /// <summary>
        /// Инициализирует Simple2DWorld из метаданных и фабрики природных явлений
        /// </summary>
        /// <param name="metadata">Метаданные мра</param>
        /// <param name="phenomenaFabrica">Фабрика природных явлений для разбора природных явлений мира</param>
        public Simple2DWorld(Simple2DWorldMetadata metadata, IPhenomenaFabrica phenomenaFabrica) : base(metadata, phenomenaFabrica)
        {
            log.Trace(LogMetadataMessages.Constructor, "Simple2DWorld");
            _organic = new Dictionary<long, LifeForm>(metadata.OrganicMetadata.Count);
            foreach (var organicMetadataPair in metadata.OrganicMetadata)
            {
                
                _organic.Add(organicMetadataPair.Key, new LifeForm(organicMetadataPair.Value));                
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
        public Simple2DWorld(int width = 1000, int height = 1000, int lifeFormCount = 100 ):
            this("Simple2DWorld",_getEnvironment(width, height), new RemoteVisualizer(), _getLifeForms(lifeFormCount, width, height), null  )
        {
           
            _InitReactions();
            log.Trace(LogMetadataMessages.OkConstructor, "Simple2DWorld");
        }
        #endregion
    }
}
