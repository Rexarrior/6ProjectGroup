using System;
using System.Collections.Generic;
using System.Dynamic;
using Google.Protobuf.Collections;

namespace CyberLife
{
    public class PhenomenMetadata
    {
        private Dictionary<string, string> _parameters;


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



        /// <summary>
        /// Параметр природного явлени
        /// </summary>
        /// <param name="index">Строка-ключ параметра</param>
        /// <returns></returns>
        public  string this[string index]
        {
            get { return _parameters[index]; }

        }



        /// <summary>
        /// Получает прототип метаданных.
        /// </summary>
        /// <returns>Прототип GoogleProtobuf</returns>
        public Protobuff.Metadata.PhenomenMetadata GetProtoMetadata()
        {
            Protobuff.Metadata.PhenomenMetadata ret = new Protobuff.Metadata.PhenomenMetadata();
            ret.Place = Place.GetProtoPlace();
            ret.Name = Name;
            ret.TypeName = PhenomenTypeName;
            foreach (var pair in _parameters)
            {
                ret.Parameters.Add(pair.Key, pair.Value);
            }
            
            return ret;
        }









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
            if (phenomenName == "")
                throw new ArgumentException("phenomenName shouldn\'t be empty", nameof(phenomenName));

            if (phenomenTypeName == "")
                throw  new ArgumentException("Phenomen type name should be a valid type name.", nameof(phenomenTypeName));

            if (parameters != null)
            {
                _parameters = parameters;
            }
                

            PhenomenTypeName = phenomenTypeName;
            Name = phenomenName;
            Place = place ?? throw new ArgumentNullException(nameof(place));
        }



      






        /// <summary>
        /// Инициализирует метаданные природного явления из прототипа
        /// </summary>
        /// <param name="protoMetadata">Прототип GoogleProtobuf</param>
        public PhenomenMetadata(Protobuff.Metadata.PhenomenMetadata protoMetadata)
        {
            if (protoMetadata == null)
                throw new ArgumentNullException(nameof(protoMetadata));

            Name = protoMetadata.Name;
            Place = new Place(protoMetadata.Place);
            PhenomenTypeName = protoMetadata.TypeName;
            _parameters = new Dictionary<string, string>(protoMetadata.Parameters);
        }

    }
}