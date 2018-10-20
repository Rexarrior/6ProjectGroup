using System;
using System.Collections.Generic;
using CyberLife.Platform.Logging.LogMessages;
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
        /// Получает пространство, на котором действует это природное явление
        /// </summary>
        /// <returns></returns>
        public Place GetItPlace()
        {
            log.Debug(LogPhenomenMessages.GetPlace, "SeasonsPhenomen");
            return _place;
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
        public void Update(World worldMetadata)
        {
            log.Trace(LogPhenomenMessages.PhenomenUpdate, "SeasonsPhenomen");
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
            log.Info(LogPhenomenMessages.ChangeSeason, _season.ToString());
        }




        public static Season ParseSeason(string season)
        {
            switch (season)
            {
                case "Winter":
                {
                    return Season.Winter;
                }
                case "Autumn":
                {
                    return Season.Autumn;
                }
                case "Summer":
                {
                    return Season.Summer;

                }
                case "Spring":
                {
                    return Season.Spring;

                }
                default:
                {
                    throw new NotImplementedException();
                }
            }
        }

        public void GetEffects(LifeForm lifeForm)
        {
            // none
        }

        #endregion


        #region constructors

        public SeasonsPhenomen()
        {
            log.Trace(LogPhenomenMessages.Constructor, "SeasonsPhenomen");
            _place = Place.Everything();
            _place.PlaceType = PlaceType.Rectangle;
            log.Trace(LogPhenomenMessages.OkConstructor, "SeasonsPhenomen");
        }

        #endregion
    }
}