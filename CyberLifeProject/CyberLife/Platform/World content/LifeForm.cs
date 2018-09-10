using System;
using System.Collections.Generic;
using System.Linq;
namespace CyberLife
{
    public class LifeForm
    {
        #region fields

        private Int64 _id; 
        private Place _lifeFormPlace;
        private Dictionary<string, LifeFormState> _states;

        #endregion


        #region properties

        /// <summary>
        /// Состояния этой формы жизни 
        /// </summary>
        internal Dictionary<string, LifeFormState> States { get => _states; set => _states = value; }


        /// <summary>
        /// Пространство, которое занимает эта форма жизни
        /// </summary>
        public Place LifeFormPlace { get => _lifeFormPlace; set => _lifeFormPlace = value; }


        /// <summary>
        /// Уникальный идентификатор этой формы жизни
        /// </summary>
        public long Id { get => _id;  }

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
        public virtual void Update(WorldMetadata metadata, List<StateMetadata> phenomenEffects)
        {
            foreach (var effect in phenomenEffects)
            {
                if (_states.ContainsKey(effect.Name))
                {
                    _states[effect.Name].Update(metadata, effect);
                }
                else
                {

                    throw new NotImplementedException();
                }
            }
        }



        /// <summary>
        /// Формирует метаданные этой формы жизни
        /// </summary>
        /// <returns>Метаданные этой формы жизни</returns>
        public LifeFormMetadata GetMetadata()
        {
            return new LifeFormMetadata(_lifeFormPlace,_id, _states.Select(x => x.Value.GetMetadata()).ToList());
        }

        #endregion


        #region constructors

        /// <summary>
        /// Инициализирует экземпляр формы жизни 
        /// из занимаемого ей пространства и состояний, которыми она обладает. 
        /// </summary>
        /// <param name="place">Пространство, которое будет занимать эта форма жизни</param>
        /// <param name="states">Состояния этой формы жизни</param>
        public LifeForm(Place place, Dictionary<string, LifeFormState> states)
        {
            _lifeFormPlace = place ?? throw new ArgumentNullException(nameof(place));
            _states = states ?? throw new ArgumentNullException(nameof(states));
            _id = DateTime.UtcNow.Second;
        }


        /// <summary>
        /// Инициализирует экземпляр формы жизни из ее метаданных
        /// </summary>
        /// <param name="metadata">Метаданные формы жизни</param>
        public LifeForm(LifeFormMetadata metadata)
        {
            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));
            _id = metadata.Id;
            _lifeFormPlace = metadata.Place;
            States = new Dictionary<string, LifeFormState>();
            foreach (var stateMetadata in metadata.Values)
            {
                States.Add(stateMetadata.Name, new LifeFormState(stateMetadata));
            }

        }

        #endregion
    }
}