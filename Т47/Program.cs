using System;

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
            Field field = new Field();
            Console.WriteLine("Симуляция боя сил Тьмы и Света, для начала любую клавишу");
            Console.ReadKey();
            field.Battle();
            field.ShowBattleResult();
        }
    }

    class Field
    {
        private Platoon _firsPlatoon = new Platoon("Сил Тьмы");
        private Platoon _secondPlatoon = new Platoon("Сил Света");
        private Soldier _firstSoldier;
        private Soldier _secondSoldier;

        public void Battle()
        {
            while (_firsPlatoon.GetCountSoliders() > 0 && _secondPlatoon.GetCountSoliders() > 0)
            {
                _firstSoldier = _firsPlatoon.GetSoldierToBattle();
                _secondSoldier = _secondPlatoon.GetSoldierToBattle();

                _firsPlatoon.ShowInfo();
                Console.WriteLine(new string('-',40));
                _secondPlatoon.ShowInfo();

                _firstSoldier.Attack(_secondSoldier);
                _secondSoldier.Attack(_firstSoldier);

                DeliteDeadSoldier();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public void ShowBattleResult()
        {
            if (_firsPlatoon.GetCountSoliders() <= 0 && _secondPlatoon.GetCountSoliders() <= 0)
            {
                Console.WriteLine("Ничья, оба взвода погибли");
            }
            else if (_firsPlatoon.GetCountSoliders() <= 0)
            {
                Console.WriteLine("Взвод сил Света победил!");
            }
            else
            {
                Console.WriteLine("Взвод сил Тьмы победил!");
            }
        }

        private void DeliteDeadSoldier()
        {
            if (_firstSoldier.Health <= 0)
            {
                _firsPlatoon.RemoveSoldier(_firstSoldier);
            }
            if (_secondSoldier.Health <= 0)
            {
                _secondPlatoon.RemoveSoldier(_secondSoldier);
            }
        }
    }

    class PlatoonCreator
    {
        private static Random _random = new Random();

        private List<Soldier> _soldiers = new List<Soldier>()
        {
            new Soldier("Снайпер", 50, 100),
            new Soldier("Инжeнер", 45, 100),
            new Soldier("Медик", 40, 100),
        };

        public List<Soldier> CreateSoldiers()
        {
            int maxCount = 10;
            int minCount = 9;
            int count = _random.Next(minCount, maxCount + 1);

            List<Soldier> newSoldiers = new List<Soldier>();

            for (int i = 0; i < count; i++)
            {
                Soldier soldier = new Soldier (_soldiers[_random.Next(_soldiers.Count)]);
                newSoldiers.Add(soldier);
            }

            return newSoldiers;
        }
    }

    class Platoon
    {
        private static Random _random = new Random();
        private List<Soldier> _soldiers = new List<Soldier>();
        private string _name;

        public Platoon(string name)
        {
            PlatoonCreator creator = new PlatoonCreator();
            _soldiers = creator.CreateSoldiers();
            _name = name;
        }

        public void RemoveSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Взвод {_name}");

            foreach (var solider in _soldiers)
            {
                Console.WriteLine($"{solider.Name}. Здоровье: {solider.Health}. Урон: {solider.Damage}.");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public int GetCountSoliders()
        {
            return _soldiers.Count;
        }

        public Soldier GetSoldierToBattle()
        {
            return _soldiers[_random.Next(0, _soldiers.Count)];
        }
    }

    class Soldier
    {
        private static Random _random = new Random();

        public Soldier(string name, int damage, int health)
        {
            Name = name;
            Damage = damage;
            Health = health;
        }

        public Soldier(Soldier soldier)
        {
            Name = soldier.Name;
            Damage = soldier.Damage;
            Health = soldier.Health;
        }

        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        public int Health { get; protected set; }

        public void Attack(Soldier soldier)
        {
            if (CanUseSpecialAttack(soldier))
            {
                UseFeature(soldier);
            }
            else
            {
                soldier.TakeDamage(Damage);
            }
        }

        public virtual bool CanUseSpecialAttack(Soldier soldier)
        {
            int rangeMaximalNumbers = 100;
            int chanceUsingAbility = _random.Next(rangeMaximalNumbers);
            int chanceAbility = 34;
            return chanceUsingAbility <= chanceAbility;
        }

        public virtual void TakeDamage(int damageSolider)
        {
            Health -= damageSolider;
            Console.WriteLine();
            Console.WriteLine($"{Name} нанес {Damage} урона, а получил {damageSolider} урона");
        }

        protected virtual void UseFeature(Soldier soldier)
        {
            Health -= soldier.Damage;
            Console.WriteLine();
            Console.WriteLine($"{Name} нанес {Damage} урона, а получил {soldier.Damage} урона");
        }
    }

    class Sniper : Soldier
    {
        private int _damageBuff = 100;
        public Sniper(string name, int damage, int health) : base(name, damage, health) { }

        protected override void UseFeature(Soldier soldier)
        {
            Damage += _damageBuff;
            Health -= soldier.Damage;
            Console.WriteLine($"\n{Name} выстрелил точно в голову, урона  нанесено {Damage} ");
        }
    }

    class Engineer : Soldier
    {

        public Engineer(string name, int damage, int health) : base(name, damage, health) { }

        public override void TakeDamage(int damageSolider)
        {
            int damageReduction = 2;
            int blockedDamage = damageSolider / damageReduction;
            Health -= damageSolider / damageReduction;
            Console.WriteLine($"\nИнженер наносит {Damage} урона , ставит щит блокируя урон , заблокировано {blockedDamage}");
        }
    }

    class Medic : Soldier
    {
        public Medic(string name, int damage, int health) : base(name, damage, health) { }

        protected override void UseFeature(Soldier soldier)
        {
            int healthBuff = 50;
            int maxHealth = 100;

            if (Health < maxHealth)
            {
                Console.WriteLine($"{Name} перебинтовывается , увеличивая здоровье");
                Health += healthBuff;
                base.TakeDamage(Damage);
            }
        }
    }
}