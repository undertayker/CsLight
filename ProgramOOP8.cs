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
        private List<Fighter> _fighters = new List<Fighter>();
        private Fighter _firstFighter;
        private Fighter _secondFighter;

        public Arena()
        {
            _fighters.Add(new Knight("Рыцарь", 100, 45, 40));
            _fighters.Add(new Barbarion("Варвар", 100, 50, 30));
            _fighters.Add(new Paladin("Паладин", 100, 40, 40));
            _fighters.Add(new Archer("Лучник", 100, 30, 35));
            _fighters.Add(new Asassin("Асассин", 100, 35, 30));
        }


        public void StartBattle()
        {
            ShowFighters();

            _firstFighter = GetChoosenFighter("Выберите первого бойца : ");
            Console.Clear();
            ShowFighters();
            Console.WriteLine($"{_firstFighter.Name}  выбран !");
            _secondFighter = GetChoosenFighter("Выберите второго бойца : ");
            Console.Clear();
            ShowFighters();
            Console.WriteLine($"{_secondFighter.Name} выбран !");
           

            while (_firstFighter.Health > 0 && _secondFighter.Health > 0)
            {
                Console.ReadKey();
                Console.Clear();
                _firstFighter.ShowInfo();
                _secondFighter.ShowInfo();
                _firstFighter.TakeDamage(_secondFighter.Damage);
                _secondFighter.TakeDamage(_firstFighter.Damage);
                _firstFighter.UseSpecialAttack(_secondFighter);
                _secondFighter.UseSpecialAttack(_firstFighter);
                ShowResultBattle();
            }
        }

        private Fighter GetChoosenFighter(string text)
        {
            Console.Write(text);
            int index = GetCorrectNumber(1, _fighters.Count) - 1 ;
            Fighter fighter = _fighters[index];
            _fighters.Remove(fighter);
            return fighter;
        }

        public int GetCorrectNumber(int minValue, int maxValue)
        {
            bool isParsing = true;
            int number = 0;

            while (isParsing)
            {
                string userInput = Console.ReadLine();

                isParsing = int.TryParse(userInput, out number);

                if (number >= minValue && number <= maxValue)
                {
                    isParsing = false;
                }
            }

            Console.WriteLine(number);
            return number;
        }

        public void ShowResultBattle()
        {
            if (_firstFighter.Health <= 0 && _secondFighter.Health <= 0)
            {
                Console.WriteLine("Ничья! Погибли оба бойца!");
            }
            else if (_firstFighter.Health < 0)
            {
                Console.WriteLine($"{_secondFighter.Name} Победил в битве!!");
            }
            else if (_secondFighter.Health < 0)
            {
                Console.WriteLine($"{_secondFighter.Name} Победил в битве!!");
            }
        }
        public void ShowFighters()
        {
            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.Write(i + 1);
                _fighters[i].ShowInfo();
            }
        }
    }

    abstract class Fighter
    {
        public Fighter(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public string Name { get; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }

        public void ShowInfo()
        {
            Console.WriteLine($" Класс : {Name}, Жизни : {Health}, Урон : {Damage}, Броня : {Armor}");
        }

        public void AddHealth(int health)
        {
            if (health > 0)
            {
                Health += health;
            }
        }
        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }

        public void UseSpecialAttack(Fighter fighter)
        {
            Random random = new Random();
            int _chance = 33;
            int _maxChance = 100;

            bool isSuccess = random.Next(_maxChance) < _chance;

            if (isSuccess)
            {
                UseSkill();
            }
        }

        protected virtual void UseSkill() { }
    }

    class Knight : Fighter
    {
        private int _graceOfTheGoods = 25;
        public Knight(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSkill()
        {
            Console.WriteLine($"{Name} Использовал милость богини. Жизни и Броня увеличилсь !");
            Health += _graceOfTheGoods;
            Armor += _graceOfTheGoods;
        }
    }

    class Barbarion : Fighter
    {
        private int _furiousRoar = 20;

        public Barbarion(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSkill()
        {
            Console.WriteLine($"{Name} Использовал Яростный рев. Урон увеличен");
            Damage += _furiousRoar;
        }
    }

    class Paladin : Fighter
    {
        private int _divineHealth = 50;
        public Paladin(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSkill()
        {
            Console.WriteLine($"{Name} Использует Божественное исцеление. Восстановление здоровья на 50%");
            AddHealth(_divineHealth);
        }
    }

    class Archer : Fighter
    {
        private int _damageBuff = 40;

        public Archer(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSkill()
        {
            Console.WriteLine($"{Name} Использовал Песнь духов. Урон увеличен ! ");
            Damage += _damageBuff;
        }
    }

    class Asassin : Fighter
    {
        private int _doubleDamage = 2;
        public Asassin(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSkill()
        {
            Console.WriteLine($"{Name} Призывает из тени двойника. Бьет в 2 раза сильней !");
            Damage *= _doubleDamage;
        }
    }
}

