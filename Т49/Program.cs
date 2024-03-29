﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.StartExcursion();
        }
    }

    class Zoo
    {
        private const string Start = "1";
        private const string Exit = "2";

        private List<Aviary> _aviaries = new List<Aviary>();

        public void StartExcursion()
        {
            CreateAviaries();

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Добро пожаловать в зоопар. У нас есть {_aviaries.Count} вальеров с животными\n" +
                    $"Для начало экскурсии по зоопарку, введите : {Start}\n" +
                    $"Для завершения экскурсии введите : {Exit} ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case Start:
                        ShowAviary();
                        break;

                    case Exit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Хм.. Такой команды нету.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateAviaries()
        {
            _aviaries.Add(new Aviary(new Animal("Тигр", "Ppppp")));
            _aviaries.Add(new Aviary(new Animal("Горный козел", "Бееее")));
            _aviaries.Add(new Aviary(new Animal("Жираф", "Хрум хрум")));
            _aviaries.Add(new Aviary(new Animal("Змея", "Ссссс")));
            _aviaries.Add(new Aviary(new Animal("Крокодил", "Клац клац")));
        }

        private void ShowAviary()
        {
            Console.Write("На какой вольер вы хотите посмотреть?: ");

            bool isNumber = int.TryParse(Console.ReadLine(), out int inputNumberAviary);

            if (isNumber == false)
            {
                Console.WriteLine("Ошибка! Вы ввели не коректные данные.");
            }
            else if (inputNumberAviary > 0 && inputNumberAviary < _aviaries.Count + 1)
            {
                _aviaries[inputNumberAviary - 1].ShowAnimal();
            }
            else
            {
                Console.WriteLine("Вальера с таким номером в зоопарке нету.");
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();
        private static Random _random = new Random();
        private int _numberOfAnimals;
        private int _maxCountAnimals = 8;
        private int _minCountAnimals = 3;

        public Aviary(Animal animal)
        {
            _numberOfAnimals = _random.Next(_minCountAnimals, _maxCountAnimals);

            for (int i = 0; i < _numberOfAnimals; i++)
            {
                _animals.Add(new Animal(animal));
            }
        }

        public void ShowAnimal()
        {
            Console.WriteLine($"\nКоличиство животных в вольере - {_animals.Count}");

            foreach (var animal in _animals)
            {
                Console.WriteLine($"\n{animal.Name}. Пол - {animal.Gender}. Звук - {animal.Voice}");
            }
        }
    }

    class Animal
    {
        private static Random _random = new Random();

        public Animal(string name, string voice)
        {
            Name = name;
            Gender = GetGenderAnimal();
            Voice = voice;
        }

        public Animal(Animal animal)
        {
            Name = animal.Name;
            Gender = GetGenderAnimal();
            Voice = animal.Voice;
        }

        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Voice { get; private set; }

        private string GetGenderAnimal()
        {
            int minimumNumberGender = 0;
            int maximumNumberGender = 3;
            int gender = _random.Next(minimumNumberGender, maximumNumberGender);

            if (gender == 1)
            {
                return "Мужской";
            }
            else
            {
                return "Женский";
            }
        }
    }
}