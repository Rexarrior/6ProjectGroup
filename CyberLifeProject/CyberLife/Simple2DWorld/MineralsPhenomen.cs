﻿using System;
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



        /// <summary>
        /// Возвращает экземпляр  класса Place, представляющий пространство,
        /// на  которое воздействует этот феномен
        /// </summary>
        public Place GetItPlace()
        {
            return _place;
        }



        /// <summary>
        /// Получает метаданные этого природного явления
        /// </summary>
        /// <returns>Метаданные</returns>
        public PhenomenMetadata GetMetadata()
        {
            Dictionary<string, string> param = new Dictionary<string, string>(1);
            param.Add("Percent", PercentOfMap.ToString());
            PhenomenMetadata ret = new PhenomenMetadata("MineralsPhenomen", _place, this.GetType().Name, param);
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
                throw new ArgumentNullException(nameof(point));
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
            if (mapSize == null)
                throw new ArgumentNullException(nameof(mapSize));
            List<Point> points = new List<Point>(2);
            points.Add(new Point(0, mapSize.Height *(PercentOfMap/100)));
            points.Add(new Point(mapSize.Width, mapSize.Height));
            _place = new Place(points, PlaceType.Rectangle);
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
