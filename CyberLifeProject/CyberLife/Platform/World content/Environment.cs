using CyberLife.Simple2DWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberLife
{
    public class Environment
    {
        #region field
        private List<IPhenomen> _naturalPhenomena;
        private MapSize _size;
        #endregion


        #region properties
        internal List<IPhenomen> NaturalPhenomena { get => _naturalPhenomena; }

        internal MapSize Size { get => _size; }
        #endregion


        #region methods
      
        /// <summary>
        /// Вызывает операцию обновления для всех природных явлений, 
        /// принадлежащих этой окружающей среде. 
        /// </summary>
        public void Update(World world)
        {
            foreach (IPhenomen phenomen in _naturalPhenomena)
                phenomen.Update(world);
        }
        #endregion


        #region constructor

        /// <summary>
        /// Инициализирует окружающую среду из ее размера и списка природных явлений
        /// </summary>
        /// <param name="naturalPhenomena">Природные явления</param>
        /// <param name="size">Размер окружающей среды</param>
        public Environment(List<IPhenomen> naturalPhenomena, MapSize size)
        {
            _naturalPhenomena = naturalPhenomena;
            _size = size;
        }


        #endregion
    }
}
