using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PhoneNumb
    {
        public String numb { get; set; }
        public String name { get; set; }
        public String discription { get; set; }
    }
    class PhoneBook
    {
        private List<PhoneNumb> phones = new List<PhoneNumb>();

        public void AddPhone()
        {
            Console.WriteLine("Write num");
            string a = Console.ReadLine();
            if(a.length > 11) {
                Console.WriteLine("Phone number length <= 11");
                Console.WriteLine("Write Num");
                a = Console.ReadLine();
            }
            Console.WriteLine("Write Name");
            string b = Console.ReadLine();
            Console.WriteLine("Write Discription");
            string c = Console.ReadLine();
            phones.Add(new PhoneNumb() { numb = a, name = b, discription = c});
        }
        public void Search()
        {
            if (phones.Count() > 0 ) {
                Console.WriteLine("Write Name");
                String n = Console.ReadLine();

                PhoneNumb Found = phones.Find(item => item.name == n);
                Console.WriteLine("Name:{0},Phone:{1},Discription:{2}", Found.name, Found.numb, Found.discription);
            }
            else
            {
                Console.WriteLine("No phones");
            }
        }
        public void DeleteNumb()
        {
            if (phones.Count() > 0)
            {
                Console.WriteLine("Write Name");
                String numname = Console.ReadLine();
                PhoneNumb Found = phones.Find(item => item.name == numname);
                phones.Remove(Found);
            }
            else
            {
                Console.WriteLine("No phones");
            }
        }
        public void ViewDiscr()
        {
            if (phones.Count() > 0)
            {
                Console.WriteLine("Write Name");
                String n = Console.ReadLine();
                PhoneNumb Found = phones.Find(item => item.name == n);
                Console.WriteLine("Discription:{0}", Found.discription);
            }
            else
            {
                Console.WriteLine("No phones");
            }
        }
        public void Redact()
        {
            if (phones.Count() > 0)
            {
                Console.WriteLine("Write name");
                String n = Console.ReadLine();
                PhoneNumb Found = phones.Find(item => item.name == n);
                Console.WriteLine("Write new name");
                n = Console.ReadLine();
                Console.WriteLine("Write new phone number");
                String a = Console.ReadLine();
                Console.WriteLine("Write new discription");
                String b = Console.ReadLine();
                phones.Remove(Found);
                phones.Add(new PhoneNumb() { numb = Console.ReadLine(), name = n, discription = Console.ReadLine() });
            }
            else
            {
                Console.WriteLine("No phones");
            }
        }
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook book = new PhoneBook();
            Console.WriteLine("To add phone to phone book write add");
            Console.WriteLine("To delete numb write del");
            Console.WriteLine("To search numb write srch");
            Console.WriteLine("To view discription write discr");
            Console.WriteLine("To redact phone write redct");
            while (true)
            {
                String a = Console.ReadLine();
                if (a == "add")
                {
                    book.AddPhone();
                }else if (a == "del")
                {
                    book.DeleteNumb();
                }else if (a == "srch")
                {
                    book.Search();
                }else if (a == "discr")
                {
                    book.ViewDiscr();
                }else if (a == "redct")
                {
                    book.Redact();
                }else if (a == "exit")
                {
                    break;
                }
            }
        }
    }
}
