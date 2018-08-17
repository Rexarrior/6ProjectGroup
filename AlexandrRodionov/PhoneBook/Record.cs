using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Record: ICloneable
    {
        private readonly RecordType _type;
        private string _caption;
        private string _value;



        public Record(RecordType type, string caption, string value)
        {
            if (caption == string.Empty)
                throw  new ArgumentException(ErrorsMessages.Record_new_empty_caption);


            _type = type ?? throw new ArgumentNullException(nameof(type));

            _caption = caption;
            _value = value;
        }



        public Record(ProtoRecord protoRecord) :
            this(new RecordType(protoRecord.Type), protoRecord.Caption, protoRecord.Value)
        {

        }



        public string Caption { get => _caption; set => _caption = value; }
        public string Value { get => _value; set => _value = value; }
        internal RecordType Type => _type;




        public ProtoRecord GetProtoRecord()
        {
            ProtoRecord ret = new ProtoRecord();
            ret.Caption = _caption;
            ret.Type = _type.GetProtoRecordType();
            ret.Value = _value;
            return ret;
        }


        public override string ToString()
        {
            return _caption + ":" + Value;
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Record))
                return false;

            Record anotheRecord = (Record) obj;

            if (!_type.Equals(anotheRecord.Type) ||
                _caption != anotheRecord.Caption ||
                _value != anotheRecord.Value
            )
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_type != null ? _type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_caption != null ? _caption.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_value != null ? _value.GetHashCode() : 0);
                return hashCode;
            }
        }

        public object Clone()
        {
            return  new Record((RecordType)_type.Clone(), _caption, _value);
        }
    }
}
