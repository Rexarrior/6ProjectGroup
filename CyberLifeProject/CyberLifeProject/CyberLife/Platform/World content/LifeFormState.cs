using System;
using System.Collections.Generic;
using System.Data;

namespace CyberLife
{
    public class LifeFormState
    {
        #region fields

        private string _name;
        private double _value;
        private Dictionary<string, string> _params;

        #endregion


        #region properties

        /// <summary>
        /// Название состояния формы жизни
        /// </summary>
        public string Name { get => _name; }
        

        /// <summary>
        /// Числовое значение состояния формы жизни. 
        /// </summary>
        public double Value { get => _value; set => _value = value; }


        /// <summary>
        /// Дополнительные параметры формы жихни. 
        /// </summary>
        public Dictionary<string, string> Params { get; set; }

        #endregion


        #region methods

        /// <summary>
        /// Формирует метаданные этого состояния формы жизни
        /// </summary>
        /// <returns>Метаданные состояния</returns>
        public virtual StateMetadata GetMetadata()
        {
            return new StateMetadata(_name, _value,_params);
        }


        
        public virtual void Update(WorldMetadata lifeFormMetadata, StateMetadata stateMetadata)
        {
            if (stateMetadata.Name != _name)
                throw new ArgumentException("metadata of another state given.", nameof(stateMetadata));

            _value += stateMetadata.Value; 
            
        }

        #endregion


        #region constructors

        /// <summary>
        /// Инициализирует состояние формы жизни
        /// по его названию и значению
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public LifeFormState(string name, double value, Dictionary<string, string> Params)
        {
            if (name == "")
                throw new ArgumentException("name shouldn't be empty", nameof(name));
            if (double.IsNaN(value))
                throw new ArgumentException("value shouldn't be NaN", nameof(value));
            _params = Params ?? new Dictionary<string, string>();
            _name = name;
            _value = value;
        }


        /// <summary>
        /// Инициализирует состояние формы жизни по
        /// его метаданным
        /// </summary>
        /// <param name="metadata"></param>
        public LifeFormState(StateMetadata metadata)
        {
            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            _name = metadata.Name;
            _value = metadata.Value;
            _params = metadata;
        }

        #endregion
    }
}