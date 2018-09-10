using System;
using System.Collections.Generic;
using NLog;
using CyberLife.Platform.Logging.LogMessages;

namespace CyberLife
{
    /// <summary>
    /// Метаданный формы жизни
    /// </summary>
    public class LifeFormMetadata: Dictionary<string, StateMetadata>
    {
        Logger log = LogManager.GetCurrentClassLogger();

        #region fields

        #endregion


        #region properties

        /// <summary>
        /// Пространство, занимаемое формой жизни
        /// </summary>
        public Place Place { get; set; }


        /// <summary>
        /// Уникальный (для мира) идентификатор формы жизни
        /// </summary>
        public long Id { get; set; }

        #endregion


        #region methods

        /// <summary>
        /// Получает прототип метаданных формы жизни
        /// </summary>
        /// <returns>Прототип googleProtobuf</returns>
        public Protobuff.Metadata.LifeFormMetadata GetProtoMetadata()
        {
            log.Trace(LogMetadataMessages.ProtobuffFromMetadata, "LifeFormMetadata");
            Protobuff.Metadata.LifeFormMetadata ret = new Protobuff.Metadata.LifeFormMetadata();

            ret.Id = Id;
            ret.Place = Place.GetProtoPlace();
            log.Info(this.Values.Count + " дополнительных параметров содержит данный экземпляр");
            foreach (var state in this.Values)
            {
                ret.StatesMetadata.Add(state.GetProtoMetadata());
            }

            log.Trace(LogMetadataMessages.OkProtobuffFromMetadata);
            return ret;

        }

        #endregion


        #region constructors

        /// <summary>
        /// Инициализирует метаданные формы жизни из 
        /// занимаемого ей пространства, ее уникального идентификатора и метаданных 
        /// состояний, которыми она обладает. 
        /// </summary>
        /// <param name="place">Пространство, занимаемое формой жизни</param>
        /// <param name="id">Уникальный для мира идентификатор формы жизни</param>
        /// <param name="statesMetadata">Метаданные состояний формы жизни</param>
        public LifeFormMetadata(Place place, Int64 id,  List<StateMetadata> statesMetadata)
        {
            log.Trace(LogMetadataMessages.Constructor, "LifeFormMetadata");
            if (place == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(place));
                log.Error(LogMetadataMessages.NullArgument, "LifeFormPlace");
            }
            Place = place;
            foreach (var state in statesMetadata ?? throw new ArgumentNullException(nameof(statesMetadata)))
            {
                this.Add(state.Name, state);
            }
            Id = id;
            log.Trace(LogMetadataMessages.OkConstructor, "LifeFormMetadata");
        }



        /// <summary>
        /// Инициализирует метаданные из их прототипа. 
        /// </summary>
        /// <param name="protoMetadata">Прототип googleProtobuff</param>
        public LifeFormMetadata(Protobuff.Metadata.LifeFormMetadata  protoMetadata)
        {
            log.Trace(LogMetadataMessages.MetadataFromProtobuff, "LifeFormMetadata");
            Place = new Place(protoMetadata.Place);
            Id = protoMetadata.Id;
            log.Info(protoMetadata.StatesMetadata.Count + " дополнительных параметров содержит данный экземпляр");
            foreach (var state in protoMetadata.StatesMetadata)
            {
                this.Add(state.Name, new StateMetadata(state));
            }
            log.Trace(LogMetadataMessages.OkMetadataFromProtobuff);
        }

        #endregion
    }
}