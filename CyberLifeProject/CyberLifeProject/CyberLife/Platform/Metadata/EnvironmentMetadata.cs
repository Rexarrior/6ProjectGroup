using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using CyberLife.Platform.Logging.LogMessages;

namespace CyberLife
{
    public class EnvironmentMetadata: Dictionary<string, PhenomenMetadata>
    {
        Logger log = LogManager.GetCurrentClassLogger();

        #region fields

        /// <summary>
        /// Размер поля окружающей среды
        /// </summary>
        public MapSize Size;

        #endregion


        #region properties

        #endregion


        #region methods

        /// <summary>
        /// Получает прототип метаданных этой окружающей среды
        /// </summary>
        /// <returns></returns>
        public Protobuff.Metadata.EnvironmentMetadata GetProtoMetadata()
        {
            log.Trace(LogMetadataMessages.ProtobuffFromMetadata, "EnvironmentMetadata");
            Protobuff.Metadata.EnvironmentMetadata ret = new Protobuff.Metadata.EnvironmentMetadata();
            ret.MapSize = Size.GetProtoMapSize();
            foreach (var phenomen in this.Values)
            {
                ret.PhenomenaMetadata.Add(phenomen.GetProtoMetadata());
            }
            log.Trace(LogMetadataMessages.OkProtobuffFromMetadata);
            return ret;
        }

        #endregion


        #region constructors

        /// <inheritdoc />
        /// <summary>
        /// Инициализирует метаданные окружающей среды из размера поля и 
        /// метаданных природных явлений, действующих в окружающей среде
        /// </summary>
        /// <param name="size">Размер поля</param>
        /// <param name="phenomenaMetadata">Метаданные природных явлений</param>
        public EnvironmentMetadata(MapSize size,  List<PhenomenMetadata> phenomenaMetadata)
        {
            log.Trace(LogMetadataMessages.Constructor, "EnvironmentMetadata");
            if (size == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(size));
                log.Error(LogMetadataMessages.NullArgument, "MapSize", ex);
                throw ex;
            }
            Size = size;
            if (phenomenaMetadata == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(phenomenaMetadata));
                log.Error(LogMetadataMessages.NullArgument, "List<PhenomenMetadata>", ex);
                throw ex;
            }
            foreach (var phenomen in phenomenaMetadata)
            {
                log.Info(LogMetadataMessages.AddingNewListElement, phenomen.Name, phenomen);
                this.Add(phenomen.Name, phenomen);
            }
            log.Trace(LogMetadataMessages.OkConstructor, "EnvironmentMetadata");
        }


        /// <inheritdoc />
        /// <summary>
        /// Инициализирует метаданные окружающей среды из их прототипа
        /// </summary>
        /// <param name="protoMetadata"></param>
        public EnvironmentMetadata(Protobuff.Metadata.EnvironmentMetadata protoMetadata)
        {
            log.Trace(LogMetadataMessages.MetadataFromProtobuff, "EnvironmentMetadata");
            Size = new MapSize(protoMetadata.MapSize);
            foreach (var phenomenMetadata in protoMetadata.PhenomenaMetadata)
            {
                this.Add(phenomenMetadata.Name, new PhenomenMetadata(phenomenMetadata));
            }
            log.Trace(LogMetadataMessages.OkMetadataFromProtobuff);
        }

        #endregion
    }
}