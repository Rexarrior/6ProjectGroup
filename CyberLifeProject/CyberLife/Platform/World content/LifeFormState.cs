using System;
using System.Collections.Generic;
namespace CyberLife
{
    public class LifeFormState
    {
        private string _name;
        private double _value;
        private Dictionary<string, string> _params;
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

        /// <summary>
        /// Формирует метаданные этого состояния формы жизни
        /// </summary>
        /// <returns>Метаданные состояния</returns>
        public virtual StateMetadata GetMetadata()
        {
            return new StateMetadata(_name, _value,_params);
        }



        /// <summary>
        /// Инициализирует состояние формы жизни
        /// по его названию и значению
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public LifeFormState(string name, double value, Dictionary<string, string> Params)
        {
            if (name == "")
                throw new ArgumentException("name shouldn't be empty", "name");
            if (double.IsNaN(value))
                throw new ArgumentException("value shouldn't be NaN", "value");
            _params = Params ?? throw new ArgumentNullException("empty dictionary parameters");
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
                throw new ArgumentNullException("metadata");


            _name = metadata.Name;
            _value = metadata.Value;
            _params = metadata.Params;
        }
    }
}