using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using CyberLife.Platform.World_content;

namespace CyberLife.Simple2DWorld
{
    /// <summary>
    /// Природное явление "солнце". Не реализовано.
    /// </summary>
    class SunPhenomen : IPhenomen
    {
        private const int BaseIntensity = 100;
        private const double NormalPowerFactor = 1;
        private const double LowPowerFactor = 0.5;
        private const double HightPowerFactor = 1.5;
        private const double SunDepthFactor = 0.5; 


        private const string ActionPhotosynthesisName = "Photosynthesis";


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
        public void Update(WorldMetadata worldMetadata)
        {
            if (!worldMetadata.EnvironmentMetadata.ContainsKey("SeasonsPhenomen"))
                throw new ArgumentException("world metadata isn't contains SeasonPhenomen metadata", nameof(worldMetadata));


            if (!worldMetadata.EnvironmentMetadata["SeasonsPhenomen"].ContainsParameter("season"))
                throw new ArgumentException("SeasonsPhenomen metadata isn't contains the parameter named \"season\"");

            Season season = (Season)(int.Parse(worldMetadata.EnvironmentMetadata["SeasonsPhenomen"]["season"]));
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
                        throw new Exception("Impossible");
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
                throw new ArgumentNullException(nameof(point));

            if (lifeFormMetadataMetadata == null)
                throw  new ArgumentNullException(nameof(lifeFormMetadataMetadata));


            if (!isIn(point))
                throw new ArgumentException("Point isn't in phenomen area.", nameof(point));


            if (!lifeFormMetadataMetadata.ContainsKey("GenotypeState"))
                throw  new ArgumentException("life form metadata isn't contains Genotype state metadata", nameof(lifeFormMetadataMetadata));


            if (!lifeFormMetadataMetadata["GenotypeState"].Params.ContainsKey("Action") ||
            lifeFormMetadataMetadata["GenotypeState"].Params["Action"] != ActionPhotosynthesisName)
            {
                return  new List<StateMetadata>(0);
            }


            double depthFactor =  1 / (1 + (point.Y - _place[0].Y)/_place[1].Y); 



            StateMetadata stateMetadata = new StateMetadata("EnergyState", BaseIntensity * _powerFactor  * depthFactor, null);

            List<StateMetadata> ret = new List<StateMetadata>(1);
            ret.Add(stateMetadata);

            return ret;

        }


        /// <summary>
        /// Проверяет, попадает ли точка под действие природного явления
        /// </summary>
        /// <param name="point">Точка для проверки</param>
        /// <returns>Попадает?</returns>
        public bool isIn(Point point)
        {
            if (point == null)
            {
                throw  new ArgumentNullException(nameof(point));
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
            return _place;
        }

        
        /// <inheritdoc />
        /// <summary>
        /// Получает метаданные этого природного явления
        /// </summary>
        /// <returns>Метаданные</returns>
        public PhenomenMetadata GetMetadata()
        {
            Dictionary<string, string> param = new Dictionary<string, string>(1);
            param.Add("Intensity",(BaseIntensity * _powerFactor).ToString(CultureInfo.InvariantCulture));
            PhenomenMetadata ret = new PhenomenMetadata("SunPhenomen", _place, this.GetType().Name, param);
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

            _powerFactor = NormalPowerFactor;

            if (mapSize == null)
                throw new ArgumentNullException(nameof(mapSize));

            List<Point> points = new List<Point>(2);
            points.Add(new Point(0, 0));
            
            points.Add(new Point(mapSize.Width, (int)Math.Round(mapSize.Height * SunDepthFactor)));
            _place = new Place(points, PlaceType.Rectangle);
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
