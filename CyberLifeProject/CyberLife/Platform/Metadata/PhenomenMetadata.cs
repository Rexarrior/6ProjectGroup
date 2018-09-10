using System;
using System.Collections.Generic;
using System.Dynamic;
using Google.Protobuf.Collections;
using NLog;
using CyberLife.Platform.Logging.LogMessages;

namespace CyberLife
{
    public class PhenomenMetadata : Dictionary<string, string>
    {
        Logger log = LogManager.GetCurrentClassLogger();

        #region fields

        #endregion


        #region properties

        /// <summary>
        /// Название природного явления
        /// </summary>
        public string Name { get; set; }



        /// <summary>
        /// Пространство, занимаемое природным явлением
        /// </summary>
        public Place Place { get; set; }


        /// <summary>
        /// Строковое представление имени класса. Может быть получено, как phenomen.GetType().Name
        /// </summary>
        public string PhenomenTypeName { get; set; }

        #endregion


        #region methods

        /// <summary>
        /// Проверяет, содержится ли параметр с указанным именем в метаданных
        /// </summary>
        /// <param name="parameterName"> Имя параметра для проверки</param>
        /// <returns>Содержит?</returns>
        public bool ContainsParameter(string parameterName)
        {
            log.Trace("Вызван PhenomenMetadata.ContainsParameter, входной параметр " + parameterName);
            return this.ContainsKey(parameterName);
        }



        /// <summary>
        /// Получает прототип метаданных.
        /// </summary>
        /// <returns>Прототип GoogleProtobuf</returns>
        public Protobuff.Metadata.PhenomenMetadata GetProtoMetadata()
        {
            log.Trace(LogMetadataMessages.ProtobuffFromMetadata, "PhenomenMetadata");
            Protobuff.Metadata.PhenomenMetadata ret = new Protobuff.Metadata.PhenomenMetadata();
            ret.Place = Place.GetProtoPlace();
            ret.Name = Name;
            ret.TypeName = PhenomenTypeName;
            log.Info("Имя экземпляра {0}, тип {1}, кол-во дополнительных параметров {2}", Name, PhenomenTypeName, this.Count);
            foreach (var pair in this)
            {
                ret.Parameters.Add(pair.Key, pair.Value);
            }
            log.Trace(LogMetadataMessages.OkProtobuffFromMetadata);
            return ret;
        }

        #endregion


        #region constructors

        /// <summary>
        /// Инициализирует метаданные природного явления из 
        /// его названия, занимаемого им пространства и списка его параметров
        /// </summary>
        /// <param name="phenomenName">Название природного явления</param>
        /// <param name="place">Пространство, занимаемое природным явлением</param>
        /// <param name="parameters">Дополнительные параметры природного явления</param>
        /// <param name="phenomenTypeName">phenomen.GetType().Name для природного явления</param>
        /// 
        public PhenomenMetadata(string phenomenName, Place place, string phenomenTypeName, Dictionary<string, string> parameters = null)
        {
            log.Trace(LogMetadataMessages.Constructor, "PhenomenMetadata");
            if (phenomenName == "")
            {
                ArgumentException ex = new ArgumentException("phenomenName shouldn\'t be empty", nameof(phenomenName));
                log.Error(LogMetadataMessages.NullArgument, "string phenomenName", ex);
                throw ex;
            }
            if (phenomenTypeName == "")
            {
               ArgumentException ex = new ArgumentException("Phenomen type name should be a valid type name.", nameof(phenomenTypeName));
                log.Error(LogMetadataMessages.AddingNewListElement, "string phenomenTypeName", ex);
                throw ex;
            }
            if (parameters != null)
            {
                foreach(var pair in parameters)
                {
                    this.Add(pair.Key, pair.Value);
                }
                log.Info(this.Count + " дополнительных параметров");
            }
                

            PhenomenTypeName = phenomenTypeName;
            Name = phenomenName;
            if (place == null)
            {
                ArgumentNullException ex =new ArgumentNullException(nameof(place));
                log.Error(LogMetadataMessages.NullArgument, "LifeFormPlace", ex);
                throw ex;
            }
            Place = place;
            log.Trace(LogMetadataMessages.OkConstructor, "PhenomenMetadata");
        }


        /// <summary>
        /// Инициализирует метаданные природного явления из прототипа
        /// </summary>
        /// <param name="protoMetadata">Прототип GoogleProtobuf</param>
        public PhenomenMetadata(Protobuff.Metadata.PhenomenMetadata protoMetadata)
        {
            log.Trace(LogMetadataMessages.MetadataFromProtobuff, "PhenomenMetadata");
            if (protoMetadata == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(protoMetadata));
                log.Error(LogMetadataMessages.NullArgument, "Protobuff.Metadata.PhenomenMetadata", ex);
                throw ex;
            }
            Name = protoMetadata.Name;
            Place = new Place(protoMetadata.Place);
            PhenomenTypeName = protoMetadata.TypeName;
            Dictionary<string, string> parameters = new Dictionary<string, string>(protoMetadata.Parameters);
            foreach (var pair in parameters)
            {
                this.Add(pair.Key, pair.Value);
            }
            log.Info("Имя экземпляра {0}, тип {1}, кол-во дополнительных параметров {2}", Name, PhenomenTypeName, this.Count);
            log.Trace(LogMetadataMessages.OkMetadataFromProtobuff);
        }

        #endregion
    }
}