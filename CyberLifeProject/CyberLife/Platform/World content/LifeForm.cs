using System;
using System.Collections.Generic;
using System.Linq;
namespace CyberLife
{
    public class LifeForm
    {
        #region fields

        private Point _lifeFormPoint;

        #endregion


        #region properties

        /// <summary>
        /// Пространство, которое занимает эта форма жизни
        /// </summary>
        public Point LifeFormPoint { get => _lifeFormPoint; set => _lifeFormPoint = value; }

        #endregion


        #region methods

        #endregion


        #region constructors   

        /// <summary>
        /// Инициализирует экземпляр формы жизни 
        /// из занимаемого ей пространства и состояний, которыми она обладает. 
        /// </summary>
        /// <param name="place">Пространство, которое будет занимать эта форма жизни</param>
        /// <param name="states">Состояния этой формы жизни</param>
        public LifeForm(Point point)
        {
            _lifeFormPoint = point;
        }

        #endregion
    }
}