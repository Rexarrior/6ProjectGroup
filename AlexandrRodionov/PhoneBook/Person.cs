using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Person : ICloneable
    {
        public const int COMMENT_MAX_LENGTH = 2000;

        private Dictionary<string, Record> _records;

        private string _name;

        private string _comment;






        public Person(string name, string comment, IEnumerable<Record> records = null)
        {
            _records = new Dictionary<string, Record>();
            try
            {
                if (records != null)
                    foreach (var record in records)
                    {
                        _records.Add(record.Caption, record);
                    }

            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(ErrorsMessages.Person_new_records_not_correct,
                    nameof(records), e);
            }

            if (name == String.Empty)
                throw new ArgumentException(ErrorsMessages.Person_new_empty_name);

            if (comment.Length > COMMENT_MAX_LENGTH)
                throw new ArgumentException(String.Format(
                    ErrorsMessages.Person_new_comment_too_large_formating, COMMENT_MAX_LENGTH));

            _name = name;
            _comment = comment;
        }



        public Person(ProtoPerson protoPerson) :
            this(protoPerson.Name, protoPerson.Comment, protoPerson.Records.Select(x => new Record(x)))
        {

        }



        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Comment
        {
            get => _comment;
            set => _comment = value;
        }


        public Dictionary<string, Record>.ValueCollection Values => _records.Values;
        public Dictionary<string, Record>.KeyCollection Keys => _records.Keys;
        public Record this[string key] => _records[key];


        public void Add(string key, Record value) => _records.Add(key, value);
        public bool Remove(string key) => _records.Remove(key);


        public ProtoPerson GetProtoPerson()
        {
            ProtoPerson ret = new ProtoPerson();
            ret.Comment = _comment;
            ret.Name = _name;

            foreach (var record in _records.Values)
            {
                ret.Records.Add(record.GetProtoRecord());
            }
            
            return ret;
        }


        public override string ToString()
        {
            return _name;
            
        }




        public object Clone()
        {
            return  new Person(_name, _comment, _records.Values.Select(x=> (Record)x.Clone()));
        }
        



        public override bool Equals(object obj)
        {
            if (!(obj is Person))
                return false;

            Person anotherPerson = (Person) obj;
            if (anotherPerson.Name != _name ||
                anotherPerson.Comment != Comment ||
                !anotherPerson.Keys.Zip(Keys, (s, s1) => s == s1).All(x => x) ||
                !anotherPerson.Values.Zip(Values, (record, record1) => record.Equals(record1)).All(x => x)
            )
                return false;
            return true;

        }

        

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_name != null ? _name.GetHashCode() : 0) * 397) ^ (_comment != null ? _comment.GetHashCode() : 0);
            }
        }

    }

   
}
