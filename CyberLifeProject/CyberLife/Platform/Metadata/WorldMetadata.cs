using System;
using System.Collections.Generic;
using System.IO;
using NLog;
using CyberLife.Platform.Logging.LogMessages;

namespace CyberLife
{
    public class WorldMetadata : Dictionary<Int64, LifeFormMetadata>
    {
        protected Logger log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Метаданные окружающей среды этого мира
        /// </summary>
        public EnvironmentMetadata EnvironmentMetadata;

        /// <summary>
        /// Название мира
        /// </summary>
        public string Name;

        /// <summary>
        /// Возраст мира. В ходах. 
        /// </summary>
        public int Age;



        /// <summary>
        /// Получает прототип метаданных мира. 
        /// </summary>
        /// <returns>Прототип googleProtobuf</returns>
        public Protobuff.Metadata.WorldMetadata GetProtoMetadata()
        {
            log.Trace(LogMetadataMessages.ProtobuffFromMetadata, "WorldMetadata");
            Protobuff.Metadata.WorldMetadata ret = new Protobuff.Metadata.WorldMetadata();

            ret.Age = Age;
            ret.EnvironmentMetadata = EnvironmentMetadata.GetProtoMetadata();
            ret.Name = Name;
            foreach (var pair in this)
            {
                ret.LifeFormMetadata.Add(pair.Key, pair.Value.GetProtoMetadata());
            }
            log.Info("Возраст {0}, Имя {1}, Кол-во метаданных форм жизни {2}", Age, Name, this.Count);
            log.Trace(LogMetadataMessages.OkProtobuffFromMetadata);
            return ret;
        }

        


       



        /// <summary>
        /// Инициализирует метаданные мира из метаданных его компонент. 
        /// </summary>
        /// <param name="environmentMetadata">Метаданные окружающей среды</param>
        /// <param name="lifeFormsMetadata">Метаданные форм жизни</param>
        /// <param name="name">Название мира</param>
        /// <param name="age">Возраст мира в ходах</param>
        public WorldMetadata(EnvironmentMetadata environmentMetadata, Dictionary<long, LifeFormMetadata> lifeFormsMetadata, string name, int age)
        {
            log.Trace(LogMetadataMessages.Constructor, "WorldMetadata");
            if (name == ""||name ==null)
            {
                ArgumentException ex = new ArgumentException("name shouldn't be empty.", nameof(name));
                log.Error(LogMetadataMessages.NullArgument, "string name", ex);
                throw ex;
            }

            if (age < 0)
            {
                ArgumentException ex = new ArgumentException("age should be positive.", nameof(age));
                log.Error("Переданная переменная age меньше нуля");
                throw ex;
            }
            if (environmentMetadata == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(environmentMetadata));
                log.Error(LogMetadataMessages.NullArgument, "EnvironmentMetadata environmentMetadata", ex);
            }
            EnvironmentMetadata = environmentMetadata;
            if(lifeFormsMetadata ==null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(lifeFormsMetadata));
                log.Error(LogMetadataMessages.NullArgument, "Dictionary<long, LifeFormMetadata> lifeFormsMetadata", ex);
                throw ex;
            }
            foreach (var pair in lifeFormsMetadata)
            {
                this.Add(pair.Key, pair.Value);
            }
            Name = name;
            Age = age;
            log.Info("Возраст {0}, Имя {1}, Кол-во метаданных форм жизни {2}", Age, Name, this.Count);
            log.Trace(LogMetadataMessages.OkConstructor, "WorldMetadata");
        }



        /// <summary>
        /// Инициализирует метаданные мира из их прототипа
        /// </summary>
        /// <param name="protoMetadata">прототип googleProtobuff</param>
        public WorldMetadata(Protobuff.Metadata.WorldMetadata protoMetadata)
        {
            log.Trace(LogMetadataMessages.MetadataFromProtobuff, "WorldMetadata");
            if (protoMetadata == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(protoMetadata));
                log.Error(LogMetadataMessages.NullArgument, "Protobuff.Metadata.WorldMetadata protoMetadata");
            }
            Name = protoMetadata.Name;
            Age = protoMetadata.Age;
            EnvironmentMetadata = new EnvironmentMetadata(protoMetadata.EnvironmentMetadata);
            foreach (var pair in protoMetadata.LifeFormMetadata)
            {
                this.Add(pair.Key, new LifeFormMetadata(pair.Value));
            }
            log.Info("Возраст {0}, Имя {1}, Кол-во метаданных форм жизни {2}", Age, Name, this.Count);
            log.Trace(LogMetadataMessages.OkMetadataFromProtobuff);
        }
    }
}