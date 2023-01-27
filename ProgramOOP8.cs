using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            arena.StartBattle();
        }
    }

    class Arena
    {
        private Fighter _firstFighter;
        private Fighter _secondFighter;
        private List<Fighter> _fighters = new List<Fighter>();

        public Arena()
        {
            _fighters.Add(new Knight(" Рыцарь", 100, 55, 45));
            _fighters.Add(new Barbarion(" Варвар", 100, 60, 20));
            _fighters.Add(new Paladin(" Паладин", 100, 50, 50));
            _fighters.Add(new Asassin(" Асасин", 100, 70, 10));
            _fighters.Add(new Archer(" Лучник", 100, 55, 15));
        }

        public void StartBattle()
        {
            _firstFighter = ChooseFighter();
            _secondFighter = ChooseFighter();

            while (_firstFighter.Health > 0 && _secondFighter.Health > 0)
            {
                _firstFighter.ShowStats();
                _secondFighter.ShowStats();
                _firstFighter.TakeDamage(_secondFighter.Damage);
                _secondFighter.TakeDamage(_firstFighter.Damage);
                _firstFighter.UseSpecialAttack();
                _secondFighter.UseSpecialAttack();

                ShowBattleResult();

                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ShowBattleResult()
        {
            if (_firstFighter.Health <= 0 && _secondFighter.Health <= 0)
            {
                Console.WriteLine("Ничья!! Погибли оба бойца!!");
            }
            else if (_firstFighter.Health <= 0)
            {
                Console.WriteLine($"{_secondFighter.Name} Победил!!!");
            }
            else if (_secondFighter.Health <= 0)
            {
                Console.WriteLine($"{_firstFighter.Name} Победил!!!");
            }
        }

        private Fighter ChooseFighter()
        {
            Fighter fighter = null;
            int number;
            ShowFighters();

            Console.Write("Введите номер бойца: ");
            string fighterNimber = Console.ReadLine();
 
            if (int.TryParse(fighterNimber, out number))
            {
                number--;

                if (number >= 0 && number < _fighters.Count)
                {
                    fighter = _fighters[number];
                    _fighters.Remove(fighter);
                }
                else
                {
                    Console.WriteLine("Такого бойца нет!");
                }
            }

            return fighter;
        }

        private void ShowFighters()
        {
            Console.WriteLine("Добро пожаловать на Арену!!\nВыберите 2 бойцов из списка :");

            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.Write(i + 1);
                _fighters[i].ShowStats();
            }
        }
    }

    class Fighter
    {
        public Fighter(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }

        public void ShowStats()
        {
            Console.WriteLine($"Класс - {Name}," +
                              $" Здоровье - {Health}," +
                              $" Наносимый урон - {Damage}," +
                              $" Броня - {Armor}");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }

        public void UseSpecialAttack()
        {
            Random random = new Random();
            int rangeMaxNumbers = 100;
            int chanceUsingAbility = random.Next(rangeMaxNumbers);
            int chanceAbility = 20;

            if (chanceUsingAbility < chanceAbility)
            {
                UsePower();
            }
        }

        protected virtual void UsePower() { }
    }

    class Knight : Fighter
    {
        private int _graceOfTheGoddess = 25;
        public Knight(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} Использовал милость богини. Броня и Жизни увеличены!!");
            Armor += _graceOfTheGoddess;
            Health += _graceOfTheGoddess;
        }
    }

    class Barbarion : Fighter
    {
        private int _furiousRoar = 20;
        public Barbarion(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} Использовал заклинание Яростный рев. Урон и Жизни увеличены!!");
            Health += _furiousRoar;
            Damage += _furiousRoar;
        }
    }

    class Paladin : Fighter
    {
        private int _divineHealing = 50;
        public Paladin(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} Использует заклинание Божественное исцеление. Восстановление 50% жизней");
            Health += _divineHealing;
        }
    }

    class Asassin : Fighter
    {
        private int _doubleDamage = 2;
        public Asassin(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} Призывает из тени двойника. Получение в 2 раза больше урона !!");
            Damage *= _doubleDamage;
        }
    }

    class Archer : Fighter
    {
        private int _damageBuff = 50;
        public Archer(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} использовал заклинание Песнь Духов. Урон увеличен!! ");
            Damage += _damageBuff;
        }
    }
}

