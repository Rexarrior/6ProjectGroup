using System;
using System.Text.RegularExpressions;

namespace PhoneBook
{
    public class RecordType: ICloneable
    {
        private readonly string _typeName;

        private readonly Regex _filter;



        public RecordType(string typeName, string regexFilter)
        {
            if (typeName == string.Empty)
                throw  new ArgumentException(ErrorsMessages.RecordType_new_empty_type_name,
                    nameof(typeName));

            if (regexFilter == string.Empty)
                throw new ArgumentException(ErrorsMessages.RecordType_new_empty_regex_filter,
                    nameof(regexFilter));



            _typeName = typeName;
            _filter = new Regex(regexFilter);
        }




        public RecordType(ProtoRecordType protoRecordType):
            this(protoRecordType.TypeName, protoRecordType.RegexFilter)
        {
            
        }


        public string TypeName { get => _typeName;  }

        public Regex Filter { get => _filter; }





        public bool Verify(string stringForVerification)
        {
            return _filter.IsMatch(stringForVerification);
        }




        public ProtoRecordType GetProtoRecordType()
        {
            ProtoRecordType ret = new ProtoRecordType();
            ret.TypeName = _typeName;
            ret.RegexFilter = _filter.ToString();
            return ret;
        }


        public override string ToString()
        {
            return _typeName;
        }


        public override bool Equals(object obj)
        {
            if (!(obj is RecordType))
                return false;

            RecordType anotherRecordType = (RecordType) obj;

            if (anotherRecordType._typeName != _typeName ||
                anotherRecordType.Filter.ToString() != _filter.ToString())
                return false;



            return true;

        }


        public override int GetHashCode()
        {
            unchecked
            {
                return ((_typeName != null ? _typeName.GetHashCode() : 0) * 397) ^ (_filter != null ? _filter.GetHashCode() : 0);
            }
        }

        public object Clone()
        {
            return  new RecordType(_typeName, _filter.ToString());
        }
    }
}