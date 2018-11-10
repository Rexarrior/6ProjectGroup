using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberLife.Platform.Logging.LogMessages;
using NLog;

namespace CyberLife.Simple2DWorld
{

    class MineralsPhenomen : IPhenomen
    {
        Logger log = LogManager.GetCurrentClassLogger();

        private const int MineralsSpread = 300;
        private const int PercentOfMap = 50;

        #region fields

        private Place _place;

        #endregion


        #region  properties

        public int Percent { get => PercentOfMap; }

        #endregion


        #region Methods

        /// <summary>
        /// Определяет, оказывает ли феномен воздействие на форму жизни и возвращает 
        /// результат этого воздействия
        /// </summary>
        /// <param name="point">Точка</param>
        /// <param name="lifeFormMetadataMetadata">метаданные форммы жизни, находящейся в этой точке</param>
        /// <returns>Эффект воздействия феномена</returns>
        public void GetEffects(LifeForm bot)
        {
            Point botPoint = new Point(bot.LifeFormPoint.X, bot.LifeFormPoint.Y);
            if (isIn(botPoint))
            {
                double depthFactor = 1 / (1 + ((double)(_place[1].Y - botPoint.Y) / _place[0].Y));
                ((BotLifeForm)bot).Energy += (int)(MineralsSpread * depthFactor);
                ((BotLifeForm)bot).LastEnergyActions.Enqueue(Actions.Extraction);
            }
        }



        /// <summary>
        /// Возвращает экземпляр  класса LifeFormPlace, представляющий пространство,
        /// на  которое воздействует этот феномен
        /// </summary>
        public Place GetItPlace()
        {
            log.Debug(LogPhenomenMessages.GetPlace, "MineralsPhenomen");
            return _place;
        }



        /// <summary>
        /// Проверяет, попадает ли точка под действие природного явления
        /// </summary>
        /// <param name="point">Точка для проверки</param>
        /// <returns>Попадает?</returns>
        public bool isIn(Point point)
        {
            log.Trace(LogPhenomenMessages.PhenomenIsIn, "MineralsPhenomen");

            return _place.IsIn(point);
        }



        public void Update(World worldMetadata)
        {

        }

        #endregion


        #region  constructors

        /// <summary>
        /// Инициализирует экземпляр MineralsPhenomen,
        /// занимающий нижнюю половину площади карты
        /// </summary>
        /// <param name="mapSize">Размер карты</param>
        public MineralsPhenomen(MapSize mapSize)
        {
            log.Trace(LogPhenomenMessages.Constructor, "MineralsPhenomen");
            if (mapSize == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(mapSize));
                log.Error(LogPhenomenMessages.NullArgument, "MapSize", ex);
                throw ex;
            }
            List<Point> points = new List<Point>(2);
            points.Add(new Point(0, mapSize.Height / (100 / PercentOfMap)));
            points.Add(new Point(mapSize.Width, mapSize.Height));
            _place = new Place(points, PlaceType.Rectangle);
            _place.PlaceType = PlaceType.Rectangle;
            log.Trace(LogPhenomenMessages.OkConstructor, "MineralsPhenomen");
        }


        /// <summary>
        /// Инициализирует экземпляр MineralsPhenomen, 
        /// занимающий указанное place пространство
        /// </summary>
        /// <param name="place">Пространство, которое будет занимать феномен</param>
        public MineralsPhenomen(Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException();
            }

            _place = place;

        }

        #endregion
    }
}
