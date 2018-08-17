using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;

namespace PhoneBook
{
    class PhoneBook
    {
        private readonly List<Person> _persons;
        private readonly HashSet<RecordType> _recordTypes;


        public event EventHandler<Person> PersonAdded;



        public static List<RecordType> BasicTypes = new List<RecordType>(new RecordType[4]
        {
            new PhoneNumberRecord(), 
            new EmailRecord(), 
            new DiscordTagRecord(), 
            new NoTypeRecord()
        });


        public PhoneBook( IEnumerable<RecordType> recordTypes = null, IEnumerable<Person> persons= null)
        {
            _persons = persons == null ? new List<Person>() : new List<Person>(persons);

            _recordTypes = recordTypes == null ?  new HashSet<RecordType>() : new HashSet<RecordType>(recordTypes);
        }



        public PhoneBook(ProtoPhoneBook protoPhoneBook) :
            this(protoPhoneBook.Types_.Select(x => new RecordType(x)),
                protoPhoneBook.Persons.Select(x => new Person(x)))
        {

        }




        internal List<Person> Persons { get => _persons;}
        internal HashSet<RecordType> RecordTypes { get => _recordTypes; }





        public void AddPerson(Person person)
        {
            _persons.Add(person);
            foreach (var record in person.Values)
            {
                _recordTypes.Add(record.Type);
            }
            OnPersonAdded(person);
        }



        public ProtoPhoneBook GetProtoPhoneBook()
        {
            ProtoPhoneBook ret = new ProtoPhoneBook();
            ret.Persons.AddRange(_persons.Select(x=>x.GetProtoPerson()));
            ret.Types_.AddRange(_recordTypes.Select(x=>x.GetProtoRecordType()));
            return ret;
        }



        public void SaveToFile(string fileName)
        {
            ProtoPhoneBook protoPhoneBook = GetProtoPhoneBook();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            protoPhoneBook.WriteTo(fs);
            fs.Close();

        }


        public static PhoneBook LoadFromFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            PhoneBook ret = new PhoneBook(ProtoPhoneBook.Parser.ParseFrom(fs));
            fs.Close();

            return ret;
        }


        protected virtual void OnPersonAdded(Person e)
        {
            PersonAdded?.Invoke(this, e);
        }
    }
}
