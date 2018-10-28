using System;
using System.Collections.Generic;
using System.Linq;
namespace CyberLife
{
    public class LifeForm
    {
        #region fields

        private Int64 _id; 
        private Point _lifeFormPoint;

        #endregion


        #region properties

        /// <summary>
        /// Пространство, которое занимает эта форма жизни
        /// </summary>
        public Point LifeFormPoint { get => _lifeFormPoint; set => _lifeFormPoint = value; }


        /// <summary>
        /// Уникальный идентификатор этой формы жизни
        /// </summary>
        public long Id { get => _id; set => _id = value; }

        #endregion


        #region methods

        /// <summary>
        /// Обновляет состояния этой формы жизни на основании
        /// списка метаданных - результатов воздействия среды.
        /// Если содержащиеся в метаданных
        /// состояния не существуют для данной формы жизни, 
        /// они будут созданы. Иначе состояния формы жизни будут
        /// увеличены на соответствующие им значения состояний из метаданных. 
        /// </summary>
        /// <param name="phenomenEffects"></param>
        public virtual void Update(World world)
        {

        }

        #endregion


        #region constructors

       


        /// <summary>
        /// Инициализирует экземпляр формы жизни 
        /// из занимаемого ей пространства и состояний, которыми она обладает. 
        /// </summary>
        /// <param name="place">Пространство, которое будет занимать эта форма жизни</param>
        /// <param name="states">Состояния этой формы жизни</param>
        public LifeForm(Point point, long id)
        {
            _lifeFormPoint = point ?? throw new ArgumentNullException(nameof(point));
            _id = id;
        }

        #endregion
    }
}