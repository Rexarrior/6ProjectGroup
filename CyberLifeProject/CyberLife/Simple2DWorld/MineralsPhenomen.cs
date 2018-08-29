using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    class MineralsPhenomen : IPhenomen
    {
        private const int MineralsSpread = 100;
        private const int PercentOfMap = 50;
        private const string ActionExtractionName = "Extraction";
        

        public int Percent { get => PercentOfMap; }


        private Place _place;

        private MapSize _mapSize;

        public List<StateMetadata> GetEffects(Point point, LifeFormMetadata lifeFormMetadata)
        {
            if (point == null)
                throw new ArgumentNullException(nameof(point));

            if (lifeFormMetadata == null)
                throw new ArgumentNullException(nameof(lifeFormMetadata));


            if (!isIn(point))
                throw new ArgumentException("Point isn't in phenomen area.", nameof(point));


            if (!lifeFormMetadata.ContainsKey("GenotypeState"))
                throw new ArgumentException("life form metadata isn't contains Genotype state metadata", nameof(lifeFormMetadata));


            if (!lifeFormMetadata["GenotypeState"].Params.ContainsKey("Action") ||
            lifeFormMetadata["GenotypeState"].Params["Action"] != ActionExtractionName)
            {
                return new List<StateMetadata>(0);
            }


            double depthFactor = 1 / (1 + ((_place[1].Y-point.Y)/ _place[0].Y));



            StateMetadata stateMetadata = new StateMetadata("EnergyState", MineralsSpread * depthFactor, null);
            List<StateMetadata> ret = new List<StateMetadata>(1);
            ret.Add(stateMetadata);

            return ret;
        }

        public Place GetItPlace()
        {
            return _place;
        }

        public PhenomenMetadata GetMetadata()
        {
            Dictionary<string, string> param = new Dictionary<string, string>(1);
            param.Add("Percent", PercentOfMap.ToString());
            PhenomenMetadata ret = new PhenomenMetadata("MineralsPhenomen", _place, this.GetType().Name, param);
            return ret;
        }

        public bool isIn(Point point)
        {
            if (point == null)
            {
                throw new ArgumentNullException(nameof(point));
            }

            List<Point> points = new List<Point>(1);
            points.Add(point);

            return _place.Intersect(new Place(points)).Points.Count == 1;
        }

        public void Update(WorldMetadata worldMetadata)
        {
            
        }

        public MineralsPhenomen(MapSize mapSize)
        {
            _mapSize = mapSize ?? throw new ArgumentNullException(nameof(mapSize));
            List<Point> points = new List<Point>(2);
            points.Add(new Point(0, mapSize.Height *(PercentOfMap/100)));
            points.Add(new Point(mapSize.Width, mapSize.Height));
            _place = new Place(points, PlaceType.Rectangle);
        }
    }
}
