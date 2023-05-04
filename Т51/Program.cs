using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Т51
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DetectiveAgency detectiveAgency = new DetectiveAgency();
            detectiveAgency.Work();
        }
    }

    class DetectiveAgency
    {
        const string ShowAllCriminals = "1";
        const string FindPrisoners = "2";
        const string Exit = "3";

        private List<Criminal> _criminals = new List<Criminal>();

        public DetectiveAgency()
        {
            _criminals.Add(new Criminal("Котович Андрей Валерьевич", "Заключен под стражу", 181, 83, "Русский"));
            _criminals.Add(new Criminal("Смирнов Александр Владимирович", "Под стражу не заключен", 176, 72, "Русский"));
            _criminals.Add(new Criminal("Петров Владимер Андреевич", "Заключен под стражу", 190, 87, "Белорус"));
            _criminals.Add(new Criminal("Волков Анатолий Сергеевич", "Под стражу не заключен", 172, 67, "Украинец"));
            _criminals.Add(new Criminal("Кузнецов Давид Валерьевич", "Под стражу не заключен", 187, 74, "Русский"));
            _criminals.Add(new Criminal("Соколов Генадий Александрович", "Заключен под стражу", 182, 80, "Русский"));
        }

        public void Work()
        {
            bool isWork = true;
            string userInput;

            Console.WriteLine("Добро пожаловать в детективное агенство");

            while (isWork)
            {
                Console.WriteLine($"\n{ShowAllCriminals} - Для просмотра всех приступников\n" +
                    $"{FindPrisoners} - Для поиска приступников\n{Exit} - Для выхода из агенства ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowAllCriminals:
                        ShowCriminals();
                        break;

                    case FindPrisoners:
                        FindCriminals();
                        break;

                    case Exit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Некорректный ввод!!!");
                        break;
                }
            }
        }

        private void FindCriminals()
        {
            string notTakenIntoCustody = "Под стражу не заключен";
            string nationality;
            bool userInput;

            Console.Write("Введите рост подозреваемого :");
            userInput = int.TryParse(Console.ReadLine(), out int height);
            Console.Write("Введите вес подозреваемого :");
            userInput = int.TryParse(Console.ReadLine(), out int weight);
            Console.Write("Введите национальность подозреваемого :");
            nationality = Console.ReadLine();

            var filteredCriminals = from Criminal criminal in _criminals
                                    where criminal.Height == height
                                    && criminal.Weight == weight && criminal.Nationality == nationality
                                    && criminal.Guarded == notTakenIntoCustody
                                    select criminal;

            foreach (var criminal in filteredCriminals)
            {
                Console.WriteLine("Найдены заключенные :");

                criminal.ShowInfo();
            }
        }

        private void ShowCriminals()
        {
            foreach (var criminal in _criminals)
            {
                criminal.ShowInfo();
            }
        }
    }

    class Criminal
    {
        public Criminal(string name, string guarded, int height, int weight, string nationality)
        {
            Name = name;
            Guarded = guarded;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }

        public string Name { get; private set; }
        public string Guarded { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} | {Guarded} | Рост {Height} | Вес {Weight} | Национальность {Nationality}");
        }
    }
}
