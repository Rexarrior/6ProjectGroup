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

        private const string ActionPhotosynthesisName = "Photosynthesis";


        #region fields

        private double _powerFactor;

        private Place _place;

        private MapSize _mapSize;


        #endregion

        #region  properties



        #endregion

        #region Methods

        ///<inheritdoc cref="IPhenomen.Update"/>>
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




        ///<inheritdoc cref="IPhenomen.GetEffects"/>>
        public List<StateMetadata> GetEffects(Point point, LifeFormMetadata lifeFormMetadataMetadata)
        {
            if (point == null)
                throw new ArgumentNullException(nameof(point));

            if (lifeFormMetadataMetadata == null)
                throw  new ArgumentNullException(nameof(lifeFormMetadataMetadata));

            if (!lifeFormMetadataMetadata.ContainsKey("GenotypeState"))
                throw  new ArgumentException("life form metadata isn't contains Genotype state metadata", nameof(lifeFormMetadataMetadata));


            if (!lifeFormMetadataMetadata["GenotypeState"].Params.ContainsKey("Action") ||
            lifeFormMetadataMetadata["GenotypeState"].Params["Action"] != ActionPhotosynthesisName)
            {
                return  new List<StateMetadata>(0);
            }


            double depthFactor = (point.Y - _place[0].Y) *
                                 (_place[1].Y / _mapSize.Height);
            StateMetadata stateMetadata = new StateMetadata("EnergyState", BaseIntensity * _powerFactor * depthFactor, null);

            List<StateMetadata> ret = new List<StateMetadata>(1);
            ret.Add(stateMetadata);

            return ret;

        }



        ///<inheritdoc cref="IPhenomen.isIn"/>>
        public bool isIn(Point point)
        {
            if (point == null)
            {
                throw  new ArgumentNullException(nameof(point));
            }

            List<Point> points = new List<Point>(1);
            points.Add(point);

            return _place.Intersect(new Place(points)).Points.Count == 1;
        }



        ///<inheritdoc cref="IPhenomen.GetItPlace"/>>
        public Place GetItPlace()
        {
            return _place;
        }


        ///<inheritdoc cref="IPhenomen.GetMetadata"/>>
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

            _mapSize = mapSize ?? throw new ArgumentNullException(nameof(mapSize));

            List<Point> points = new List<Point>(2);
            points.Add(new Point(0, 0));
            points.Add(new Point(mapSize.Width, mapSize.Height / 2));

            _place = new Place(points, PlaceType.Rectangle);
        }


        #endregion
    }
}
