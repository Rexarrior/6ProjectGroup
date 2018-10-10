using System;
using System.Collections.Generic;
using NLog;
using CyberLife.Platform.Logging.LogMessages;

namespace CyberLife
{
    public class StateMetadata : Dictionary<string, string>
    {
        Logger log = LogManager.GetCurrentClassLogger();

        #region fields

        #endregion


        #region properties

        public string Name { get; set; }
        public double Value { get; set; }

        #endregion


        #region methods

        /// <summary>
        /// Получает прототип этих метаданных
        /// </summary>
        /// <returns>прототип googleProtobuff</returns>
        public Protobuff.Metadata.StateMetadata GetProtoMetadata()
        {
            log.Trace(LogMetadataMessages.ProtobuffFromMetadata, "StateMetadata");
            Protobuff.Metadata.StateMetadata ret = new Protobuff.Metadata.StateMetadata();
            ret.Value = Value;
            ret.Name = Name;
            log.Info("Имя {0}, значение{1}, кол-во доп. параметров{2}", Name, Value.ToString(), this.Count);
            foreach (var pair in this)
            {
                ret.Params.Add(pair.Key, pair.Value);
            }
            log.Trace(LogMetadataMessages.OkProtobuffFromMetadata);
            return ret;
        }

        #endregion


        #region constructors

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
            log.Trace(LogMetadataMessages.Constructor, "StateMetadata");
            if (stateName == "" || stateName == null)
            {
                ArgumentException ex = new ArgumentException("stateNmae shouldn't be empty", nameof(stateName));
                log.Error(LogMetadataMessages.NullArgument, "string stateName", ex);
                throw ex;
            }
            if (double.IsNaN(value))
            {
                ArgumentException ex = new ArgumentException("value shouldn't be NaN", nameof(value));
                log.Error("Входной параметр double value не может быть NaN",ex);
                throw ex;
            }
            
            if (Params != null)
            {
                foreach (var pair in Params)
                {
                    this.Add(pair.Key, pair.Value);
                }
            }
            Name = stateName;
            Value = value;
            log.Info("Имя {0}, значение{1}, кол-во доп. параметров{2}", Name, Value.ToString(),this.Count);
            log.Trace(LogMetadataMessages.OkConstructor, "StateMetadata");
        }
      

        /// <summary>
        /// Инициализирует метаданные состояния из их прототипа.
        /// </summary>
        /// <param name="protoMetadata">Прототип GoogleProtobuff</param>
        public StateMetadata(Protobuff.Metadata.StateMetadata protoMetadata)
        {
            log.Trace(LogMetadataMessages.MetadataFromProtobuff, "StateMetadata");
            if (protoMetadata == null)
            {
              ArgumentNullException ex =  new ArgumentNullException(nameof(protoMetadata));
                log.Error(LogMetadataMessages.NullArgument, "Protobuff.Metadata.StateMetadata protoMetadata", ex);
                throw ex;
            }
            Name = protoMetadata.Name;
            Value = protoMetadata.Value;
            foreach(var pair in protoMetadata.Params)
            {
                this.Add(pair.Key, pair.Value);
            }
            log.Info("Имя {0}, значение{1}, кол-во доп. параметров{2}", Name, Value.ToString(), this.Count);
            log.Trace(LogMetadataMessages.OkMetadataFromProtobuff);
        }
        #endregion
    }
}