using System;
using System.Collections.Generic;

namespace CyberLife.Platform.World_content
{
    public enum Season
    {
        Winter = 0,
        Spring = 1,
        Summer = 2,
        Autumn = 3
    }
    public class SeasonsPhenomen : IPhenomen
    {
        #region field

        private Season _season = 0;
        private int _step = 0;
        private Place _place;

        #endregion

        #region properties

        public int Step
        {
            get { return _step; }
        }
        public Season CurSeason
        {
            get { return _season; }
        }

        #endregion

        #region methods

        /// <summary>
        /// Получает эффекты воздействия этого феномена на точку пространства.
        /// Использует метаданные попавшей под воздействия формы жизни для корректировки 
        /// эффектов.
        /// </summary>
        /// <param name="point">Точка пространства</param>
        /// <param name="lifeFormMetadata">Метаданные формы жизни</param>
        /// <returns></returns>
        public List<StateMetadata> GetEffects(Point point, LifeFormMetadata lifeFormMetadata)
        {
            List<StateMetadata> stateMetadata = new List<StateMetadata> { };

            //Реализация GetEffects(Point point, LifeFormMetadata lifeFormMetadata)

            return stateMetadata;
        }

        /// <summary>
        /// Получает пространство, на котором действует это природное явление
        /// </summary>
        /// <returns></returns>
        public Place GetItPlace()
        {
            return _place;
        }

        /// <summary>
        /// Получает метаданные этого природного явления.
        /// </summary>
        /// <returns></returns>
        public PhenomenMetadata GetMetadata()
        {
            Dictionary<string, string> data = new Dictionary<string, string> { };
            data.Add("step", Convert.ToString(_step));
            data.Add("season", _season.ToString());
            PhenomenMetadata phenomenMetadata = new PhenomenMetadata("SeasonsPhenomen", _place, this.GetType().Name, data);
            return phenomenMetadata;
        }

        /// <summary>
        /// проверяет, попадает ли точка под воздействие этого природного явления
        /// </summary>
        /// <param name="point">Точка пространства</param>
        /// <returns>Попадает?</returns>
        public bool isIn(Point point)
        {

            if (_place.PlaceType == PlaceType.Array && _place.Points.Contains(point))
                return true;
            if (_place.PlaceType == PlaceType.Rectangle && _place.Points[1].X >= point.X && _place.Points[1].Y >= point.Y)
                return true;
            return false;
        }

        /// <summary>
        /// Увеличивает переменную количества ходов на 1
        /// </summary>

        /*
        public void NextStep()
        {
            if (_step == 360)
                _step = 0;
            ChangeSeason();
            _step += 1;
        }
        */

        /// <summary>
        /// Вызывает обновление этого природного явления на основании
        /// метаданных окружающей среды.
        /// </summary>
        /// <param name="worldMetadata">Метаданные окружающей среды.</param>
        public void Update( WorldMetadata worldMetadata)
        {
            if (worldMetadata.Age >= 360)
                worldMetadata.Age = 0;
            _step = worldMetadata.Age;
            ChangeSeason();
        }

        /// <summary>
        /// Изменяет сезон в соответствии с ходом
        /// </summary>
        private void ChangeSeason()
        {
            byte season = (byte)(_step / 90);
            _season = (Season)Enum.GetValues(typeof(Season)).GetValue(season);
        }

        #endregion

        #region constructor

        public SeasonsPhenomen()
        {
            _place = Place.Everything();
        }

        #endregion
    }
}