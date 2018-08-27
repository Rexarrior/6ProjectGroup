using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberLife
{
    public class EnvironmentMetadata: Dictionary<string, PhenomenMetadata>
    {
        /// <summary>
        /// Размер поля окружающей среды
        /// </summary>
        public MapSize Size;


        public int Age;

        /// <summary>
        /// Получает прототип метаданных этой окружающей среды
        /// </summary>
        /// <returns></returns>
        public Protobuff.Metadata.EnvironmentMetadata GetProtoMetadata()
        {
            Protobuff.Metadata.EnvironmentMetadata ret = new Protobuff.Metadata.EnvironmentMetadata();
            ret.MapSize = Size.GetProtoMapSize();
            ret.Age = Age;
            foreach (var phenomen in this.Values)
            {
                ret.PhenomenaMetadata.Add(phenomen.GetProtoMetadata());
            }

            return ret;
        }



        /// <summary>
        /// Инициализирует метаданные окружающей среды из размера поля и 
        /// метаданных природных явлений, действующих в окружающей среде
        /// </summary>
        /// <param name="size">Размер поля</param>
        /// <param name="phenomenaMetadata">Метаданные природных явлений</param>
        public EnvironmentMetadata(MapSize size, int age, List<PhenomenMetadata> phenomenaMetadata)
        {
            Size = size ?? throw new ArgumentNullException(nameof(size));
            Age = age >= 0? age : throw  new ArgumentException("Age should be less then 0", nameof(age));
            foreach (var phenomen in phenomenaMetadata ?? throw  new ArgumentNullException(nameof(phenomenaMetadata)))
            {
                this.Add(phenomen.Name, phenomen);
            }
        }



        /// <summary>
        /// Инициализирует метаданные окружающей среды из их прототипа
        /// </summary>
        /// <param name="protoMetadata"></param>
        public EnvironmentMetadata(Protobuff.Metadata.EnvironmentMetadata protoMetadata)
        {
            Size = new MapSize(protoMetadata.MapSize);
            Age = protoMetadata.Age; 
            foreach (var phenomenMetadata in protoMetadata.PhenomenaMetadata)
            {
                this.Add(phenomenMetadata.Name, new PhenomenMetadata(phenomenMetadata));
            }
        }
    }
}