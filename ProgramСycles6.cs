using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            string menuCommand1 = "[Time] - узнать время ";
            string menuCommand2 = "[СhangeColor] - изменить цвет текста";
            string menuCommand3 = "[Set Name] - установить имя";
            string menuCommand4 = "[Esc] - выйти из меню";
            string name;

            string enter = "";

            while (enter != "Esc")
            {
                Console.Clear();
                Console.WriteLine(" Меню ");
                Console.WriteLine(menuCommand1);
                Console.WriteLine(menuCommand2);
                Console.WriteLine(menuCommand3);
                Console.WriteLine(menuCommand4);
                Console.WriteLine("Выберите команду из меню : ");
                enter = Console.ReadLine();

                if (enter == "Time")
                {
                    Console.Clear();
                    Console.WriteLine("Вы выбрали команду [Time]");
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine("Нажмите Enter для возврата в меню ");
                    Console.ReadLine();
                }
                else if (enter == "ChangeColor")
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Вы выбрали команду [ChangeColor]");
                    Console.WriteLine("Была произведена окораска текста ");
                    Console.WriteLine("Нажмите Enter для возврата в меню ");
                    Console.ReadLine();
                    Console.ResetColor();
                }
                else if (enter == "Set Name")
                {
                    Console.Clear();
                    Console.WriteLine("Вы выбрали команду [SetName]");
                    Console.WriteLine("Введите ваше имя : ");
                    name = Console.ReadLine();
                    Console.WriteLine("Ваше имя установлено\nДобро пожаловать!!!\n" + name);
                    Console.WriteLine("Нажмите Enter для возврата в меню ");
                    Console.ReadLine();
                }
                else if (enter == "Esc")
                {
                    Console.Clear();
                    Console.WriteLine("Вы выбрали команду [Esc]");
                    Console.WriteLine("Спасибо за внимание, всего хорошего! ");
                }
                else
                    Console.WriteLine("Введена неверная команда, повторите ввод ");
            }
        }
    }
}


