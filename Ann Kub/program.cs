//Как не использовать возможности языка

//я не знаю на сколько коряво это работает и работает ли вообще....
//и за опечатки тапками не швыряйтесь

using System;
using System.Linq;
using System.Text;
using System.IO;

namespace phone
{
	class Program
	{
		
		
		
		/*=======================вспомогательная ерундень=======================*/
		
		
	//страница ошибки
		static void erpage(string str="Что-то пошло не так!"){
			Console.WriteLine(" Упс!" + str +  "\n" +
						      "Для продолжения нажмите любую клавишу . . . ");
			Console.ReadKey();
			Console.Clear();
		}
	//страница подтверждения
		static void surepage(string str="Вы уверены?"){
			Console.WriteLine(str + "\n" + "    1 - YES \t 2 - NO");
		}
	//"проверка на портач"
		static int proof_on_portach(string str){
			int chetchik=0;
			foreach(char simbol in str){
				if(simbol=='|'){
					++chetchik;
				}
			}
			if(chetchik>1){
				erpage("Вы напортачили, месье! Знак вертикальной черты запрещен. Контакт будет удален, сорян. :)");
				del(str);
				chetchik=1;
			}
			else if (chetchik<1){
				erpage("На землю напали инопланетяне...");
				del(str);
				chetchik=1;
			}
			else if (chetchik==1){
				chetchik=0;
			}
			return chetchik;	
		}

	
	
