using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using CyberLife.Platform.World_content;
using NLog;

namespace CyberLife.Simple2DWorld
{
    /// <summary>
    /// Природное явление "солнце". Не реализовано.
    /// </summary>
    class SunPhenomen : IPhenomen
    {
        Logger log = LogManager.GetCurrentClassLogger();

        private const int BaseIntensity = 100;
        private const double NormalPowerFactor = 1;
        private const double LowPowerFactor = 0.5;
        private const double HightPowerFactor = 1.5;
        private const double SunDepthFactor = 0.5; 


        private const string ActionPhotosynthesisName = "Photosynthesis";


        #region fields

        private double _powerFactor;

        private Place _place;

        private MapSize _mapSize;


        #endregion

        #region  properties



        #endregion

        #region Methods


        /// <summary>
        /// Вызывает обновление интенсивности в зависимости от текущего сезона
        /// </summary>
        /// <param name="worldMetadata">Метаданные мира. В окружающей среде должен быть феномен времен года.</param>
        public void Update(WorldMetadata worldMetadata)
        {
            log.Debug(LogMessages.PhenomenUpdate, "SunPhenomen");
            if (!worldMetadata.EnvironmentMetadata.ContainsKey("SeasonsPhenomen"))
            {
               ArgumentException ex = new ArgumentException("world metadata isn't contains SeasonPhenomen metadata", nameof(worldMetadata));
                log.Error(LogMessages.BadInputMetadata, "SeasonsPhenomen");
                throw ex;
            }


            if (!worldMetadata.EnvironmentMetadata["SeasonsPhenomen"].ContainsParameter("season"))
            {
                ArgumentException ex = new ArgumentException("SeasonsPhenomen metadata isn't contains the parameter named \"season\"");
                log.Error(LogMessages.BadInputMetadata, "SeasonsPhenomen");
                throw ex;
            }

            Season season = (Season)(int.Parse(worldMetadata.EnvironmentMetadata["SeasonsPhenomen"]["season"]));
            log.Info(LogMessages.CurrentSeason, season.ToString());
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
        public List<StateMetadata> GetEffects(Point point, LifeFormMetadata lifeFormMetadataMetadata)
        {
            if (point == null)
            {
                ArgumentException ex = new ArgumentNullException(nameof(point));
                log.Error(LogMessages.NullArgument, "Point",ex);
                throw ex;
            }

            if (lifeFormMetadataMetadata == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(lifeFormMetadataMetadata));
                log.Error(LogMessages.NullArgument, "LifeFormMetadata", ex);
                throw ex;
            }


            if (!isIn(point))
            {
                ArgumentException ex = new ArgumentException("Point isn't in phenomen area.", nameof(point));
                log.Error(LogMessages.PointNotFound);
                throw ex;
            }


            if (!lifeFormMetadataMetadata.ContainsKey("GenotypeState"))
            {
                ArgumentException ex = new ArgumentException("life form metadata isn't contains Genotype state metadata", nameof(lifeFormMetadataMetadata));
                log.Error(LogMessages.GenotypeStateNotFound);
                throw ex;
            }


            if (!lifeFormMetadataMetadata["GenotypeState"].Params.ContainsKey("Action") ||
            lifeFormMetadataMetadata["GenotypeState"].Params["Action"] != ActionPhotosynthesisName)
            {
                log.Info(LogMessages.GenotypeStateAction);
                return  new List<StateMetadata>(0);
            }


            double depthFactor =  1 / (1 + (point.Y - _place[0].Y)/_place[1].Y);


            log.Info(LogMessages.DepthFactorCalc, depthFactor.ToString());
            StateMetadata stateMetadata = new StateMetadata("EnergyState", BaseIntensity * _powerFactor  * depthFactor, null);

            List<StateMetadata> ret = new List<StateMetadata>(1);
            ret.Add(stateMetadata);
            log.Debug(LogMessages.EndMethod, "SunPhenomen.GetEffects");
            return ret;

        }


        /// <summary>
        /// Проверяет, попадает ли точка под действие природного явления
        /// </summary>
        /// <param name="point">Точка для проверки</param>
        /// <returns>Попадает?</returns>
        public bool isIn(Point point)
        {
            log.Debug(LogMessages.PhenomenIsIn, "SunPhenomen");
            if (point == null)
            {
                ArgumentNullException ex =  new ArgumentNullException(nameof(point));
                log.Error(LogMessages.NullArgument, "Point", ex);
                throw ex;
            }

            return _place.IsIn(point);
        }



        /// <inheritdoc />
        /// <summary>
        /// Возвращает экземпляр  класса Place, представляющий пространство,
        /// на  которое воздействует этот феномен
        /// </summary>
        public Place GetItPlace()
        {
            log.Debug(LogMessages.GetPlace, "SunPhenomen");
            return _place;
        }

        
        /// <inheritdoc />
        /// <summary>
        /// Получает метаданные этого природного явления
        /// </summary>
        /// <returns>Метаданные</returns>
        public PhenomenMetadata GetMetadata()
        {
            log.Debug(LogMessages.GetMetadata, "SunPhenomen");
            Dictionary<string, string> param = new Dictionary<string, string>(1);
            param.Add("Intensity",(BaseIntensity * _powerFactor).ToString(CultureInfo.InvariantCulture));
            PhenomenMetadata ret = new PhenomenMetadata("SunPhenomen", _place, this.GetType().Name, param);
            log.Debug(LogMessages.EndMethod, "SunPhenomen.GetMetadata");
            return ret;
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
            log.Debug(LogMessages.Constructor, "SunPhenomen");
            _powerFactor = NormalPowerFactor;
            if (mapSize == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(mapSize));
                log.Error(LogMessages.NullArgument, "MapSize", ex);
                throw ex;
            }
            _mapSize = mapSize;
            List<Point> points = new List<Point>(2);
            points.Add(new Point(0, 0));            
            points.Add(new Point(mapSize.Width, (int)Math.Round(mapSize.Height * SunDepthFactor)));
            _place = new Place(points, PlaceType.Rectangle);
            log.Debug(LogMessages.OkConstructor, "SunPhenomen");
        }


        #endregion
    }
}
