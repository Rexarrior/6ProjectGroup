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
        
        private const int MineralsSpread = 100;
        private const int PercentOfMap = 50;    
        private const string ActionExtractionName = "Extraction";

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
        public List<StateMetadata> GetEffects(Point point, LifeFormMetadata lifeFormMetadata)
        {
            log.Trace(LogPhenomenMessages.PhenomenGetEffects, "MineralsPhenomen", point.X.ToString(), point.Y.ToString());
            if (point == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(point));
                log.Error(LogPhenomenMessages.NullArgument,"Point",ex);
                throw ex;
            }

            if (lifeFormMetadata == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(lifeFormMetadata));
                log.Error(LogPhenomenMessages.NullArgument, "LifeFormMetadata",ex);
                throw ex;
            }

            if (!isIn(point))
            {
                ArgumentException ex = new ArgumentException("Point isn't in phenomen area.", nameof(point));
                log.Error(LogPhenomenMessages.PointNotFound + ex);
                throw ex;
            }

            if (!lifeFormMetadata.ContainsKey("GenotypeState"))
            {
                ArgumentException ex = new ArgumentException("life form metadata isn't contains Genotype state metadata", nameof(lifeFormMetadata));
                log.Error(LogPhenomenMessages.GenotypeStateNotFound + ex);
                throw ex;
            }


            if (!lifeFormMetadata["GenotypeState"].ContainsKey("Action") ||
            lifeFormMetadata["GenotypeState"]["Action"] != ActionExtractionName)
            {
                log.Info(LogPhenomenMessages.GenotypeStateAction);
                return new List<StateMetadata>(0);
            }


            double depthFactor = 1 / (1 + ((_place[1].Y-point.Y)/ _place[0].Y));
            log.Info(LogPhenomenMessages.DepthFactorCalc, depthFactor.ToString());


            StateMetadata stateMetadata = new StateMetadata("EnergyState", MineralsSpread * depthFactor, null);
            List<StateMetadata> ret = new List<StateMetadata>(1);
            ret.Add(stateMetadata);
            log.Trace(LogPhenomenMessages.EndMethod, "MineralsPhenomen.GetEffects");
            return ret;
        }



        /// <summary>
        /// Возвращает экземпляр  класса Place, представляющий пространство,
        /// на  которое воздействует этот феномен
        /// </summary>
        public Place GetItPlace()
        {
            log.Debug(LogPhenomenMessages.GetPlace, "MineralsPhenomen");
            return _place;
        }



        /// <summary>
        /// Получает метаданные этого природного явления
        /// </summary>
        /// <returns>Метаданные</returns>
        public PhenomenMetadata GetMetadata()
        {
            log.Debug(LogPhenomenMessages.GetMetadata, "MineralsPhenomen");
            Dictionary<string, string> param = new Dictionary<string, string>(1);
            param.Add("Percent", PercentOfMap.ToString());
            PhenomenMetadata ret = new PhenomenMetadata("MineralsPhenomen", _place, this.GetType().Name, param);
            log.Trace(LogPhenomenMessages.EndMethod, "MineralsPhenomen.GetMetadata");
            return ret;
        }



        /// <summary>
        /// Проверяет, попадает ли точка под действие природного явления
        /// </summary>
        /// <param name="point">Точка для проверки</param>
        /// <returns>Попадает?</returns>
        public bool isIn(Point point)
        {
            log.Trace(LogPhenomenMessages.PhenomenIsIn, "MineralsPhenomen");
            if (point == null)
            {                
                ArgumentNullException ex = new ArgumentNullException(nameof(point));
                log.Error(LogPhenomenMessages.NullArgument,"Point",ex);
                throw ex;
            }

            return _place.IsIn(point);
        }



        public void Update(WorldMetadata worldMetadata)
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
            if(mapSize ==null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(mapSize));
                log.Error(LogPhenomenMessages.NullArgument, "MapSize", ex);
                throw ex;
            }
            List<Point> points = new List<Point>(2);
            points.Add(new Point(0, mapSize.Height *(PercentOfMap/100)));
            points.Add(new Point(mapSize.Width, mapSize.Height));
            _place = new Place(points, PlaceType.Rectangle);
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
