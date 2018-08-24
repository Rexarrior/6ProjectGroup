using System;

namespace CyberLife.Platform.World_content
{
    public enum Season
    {
        Winter = 0,
        Spring = 1,
        Summer = 2,
        Autumn = 3
    }
    public class SeasonsPhenomen
    {
       private Season _season = 0;
       private int _step = 0;
       public int Step
       {
            get { return _step; }
       }
        public Season CurSeason
        {
            get { return _season; }
        }
        /// <summary>
        /// Увеличивает переменную количества ходов на 1
        /// </summary>
        public void NextStep()
        {
            if (_step == 360)
                _step = 0;
            ChangeSeason();
            _step += 1;
        }
        private void ChangeSeason()
        {
            byte season =(byte)(_step / 90);
            _season = (Season)Enum.GetValues(typeof(Season)).GetValue(season);
        }
    }
}
