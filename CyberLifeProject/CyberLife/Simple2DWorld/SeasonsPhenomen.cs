using System;
using System.Collections.Generic;
using NLog;

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
        Logger log = LogManager.GetCurrentClassLogger();

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
            log.Debug(LogMessages.GetPlace, "SeasonsPhenomen");
            return _place;
        }

        /// <summary>
        /// Получает метаданные этого природного явления.
        /// </summary>
        /// <returns></returns>
        public PhenomenMetadata GetMetadata()
        {
            log.Debug(LogMessages.GetMetadata, "SeasonsPhenomen");
            Dictionary<string, string> data = new Dictionary<string, string> { };
            data.Add("step", Convert.ToString(_step));
            data.Add("season", _season.ToString());
            PhenomenMetadata phenomenMetadata = new PhenomenMetadata("SeasonsPhenomen", _place, this.GetType().Name, data);
            log.Debug(LogMessages.EndMethod, "SeasonsPhenomen.GetMetadata");
            return phenomenMetadata;
        }

        /// <summary>
        /// проверяет, попадает ли точка под воздействие этого природного явления
        /// </summary>
        /// <param name="point">Точка пространства</param>
        /// <returns>Попадает?</returns>
        public bool isIn(Point point)
        {           
            return true;
        }



        /// <summary>
        /// Вызывает обновление этого природного явления на основании
        /// метаданных окружающей среды.
        /// </summary>
        /// <param name="worldMetadata">Метаданные окружающей среды.</param>
        public void Update( WorldMetadata worldMetadata)
        {
            log.Debug(LogMessages.PhenomenUpdate, "SeasonsPhenomen");
            _step = worldMetadata.Age;
            ChangeSeason();
        }

        /// <summary>
        /// Изменяет сезон в соответствии с ходом
        /// </summary>
        private void ChangeSeason()
        {
            byte season = (byte)((_step % 360) / 90);

            _season = (Season)Enum.GetValues(typeof(Season)).GetValue(season);
            log.Info(LogMessages.ChangeSeason, _season.ToString());
        }

        #endregion

        #region constructor

        public SeasonsPhenomen()
        {
            log.Debug(LogMessages.Constructor, "SeasonsPhenomen");
            _place = Place.Everything();
        }

        #endregion
    }
}