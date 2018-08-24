using System;
using System.Collections.Generic;

namespace CyberLife
{
    public class StateMetadata
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public Dictionary<string, string> Params { get; set; }      



        /// <summary>
        /// Получает прототип этих метаданных
        /// </summary>
        /// <returns>прототип googleProtobuff</returns>
        public Protobuff.Metadata.StateMetadata GetProtoMetadata()
        {

            Protobuff.Metadata.StateMetadata ret = new Protobuff.Metadata.StateMetadata();
            ret.Value = Value;
            ret.Name = Name;
            foreach (var pair in Params)
            {
                ret.Params.Add(pair.Key, pair.Value);
            }
            return ret;
        }







        /// <summary>
        /// Инициализирует класс метаданные состояния из 
        /// имени состояния и его значения
        ///  
        /// </summary>
        /// <param name="stateName">Имя состояния</param>
        /// <param name="value">Значение состояния</param>
        /// <param name="Params">Коллекция дополнительных параметров</param>
        public StateMetadata(string stateName, double value,Dictionary<string,string> Params)
        {
            if (stateName == "")
                throw new ArgumentException("stateNmae shouldn't be empty", nameof(stateName));
            if (double.IsNaN(value))
                throw new ArgumentException("value shouldn't be NaN", nameof(value));
            this.Params = Params ?? throw new ArgumentNullException(nameof(Params));
            Name = stateName;
            Value = value;            
        }

        

        /// <summary>
        /// Инициализирует метаданные состояния из их прототипа.
        /// </summary>
        /// <param name="protoMetadata">Прототип GoogleProtobuff</param>
        public StateMetadata(Protobuff.Metadata.StateMetadata protoMetadata)
        {
            if (protoMetadata == null)
                throw  new ArgumentNullException(nameof(protoMetadata));
            Name = protoMetadata.Name;
            Value = protoMetadata.Value;
            foreach(var pair in protoMetadata.Params)
            {
                Params.Add(pair.Key, pair.Value);
            }
            
        }

    }
}