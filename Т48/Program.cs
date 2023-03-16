using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Т48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            bool isWork = true;

            const string AddFish = "1";
            const string RemoveFish = "2";
            const string Exit = "3";

            while (isWork)
            {
                aquarium.ShowAquarium();

                Console.WriteLine($"\n{AddFish} - Добавить рыбу" +
                    $"\n{RemoveFish} - Убрать рыбу " +
                    $"\n{Exit} - Выход");

                Console.WriteLine("Что бы пропустить день нажмите ENTER");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddFish:
                        aquarium.AddFish();
                        break;

                    case RemoveFish:
                        aquarium.RemoveFish();
                        break;

                    case Exit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Введены некорректные данные !");
                        break;

                }

                aquarium.UpdateAgeFish();
                aquarium.RemoveDeadFish();
                Console.Clear();
            }      
        }      
    }

    class Aquarium
    {
        private int _countFish = 5;
        private List<Fish> _fishes = new List<Fish>();

        public Aquarium()
        {
            _fishes.Add(new Fish(1, "Пузырь"));
            _fishes.Add(new Fish(3, "Дори"));
        }

        public void AddFish()
        {
            string name;
            int age;

            if (_countFish <= _fishes.Count)
            {
                Console.Clear();
                Console.WriteLine("В аквариуме больше нет места!!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Введите имя рыбки : ");
                name = GetInputText();
                Console.WriteLine("Введите возрост рыбки : ");
                age = GetInputAge();

                if (name == null && age == 0)
                {
                    Console.WriteLine("Введены некорректные данные !!");
                }
                else
                {
                    _fishes.Add(new Fish(age, name));
                }
            }
        }

        public void RemoveFish()
        {
            if (TryGetFish(out Fish fish))
            {
                _fishes.Remove(fish);
            }
        }

        public void ShowAquarium()
        {
            int numberFish = 1;
            Console.WriteLine($"\nРыб в аквариуме - {_fishes.Count}");

            foreach (var fish in _fishes)
            {
                Console.WriteLine($"{numberFish++}. {fish.Name}, возраст {fish.Age}");
            }
        }

        public void RemoveDeadFish()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].IsAlive == false)
                {
                    _fishes.Remove(_fishes[i]);
                }
            }
        }

        public void UpdateAgeFish()
        {
            foreach (var fish in _fishes)
            {
                fish.Live();
            }
        }

        private bool TryGetFish(out Fish fish)
        {
            Console.WriteLine("Введите номер рыбы : ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int inputNumberFish);

            if (isNumber == false)
            {
                Console.WriteLine("Введены не корректные данные !!");
                fish = null;
                return false;
            }
            else if (inputNumberFish > 0 && inputNumberFish - 1 < _fishes.Count)
            {
                fish = _fishes[inputNumberFish - 1];
                Console.WriteLine("Вы успешно убрали рыбу !");
                return true;
            }
            else
            {
                Console.WriteLine("Рыбы с таким номером в аквариуме нет ! ");
                fish = null;
                return false;
            }
        }

        private int GetInputAge()
        {
            int maximumLenght = 1;
            int maximumAge = 9;

            bool isNumber = int.TryParse(Console.ReadLine(), out int age);

            if (isNumber == true && age >= maximumLenght && age <= maximumAge)
            {
                Console.WriteLine("Действие выполнено !");                
                return age;
            }
            else
            {
                Console.WriteLine("Введены некорректные данные, повторите попытку !");
                return age;
            }
        }

        private string GetInputText()
        {
            string text = Console.ReadLine();

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol) == false)
                {
                    Console.WriteLine("Введены не корректные данные, повторите попытку !");
                    return null;
                }
            }

            return text;
        }
    }

    class Fish
    {
        private int _lethalAge = 10;

        public Fish(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int Age { get; private set; }
        public string Name { get; private set; }
        public bool IsAlive
        {
            get 
            {
                return Age < _lethalAge;
            }
            private set { }
        }

        public void Live()
        {
            Age++;
        }
    }
}