		/*=======================основная ерундень=======================*/
		
		
	//main
		public static void Main(string[] args)
		{ //Console.OutputEncoding=Encoding.UTF8; //раскомментить на случай неверной кодировки 
			fpage();
			menu();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		
		
		}
		
		
	//начальная страница с приветствием - first page
		static void fpage(){
			Console.WriteLine("\t\t Добро пожаловать! \n\n\n" + 
		                  	  " Вы запустили приложение 'Телефонный справочник'. \n" +
		                      " Приятного пользования! \n\n" + 
		                      " Для продолжения нажмите любую клавишу . . . ");
			Console.ReadKey(true);
		}
	//основное меню
		static void menu(){
			Console.Clear();
			Console.WriteLine(" Выберите пункт меню и \n нажмите соответствующую клавишу: \n\n" +
			                 " 1 - Открыть список контактов \n" +
			                 " 2 - Добавить новый контакт \n" +
			                 " 3 - Открыть существующий контакт \n\n" +
			                 "         Esc  Выход \n\n\n"
			                 );
			ConsoleKeyInfo k = Console.ReadKey(); 	//обработка нажатия клавиши 
			Console.Clear();
			switch (k.Key){
					case ConsoleKey.D1 : 	//Открыть список контактов
						playlist();
						break;
					case ConsoleKey.D2 : 	//Добавить новый контакт
						add_in_book();
						break;
					case ConsoleKey.D3 : 	//Открыть существующий контакт
						chose();
						break;
					case ConsoleKey.Escape : 	//Выход
						Console.Clear();
						surepage("Вы уверены, что хотите выйти?");
						ConsoleKeyInfo exit = Console.ReadKey();
						Console.Clear();
						switch (exit.Key){
							case ConsoleKey.D1 :
								Environment.Exit(0);
								break;
							case ConsoleKey.D2 :
								menu();
								break;
							default : 
								erpage();
								menu();
								break;
						}
						break;
					default :
						erpage();
						menu();
						break;
			}
	}
	//для вывода списка контактов
		static void playlist(){
			StreamReader reader = new StreamReader("1.txt"); 
   			Console.Clear();
   			if(reader.EndOfStream){ 	//если файл пуст
   				erpage("Ваш список контактов пуст!");
   			}
   			else {
   				Console.WriteLine(" 1Вернуться в меню 2Найти контакт 3Удалить все контакты \n\n");
   				Console.WriteLine(reader.ReadToEnd());	//выводим всё и вся
				ConsoleKeyInfo k = Console.ReadKey(); 	//обработка нажатия клавиши 
				Console.Clear();
				switch (k.Key){
					case ConsoleKey.D1 : 	//Вернуться в меню
						menu();
						break;
					case ConsoleKey.D2 : 	//Найти контакт
						chose();
						break;
					case ConsoleKey.D3 : 	//Удалить все контакты
						surepage("Вы уверены, что хотите удалить все контакты?");
						ConsoleKeyInfo del = Console.ReadKey();
						Console.Clear();
						switch (del.Key){
							case ConsoleKey.D1 :
								File.WriteAllText("1.txt", "");
								break;
							case ConsoleKey.D2 :
								menu();
								break;
							default : 
								erpage();
								menu();
								break;
						}
						break;
					default : 
						erpage();
						menu();
						break;
   				}
   			}
   			reader.Close();
	}
	//найти - открыть существующий контакт
		static void chose(){
			bool consist=false;
			Console.WriteLine("Введите имя или номер телефона контакта");
			foreach(string contact in File.ReadLines(@"1.txt")){
				if(contact.Contains(Console.ReadLine())){
					consist=true;				
				Console.WriteLine("1Вернуться в меню 2Редактировать контакт 3Удалить контакт\n");
				Console.WriteLine(contact);
				ConsoleKeyInfo k = Console.ReadKey(); 	//обработка нажатия клавиши 
				Console.Clear();
				switch (k.Key){
					case ConsoleKey.D1 : 	//Вернуться в меню
						menu();
						break;
					case ConsoleKey.D2 : 	//Редактировать контакт 
						if(proof_on_portach(contact)==0){
							redact(contact);
						}
						break;
					case ConsoleKey.D3 :	//Удалить контакт
						del(contact);
						break;	
					default :
						erpage();
						menu();
						break;
							
				}
				Console.ReadKey(true);
				break;
				}
			}
			if(!consist) {
				erpage();
				menu();
			} 
	}
	//добавить контакт
		static void add_in_book(){
			Console.WriteLine("Введите имя контакта: \n");
			File.AppendAllText("1.txt", Console.ReadLine());
			Console.WriteLine("Введите номер телефона контакта: \n");
			File.AppendAllText("1.txt", "  " + Console.ReadLine());
			Console.WriteLine("Добавте описание контакта: \n");
			File.AppendAllText("1.txt", " | " + Console.ReadLine() + Environment.NewLine);
			menu();
		}
	//редактировнть контакт
		static void redact(string str){
			Console.WriteLine("1Переименовать 2Изменить телефон 3Редактироваь описание 4Меню\n" + str);
			ConsoleKeyInfo chg = Console.ReadKey();
			try{
				switch (chg.Key){
					case ConsoleKey.D1 :
						Console.WriteLine("Введите старое имя контакта: \n"); //ибо мне лень искать где там имя, а где телефон :р
						str=Console.ReadLine();
						Console.WriteLine("Введите новое имя контакта: \n");
						File.WriteAllText("1.txt", File.ReadAllText("1.txt").Replace(str,Console.ReadLine()));
						break;
					case ConsoleKey.D2 :
						Console.WriteLine("Введите старый телефон контакта: \n"); //ибо мне лень искать где там имя, а где телефон :р
						str=Console.ReadLine();
						Console.WriteLine("Введите новый телефон контакта: \n");
						File.WriteAllText("1.txt", File.ReadAllText("1.txt").Replace(str,Console.ReadLine()));
						break;
					case ConsoleKey.D3 :
						str=str.Substring(str.IndexOf('|'));
						Console.WriteLine("Введите новое описание контакта: \n"); 
						File.WriteAllText("1.txt", File.ReadAllText("1.txt").Replace(str,Console.ReadLine()));
						break;
					case ConsoleKey.D4 :
							menu();	
							break;
					default : 
						erpage();
						menu();
						break;
							}
				menu();
			}
			catch(Exception){
				erpage();
				menu();
			}
		} 
	//удаление контакта
		static void del(string str){
			File.WriteAllText("1.txt", File.ReadAllText("1.txt").Replace(str, ""));
			menu();
		}
}
}
