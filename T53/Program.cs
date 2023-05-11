using System;
using System.Collections.Generic;
using System.Linq;

namespace T53
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Hospital
    { 
        private List<Sick> _sick = new List<Sick>();

        public Hospital()
        {
            _sick.Add(new Sick("Котович Андрей Валерьевич", 26, "Коньюктевит"));
            _sick.Add(new Sick("Смирнов Александр Владимирович", 35, "Артрит"));
            _sick.Add(new Sick("Петров Владимер Андреевич", 46, "Цироз"));
            _sick.Add(new Sick("Волков Анатолий Сергеевич", 29, "Скалеоз"));
            _sick.Add(new Sick("Кузнецов Давид Валерьевич", 28, "Киста печени"));
            _sick.Add(new Sick("Соколов Генадий Александрович", 38, "Пневмония"));
            _sick.Add(new Sick("Скворцов Илья Анатольевич", 40, "Лейкемия"));
            _sick.Add(new Sick("Иванов Иван Иванович", 50, "Туберкулез"));
            _sick.Add(new Sick("Дроздов Никита сергеевич", 18, "Повышенная температура"));
            _sick.Add(new Sick("Никитин Вечеслав Юрьевич", 20, "Метеоризм"));
        }

        public void Work()
        {
            const string ShowAllSick = "1";
            const string SortByName = "2";
            const string SortByYears = "3";
            const string SickSpecificDisease = "4";
            const string Exit = "5";

            bool isWork = true;
            string userInput;

            Console.WriteLine("Добро пожаловать в больницу!");

            while (isWork)
            {
                Console.WriteLine($"\n{ShowAllSick} - Показать список всех больных\n" +
                    $"{SortByName} - Отсортировать всех больных по ФИО\n" +
                    $"{SortByYears} - Отсортировать всех больных по возрасту\n" +
                    $"{SickSpecificDisease} - Вывести больных с определенным заболеванием\n" +
                    $"{Exit} - Выйти");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowAllSick:
                        ShowInfos(_sick);
                        break;

                    case SortByName:
                        ShowSortAllSickByName();
                        break;

                    case SortByYears:
                        ShowSortAllSickByYears();
                        break;

                    case SickSpecificDisease:
                        ShowSickWithSpecificDisease();
                        break;

                    case Exit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Введены некорректные данные!");
                        break;
                }
            }
        }

        private void ShowSortAllSickByName()
        {
            var orderSickByName = _sick.OrderBy(sick => sick.Name);

            ShowInfos(orderSickByName);
        }

        private void ShowSortAllSickByYears()
        {
            var orderSickByYears = _sick.OrderBy(sick => sick.Years);

            ShowInfos(orderSickByYears);
        }

        private static void ShowInfos(IEnumerable<Sick> sicksCollection)
        {
            foreach (var sick in sicksCollection)
            {
                sick.ShowInfo();
            }
        }

        private void ShowSickWithSpecificDisease()
        {
            string disease;

            Console.WriteLine("Введите болезнь поциента : ");
            disease = Console.ReadLine();

            var orderSickByDisease = from Sick sick in _sick where sick.Disease == disease select sick;

            ShowInfos(orderSickByDisease);
        }
    }

    class Sick
    {
        public Sick(string name, int years, string disease)
        {
            Name = name;
            Years = years;
            Disease = disease;
        }

        public string Name { get; private set; }
        public int Years { get; private set; }
        public string Disease { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} |Возраст : {Years} Лет | Заболевание : {Disease}");
        }
    }
}
