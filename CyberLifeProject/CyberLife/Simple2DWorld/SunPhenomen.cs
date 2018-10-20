using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using CyberLife.Platform.Logging.LogMessages;
using CyberLife.Platform.World_content;
using NLog;

namespace CyberLife.Simple2DWorld
{
    class SunPhenomen : IPhenomen
    {
        Logger log = LogManager.GetCurrentClassLogger();

        private const int BaseIntensity = 100;
        private const double NormalPowerFactor = 1;
        private const double LowPowerFactor = 0.5;
        private const double HightPowerFactor = 1.5;
        private const double SunDepthFactor = 0.5; 


        #region fields

        private double _powerFactor;

        private Place _place;

        #endregion




        #region  properties



        #endregion

        #region Methods


        /// <summary>
        /// Вызывает обновление интенсивности в зависимости от текущего сезона
        /// </summary>
        /// <param name="worldMetadata">Метаданные мира. В окружающей среде должен быть феномен времен года.</param>
        public void Update(World world)
        {
            log.Trace(LogPhenomenMessages.PhenomenUpdate, "SunPhenomen");
            if (!world.NaturalPhenomena.ContainsKey("SeasonsPhenomen"))
            {
               ArgumentException ex = new ArgumentException("world metadata isn't contains SeasonPhenomen metadata", nameof(world));
                log.Error(LogPhenomenMessages.BadInputMetadata, "SeasonsPhenomen");
                throw ex;
            }

            Season season = ((SeasonsPhenomen)world.NaturalPhenomena["SeasonsPhenomen"]).CurSeason;
            log.Info(LogPhenomenMessages.CurrentSeason, season.ToString());
            switch (season)
            {
                case Season.Autumn:
                case Season.Spring:
                    {
                        _powerFactor = NormalPowerFactor;
                    }
                    break;

                case Season.Summer:
                    {
                        _powerFactor = HightPowerFactor;
                    }
                    break;

                case Season.Winter:
                    {
                        _powerFactor = LowPowerFactor;
                    }
                    break;

                default:
                    {
                        Exception ex = new Exception("Impossible");
                        log.Error("Сезоны отвалились,текущий сезон равен: "+season.ToString()+"  "+ ex);
                        throw ex;
                    }

            }

        }



        /// <summary>
        /// Определяет, оказывает ли феномен воздействие на форму жизни и возвращает 
        /// результат этого воздействия
        /// </summary>
        /// <param name="point">Точка</param>
        /// <param name="lifeFormMetadataMetadata">метаданные форммы жизни, находящейся в этой точке</param>
        /// <returns>Эффект воздействия феномена</returns>
        public void GetEffects(LifeForm bot)
        {
            log.Trace(LogPhenomenMessages.PhenomenGetEffects, "SunPhenomen", bot.LifeFormPlace[0].X, bot.LifeFormPlace[0].Y);
            if (bot == null)
            {
                ArgumentException ex = new ArgumentNullException(nameof(bot));
                log.Error(LogPhenomenMessages.NullArgument, "bot", ex);
                throw ex;
            }

            Point botPoint = new Point(bot.LifeFormPlace[0].X, bot.LifeFormPlace[0].Y);
            if (isIn(botPoint))
            {
                double depthFactor = 1 / (1 + (botPoint.Y - _place[0].Y) / _place[1].Y);
                ((BotLifeForm)bot)._energy +=(int)( BaseIntensity * _powerFactor * depthFactor);
            }

        }


        /// <summary>
        /// Проверяет, попадает ли точка под действие природного явления
        /// </summary>
        /// <param name="point">Точка для проверки</param>
        /// <returns>Попадает?</returns>
        public bool isIn(Point point)
        {
            log.Trace(LogPhenomenMessages.PhenomenIsIn, "SunPhenomen");
            if (point == null)
            {
                ArgumentNullException ex =  new ArgumentNullException(nameof(point));
                log.Error(LogPhenomenMessages.NullArgument, "Point", ex);
                throw ex;
            }

            return _place.IsIn(point);
        }



        /// <inheritdoc />
        /// <summary>
        /// Возвращает экземпляр  класса LifeFormPlace, представляющий пространство,
        /// на  которое воздействует этот феномен
        /// </summary>
        public Place GetItPlace()
        {
            log.Debug(LogPhenomenMessages.GetPlace, "SunPhenomen");
            return _place;
        }

      


        #endregion


        #region  constructors

        /// <summary>
        /// Инициализирует экземпляр SunPhenomen,
        /// занимающий верхнюю половину площади карты
        /// </summary>
        /// <param name="mapSize">Размер карты</param>
        public SunPhenomen(MapSize mapSize)
        {
            log.Trace(LogPhenomenMessages.Constructor, "SunPhenomen");
            _powerFactor = NormalPowerFactor;
            if (mapSize == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(mapSize));
                log.Error(LogPhenomenMessages.NullArgument, "MapSize", ex);
                throw ex;
            }
            List<Point> points = new List<Point>(2);
            points.Add(new Point(0, 0));            
            points.Add(new Point(mapSize.Width, (int)Math.Round(mapSize.Height * SunDepthFactor)));
            _place = new Place(points, PlaceType.Rectangle);
            _place.PlaceType = PlaceType.Rectangle;
            log.Trace(LogPhenomenMessages.OkConstructor, "SunPhenomen");
        }



        /// <summary>
        /// Инициализирует экземпляр SunPhenomen, 
        /// занимающий указанное place пространство
        /// </summary>
        /// <param name="place">Пространство, которое будет занимать феномен</param>
        public SunPhenomen(Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException();
            }

            _place = place;
            _powerFactor = NormalPowerFactor;

        }

        #endregion
    }
}
