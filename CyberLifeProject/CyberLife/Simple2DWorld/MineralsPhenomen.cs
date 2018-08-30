using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private MapSize _mapSize;

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
            log.Debug(Resources.PhenomenGetEffects, "MineralsPhenomen", point.X.ToString(), point.Y.ToString());
            if (point == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(point));
                log.Error(Resources.NullArgument,"Point",ex);
                throw ex;
            }

            if (lifeFormMetadata == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(lifeFormMetadata));
                log.Error(Resources.NullArgument, "LifeFormMetadata",ex);
                throw ex;
            }

            if (!isIn(point))
            {
                ArgumentException ex = new ArgumentException("Point isn't in phenomen area.", nameof(point));
                log.Error(Resources.PointNotFound + ex);
                throw ex;
            }

            if (!lifeFormMetadata.ContainsKey("GenotypeState"))
            {
                ArgumentException ex = new ArgumentException("life form metadata isn't contains Genotype state metadata", nameof(lifeFormMetadata));
                log.Error(Resources.GenotypeStateNotFound + ex);
                throw ex;
            }


            if (!lifeFormMetadata["GenotypeState"].Params.ContainsKey("Action") ||
            lifeFormMetadata["GenotypeState"].Params["Action"] != ActionExtractionName)
            {
                log.Info(Resources.GenotypeStateAction);
                return new List<StateMetadata>(0);
            }


            double depthFactor = 1 / (1 + ((_place[1].Y-point.Y)/ _place[0].Y));
            log.Debug(Resources.DepthFactorCalc, depthFactor.ToString());


            StateMetadata stateMetadata = new StateMetadata("EnergyState", MineralsSpread * depthFactor, null);
            List<StateMetadata> ret = new List<StateMetadata>(1);
            ret.Add(stateMetadata);
            log.Info(Resources.EndMethod, "MineralsPhenomen.GetEffects");
            return ret;
        }



        /// <summary>
        /// Возвращает экземпляр  класса Place, представляющий пространство,
        /// на  которое воздействует этот феномен
        /// </summary>
        public Place GetItPlace()
        {
            log.Debug(Resources.GetPlace, "MineralsPhenomen");
            return _place;
        }



        /// <summary>
        /// Получает метаданные этого природного явления
        /// </summary>
        /// <returns>Метаданные</returns>
        public PhenomenMetadata GetMetadata()
        {
            log.Debug(Resources.GetMetadata, "MineralsPhenomen");
            Dictionary<string, string> param = new Dictionary<string, string>(1);
            param.Add("Percent", PercentOfMap.ToString());
            PhenomenMetadata ret = new PhenomenMetadata("MineralsPhenomen", _place, this.GetType().Name, param);
            log.Info(Resources.EndMethod, "MineralsPhenomen.GetMetadata");
            return ret;
        }



        /// <summary>
        /// Проверяет, попадает ли точка под действие природного явления
        /// </summary>
        /// <param name="point">Точка для проверки</param>
        /// <returns>Попадает?</returns>
        public bool isIn(Point point)
        {
            log.Debug(Resources.PhenomenIsIn, "MineralsPhenomen");
            if (point == null)
            {                
                ArgumentNullException ex = new ArgumentNullException(nameof(point));
                log.Error(Resources.NullArgument,"Point",ex);
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
            log.Debug(Resources.Constructor, "MineralsPhenomen");
            if(mapSize ==null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(mapSize));
                log.Error(Resources.NullArgument, "Point", ex);
                throw ex;
            }
            _mapSize = mapSize ?? throw new ArgumentNullException(nameof(mapSize));
            List<Point> points = new List<Point>(2);
            points.Add(new Point(0, mapSize.Height *(PercentOfMap/100)));
            points.Add(new Point(mapSize.Width, mapSize.Height));
            _place = new Place(points, PlaceType.Rectangle);
            log.Debug(Resources.OkConstructor, "MineralsPhenomen");
        }

        #endregion
    }
}
