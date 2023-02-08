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
            _fighters.Add(new Barbarion("Варвар", 1000, 80, 60));
            _fighters.Add(new Paladin("Паладин", 1000, 65, 80));
            _fighters.Add(new Archer("Лучник", 1000, 70, 70));
            _fighters.Add(new Asassin("Асассин", 1000, 90, 65));
        }

        public void StartBattle()
        {
            ShowFighters();

            _firstFighter = ChooseFighter("\n* Выберите первого бойца : ");
            Console.Clear();
            ShowFighters();
            Console.WriteLine($"\n* {_firstFighter.Name}  выбран для битвы !");
            _secondFighter = ChooseFighter("\n* Выберите второго бойца : ");
            Console.Clear();
            ShowFighters();
            Console.WriteLine($"\n* {_secondFighter.Name} выбран для битвы !");

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

        private int GetCorrectNumber(int minValue, int maxValue)
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

        private void ShowResultBattle()
        {
            if (_firstFighter.Health <= 0 && _secondFighter.Health <= 0)
            {
                Console.WriteLine(" **** Ничья! Погибли оба бойца! ****");
            }
            else if (_firstFighter.Health <= 0)
            {
                Console.WriteLine($" **** {_secondFighter.Name} Победил в этой битве!! ****");
            }
            else if (_secondFighter.Health <= 0)
            {
                Console.WriteLine($" **** {_firstFighter.Name} Победил в этой битве!! ****");
            }
        }

        private void ShowFighters()
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
        private static Random _random = new Random();

        protected int _defoultDamage;

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
            Console.WriteLine($" |Класс : {Name} | Жизни : {Health} | Урон : {CurrentDamage} | Броня : {Armor} |");
        }

        public virtual void TakeDamage(float damage)
        {
            int maxValue = 100;
            float damageReduction = 30;
            float healthLost = damage * ((maxValue - damageReduction) / maxValue);
            Health -= healthLost;
            Console.WriteLine($"* {Name} Получил урон и теряет {healthLost} единиц здоровья !");           
        }

        public virtual void Attack(Fighter fighter)
        {         
            fighter.TakeDamage(CurrentDamage);

            CurrentDamage = _defoultDamage;
        }

        public virtual bool CanUseSkill(int percent )
        {
            int maxSkillChance = 100;

            int chance = _random.Next(maxSkillChance + 1);

            return percent > chance;
        }      
    }

    class Knight : Fighter
    {
        private int _dodgeChance = 34;
        private int _steelArmor = 0;

        public Knight(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        public override void TakeDamage(float damage)
        {
            if (CanUseSkill(_dodgeChance))
            {              
                Console.WriteLine($"* {Name} Испльзует Стальную броню и поглащает урон прортивника !!");
                CurrentDamage = _steelArmor;
                CurrentDamage = _defoultDamage;               
            }
            else
            {
                base.TakeDamage(damage);
            }
        }
    }

    class Barbarion : Fighter
    {
        private int _specialSkillChance = 34;
        private int _axe = 60;

        public Barbarion(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }
        
        public override void Attack(Fighter fighter)
        {          
            if (CanUseSkill(_specialSkillChance))
            {
                Console.WriteLine($"* {Name} Кидает тапор нанося дополнительный урон !!");
                CurrentDamage += _axe;              
            }
            else
            {
                base.Attack(fighter);
            }
        }
    }

    class Paladin : Fighter
    {
        private int _treatmentChance = 14;
        
        private int _divineHealth = 100;
      
        public Paladin(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        public override void TakeDamage(float damage)
        {
            if (CanUseSkill(_treatmentChance))
            {
                Console.WriteLine($"* {Name} Испльзует божественное исцеление восстанавливая себе {_divineHealth} единиц здоровья!!!");
                Health += _divineHealth;
            }
            else
            {
                base.TakeDamage(damage);
            }          
        }
    }

    class Archer : Fighter
    { 
        private int _evasion = 0;
        private int _dodgeChance = 19;       
        
        public Archer(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        public override void TakeDamage(float damage)
        {
            if (CanUseSkill(_dodgeChance))
            {
                Console.WriteLine($"* {Name} Использует Плащ ветра и уклоняется от атаки !!");
                CurrentDamage = _evasion;
                CurrentDamage = _defoultDamage;
            }
            else
            {
                base.TakeDamage(damage);
            }
        }        
    }
    
    class Asassin : Fighter
    {
        private int _draftСhance = 34;
        private int _damageMultiplier = 2;
        
        public Asassin(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        public override void Attack(Fighter fighter)
        {
            if (CanUseSkill(_draftСhance))
            {
                Console.WriteLine($"* {Name} Призывает двойника из мира теней нанося в 2 раза больше урона !!");
                CurrentDamage *= _damageMultiplier;
            }
            else
            {
                base.Attack(fighter);
            }
        }
    }
}