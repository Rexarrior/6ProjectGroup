namespace sp
{
    using System;
    using System.Collections.Generic;
    class Phonebook
    {
        Int64 nomer;
        string adress;
        string name;
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return String.Format("Абонент по имени:{0},зарегистрирован за номером:{1},проживает по адресу:{2}", name, nomer, adress);
            // $"Абонент по имени:{name},зарегистрирован за номером:{nomer},проживает по адресу:{adress}" may be more usable. But it's just a matter of taste. R.

        }
        public Phonebook(Int64 n, string a, string na)
        {
            this.nomer = n;
            this.adress = a;
            this.name = na;
        }
        public bool Findname(Phonebook sp)
        {
            return sp.name == name; ;
        }
        public bool Findnumber(Phonebook sp)
        {
            return sp.nomer == nomer; ;
        }
        public bool Findadrees(Phonebook sp)
        {
            return sp.adress == adress;
        }
    }
    class EntryMainPoInt64
    {
        static void Main()
        {
            //Good the Console usage. I like it) 
            try 
            {

                string command;
                Int64 number;
                string name;
                string adress;
                List<Phonebook> mylist = new List<Phonebook>();
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("Введите количество абонентов:");
                Int64 n = Int64.Parse(Console.ReadLine());
                for (Int64 i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите имя абонента:");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите номер абонента:");
                    number = Int64.Parse(Console.ReadLine());           // Just one casual letter and user become a ninny. May be your users  deserve a second chanсe?)) R.
                    Console.WriteLine("Введите адрес абонента:");
                    adress = Console.ReadLine();
                    mylist.Add(new Phonebook(number, adress, name));
                    Console.ResetColor();
                    Console.Clear();
                }
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(@"1:Найти по номеру
2:Найти по адресу
3:Найти по имени");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("4:выход");
                    Console.ResetColor();
                    command = Console.ReadLine();
                    Console.Clear();
                    switch (command)
                    {
                        case "1":
                            Console.WriteLine("Введите номер абонента для поиска:");
                            Int64 nomer = Int64.Parse(Console.ReadLine());
                            Phonebook spp = new Phonebook(nomer, "", "");
                            Phonebook sp = mylist.Find(new Predicate<Phonebook>(spp.Findnumber));  // You can use just Find(spp.Findnumber). My Resharper say me that) I didn't know, chessslovo) 
                            if (sp != null)
                            {
                                Console.WriteLine(sp);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Абонент с таким номером не найден:");
                                Console.ReadLine();
                                Console.ResetColor();
                                Console.Clear();
                            }
                            break;
                        case "2":
                            Console.WriteLine("Введите адресс абонента для поиска:");
                            string adress1 = Console.ReadLine();
                            Phonebook spp1 = new Phonebook(0, adress1, "");
                            Phonebook sp1 = mylist.Find(new Predicate<Phonebook>(spp1.Findadrees));
                            if (sp1 != null)
                            {
                                Console.WriteLine(sp1);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nАбонент с таким адресом не найден:");
                                Console.ReadLine();
                                Console.ResetColor();
                                Console.Clear();

                            }
                            break;
                        case "3":
                            Console.WriteLine("Введите имя для поиска:");
                            string names = Console.ReadLine();
                            Phonebook sppp = new Phonebook(0, "", names);
                            mylist.FindAll(new Predicate<Phonebook>(sppp.Findname)).ForEach(delegate (Phonebook s) { Console.WriteLine(s); });
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вводите значения от 1 до 4:");
                            Console.ReadLine();
                            Console.ResetColor();
                            Console.Clear();

                            break;
                    }




                } while (command != "4");
            }
            catch
            {
                Console.WriteLine("Пользователь дурачек :D");
            }
        }
    }
}