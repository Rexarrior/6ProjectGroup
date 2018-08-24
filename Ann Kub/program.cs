//��� �� ������������ ����������� �����

//� �� ���� �� ������� ������ ��� �������� � �������� �� ������....
//� �� �������� ������� �� ����������

using System;
using System.Linq;
using System.Text;
using System.IO;

namespace phone
{
	class Program
	{
		
		
		
		/*=======================��������������� ��������=======================*/
		
		
	//�������� ������
		static void erpage(string str="���-�� ����� �� ���!"){
			Console.WriteLine(" ���!" + str +  "\n" +
						      "��� ����������� ������� ����� ������� . . . ");
			Console.ReadKey();
			Console.Clear();
		}
	//�������� �������������
		static void surepage(string str="�� �������?"){
			Console.WriteLine(str + "\n" + "    1 - YES \t 2 - NO");
		}
	//"�������� �� ������"
		static int proof_on_portach(string str){
			int chetchik=0;
			foreach(char simbol in str){
				if(simbol=='|'){
					++chetchik;
				}
			}
			if(chetchik>1){
				erpage("�� �����������, �����! ���� ������������ ����� ��������. ������� ����� ������, �����. :)");
				del(str);
				chetchik=1;
			}
			else if (chetchik<1){
				erpage("�� ����� ������ ������������...");
				del(str);
				chetchik=1;
			}
			else if (chetchik==1){
				chetchik=0;
			}
			return chetchik;	
		}

	
	
		/*=======================�������� ��������=======================*/
		
		
	//main
		public static void Main(string[] args)
		{ //Console.OutputEncoding=Encoding.UTF8; //������������� �� ������ �������� ��������� 
			fpage();
			menu();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		
		
		}
		
		
	//��������� �������� � ������������ - first page
		static void fpage(){
			Console.WriteLine("\t\t ����� ����������! \n\n\n" + 
		                  	  " �� ��������� ���������� '���������� ����������'. \n" +
		                      " ��������� �����������! \n\n" + 
		                      " ��� ����������� ������� ����� ������� . . . ");
			Console.ReadKey(true);
		}
	//�������� ����
		static void menu(){
			Console.Clear();
			Console.WriteLine(" �������� ����� ���� � \n ������� ��������������� �������: \n\n" +
			                 " 1 - ������� ������ ��������� \n" +
			                 " 2 - �������� ����� ������� \n" +
			                 " 3 - ������� ������������ ������� \n\n" +
			                 "         Esc  ����� \n\n\n"
			                 );
			ConsoleKeyInfo k = Console.ReadKey(); 	//��������� ������� ������� 
			Console.Clear();
			switch (k.Key){
					case ConsoleKey.D1 : 	//������� ������ ���������
						playlist();
						break;
					case ConsoleKey.D2 : 	//�������� ����� �������
						add_in_book();
						break;
					case ConsoleKey.D3 : 	//������� ������������ �������
						chose();
						break;
					case ConsoleKey.Escape : 	//�����
						Console.Clear();
						surepage("�� �������, ��� ������ �����?");
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
	//��� ������ ������ ���������
		static void playlist(){
			StreamReader reader = new StreamReader("1.txt"); 
�� 			Console.Clear();
�� 			if(reader.EndOfStream){ 	//���� ���� ����
�� 				erpage("��� ������ ��������� ����!");
�� 			}
�� 			else {
�� 				Console.WriteLine(" 1��������� � ���� 2����� ������� 3������� ��� �������� \n\n");
�� 				Console.WriteLine(reader.ReadToEnd());	//������� �� � ���
				ConsoleKeyInfo k = Console.ReadKey(); 	//��������� ������� ������� 
				Console.Clear();
				switch (k.Key){
					case ConsoleKey.D1 : 	//��������� � ����
						menu();
						break;
					case ConsoleKey.D2 : 	//����� �������
						chose();
						break;
					case ConsoleKey.D3 : 	//������� ��� ��������
						surepage("�� �������, ��� ������ ������� ��� ��������?");
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
�� 				}
�� 			}
�� 			reader.Close();
	}
	//����� - ������� ������������ �������
		static void chose(){
			bool consist=false;
			Console.WriteLine("������� ��� ��� ����� �������� ��������");
			foreach(string contact in File.ReadLines(@"1.txt")){
				if(contact.Contains(Console.ReadLine())){
					consist=true;				
				Console.WriteLine("1��������� � ���� 2������������� ������� 3������� �������\n");
				Console.WriteLine(contact);
				ConsoleKeyInfo k = Console.ReadKey(); 	//��������� ������� ������� 
				Console.Clear();
				switch (k.Key){
					case ConsoleKey.D1 : 	//��������� � ����
						menu();
						break;
					case ConsoleKey.D2 : 	//������������� ������� 
						if(proof_on_portach(contact)==0){
							redact(contact);
						}
						break;
					case ConsoleKey.D3 :	//������� �������
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
	//�������� �������
		static void add_in_book(){
			Console.WriteLine("������� ��� ��������: \n");
			File.AppendAllText("1.txt", Console.ReadLine());
			Console.WriteLine("������� ����� �������� ��������: \n");
			File.AppendAllText("1.txt", "  " + Console.ReadLine());
			Console.WriteLine("������� �������� ��������: \n");
			File.AppendAllText("1.txt", " | " + Console.ReadLine() + Environment.NewLine);
			menu();
		}
	//������������� �������
		static void redact(string str){
			Console.WriteLine("1������������� 2�������� ������� 3������������ �������� 4����\n" + str);
			ConsoleKeyInfo chg = Console.ReadKey();
			try{
				switch (chg.Key){
					case ConsoleKey.D1 :
						Console.WriteLine("������� ������ ��� ��������: \n"); //��� ��� ���� ������ ��� ��� ���, � ��� ������� :�
						str=Console.ReadLine();
						Console.WriteLine("������� ����� ��� ��������: \n");
						File.WriteAllText("1.txt", File.ReadAllText("1.txt").Replace(str,Console.ReadLine()));
						break;
					case ConsoleKey.D2 :
						Console.WriteLine("������� ������ ������� ��������: \n"); //��� ��� ���� ������ ��� ��� ���, � ��� ������� :�
						str=Console.ReadLine();
						Console.WriteLine("������� ����� ������� ��������: \n");
						File.WriteAllText("1.txt", File.ReadAllText("1.txt").Replace(str,Console.ReadLine()));
						break;
					case ConsoleKey.D3 :
						str=str.Substring(str.IndexOf('|'));
						Console.WriteLine("������� ����� �������� ��������: \n"); 
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
	//�������� ��������
		static void del(string str){
			File.WriteAllText("1.txt", File.ReadAllText("1.txt").Replace(str, ""));
			menu();
		}
}
}