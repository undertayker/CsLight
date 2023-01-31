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
            _fighters.Add(new Knight("Рыцарь", 1000, 75, 80));
            _fighters.Add(new Barbarion("Варвар", 1000, 100, 60));
            _fighters.Add(new Paladin("Паладин", 1000, 70, 80));
            _fighters.Add(new Archer("Лучник", 1000, 60, 70));
            _fighters.Add(new Asassin("Асассин", 1000, 90, 65));
        }

        public void StartBattle()
        {
            ShowFighters();

            _firstFighter = ChooseFighter("Выберите первого бойца : ");
            Console.Clear();
            ShowFighters();
            Console.WriteLine($"{_firstFighter.Name}  выбран !");
            _secondFighter = ChooseFighter("Выберите второго бойца : ");
            Console.Clear();
            ShowFighters();
            Console.WriteLine($"{_secondFighter.Name} выбран !");

            while (_firstFighter.Health > 0 && _secondFighter.Health > 0)
            {
                Console.ReadKey();
                Console.Clear();
                _firstFighter.ShowInfo();
                _secondFighter.ShowInfo();
                _firstFighter.Attack(_secondFighter);
                _secondFighter.Attack(_firstFighter);
                ShowResultBattle();
            }          
        }

        public int GetCorrectNumber(int minValue, int maxValue)
        {
            bool isParsing = true;
            int number = 0;

            while (isParsing)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out number))
                {
                    if (number >= minValue && number <= maxValue)
                    {
                        isParsing = false;
                    }
                }

                if (isParsing)
                {
                    Console.WriteLine($"Неверный ввод. Должно быть от {minValue} до {maxValue}");
                }
            }

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

        private Fighter ChooseFighter(string text)
        {
            Console.Write(text);
            int index = GetCorrectNumber(1, _fighters.Count) - 1;
            Fighter fighter = _fighters[index];
            _fighters.Remove(fighter);
            return fighter;
        }
    }

    abstract class Fighter
    {
        private static Random random = new Random();

        int _defoultDamage;
        
        public Fighter(string name, int health, int defoultDamage, int armor)
        {
            Name = name;
            Health = health;
            _defoultDamage = defoultDamage;
            Armor = armor;
            CurrentDamage = _defoultDamage;
        }

        public string Name { get; protected set; }
        public float Health { get; protected set; }
        public float CurrentDamage { get; protected set; }
        public float Armor { get; protected set; }

        public void ShowInfo()
        {
            Console.WriteLine($" Класс : {Name}, Жизни : {Health}, Урон : {CurrentDamage}, Броня : {Armor}");
        }

        public void TakeDamage(float damage)
        {
            int maxValue = 100;
            float damageReduction = 30;
            float healthLost = damage * ((maxValue - damageReduction) / maxValue);
            Health -= healthLost;
            Console.WriteLine(Name + " Теряет " + healthLost + " ХП");
        }

        public void Attack(Fighter fighter)
        {           
            int specialSkillChance = 34;
            int maxSkillChance = 100;
            int chance = random.Next(maxSkillChance);

            if (chance <= specialSkillChance)
            {
                UseSpecialAttack();
            }

            fighter.TakeDamage(CurrentDamage);

            CurrentDamage = _defoultDamage;
        }

        protected virtual void UseSpecialAttack() { }
    }

    class Knight : Fighter
    {
        private int _maxArmor = 150;
        private int _graceOfGods = 70;

        public Knight(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSpecialAttack()
        {
            Console.WriteLine($"{Name} Использовал милость богини. Жизни и Броня увеличилсь !");
            Health += _graceOfGods;
            Armor += _graceOfGods;

            if (Armor > _maxArmor)
            {
                Armor = _maxArmor;
            }
        }
    }

    class Barbarion : Fighter
    {
        private int _furiousRoar = 40;

        public Barbarion(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSpecialAttack()
        {
            Console.WriteLine($"{Name} Использовал Яростный рев. Урон увеличен");
            CurrentDamage += _furiousRoar;
        }
    }

    class Paladin : Fighter
    {
        private int _divineHealth = 50;

        public Paladin(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSpecialAttack()
        {
            Console.WriteLine($"{Name} Использует Божественное исцеление. Восстановление здоровья");
            Health += _divineHealth;
        }
    }

    class Archer : Fighter
    {
        private int _damageBuff = 70;

        public Archer(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSpecialAttack()
        {
            Console.WriteLine($"{Name} Использовал Песнь духов. Урон увеличен ! ");
            CurrentDamage += _damageBuff;
        }
    }

    class Asassin : Fighter
    {
        private int _damageMultiplier  = 2;

        public Asassin(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSpecialAttack()
        {
            Console.WriteLine($"{Name} Призывает из тени двойника. Бьет в {_damageMultiplier} раза сильней !");
            
            CurrentDamage *= _damageMultiplier ;
        }
    }
}
