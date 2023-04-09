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
        private Platoon _firsPlatoon = new Platoon();
        private Platoon _secondPlatoon = new Platoon();
        private Soldier _firstSoldier;
        private Soldier _secondSoldier;

        public void Battle()
        {
            while (_firsPlatoon.GetCountSoliders() > 0 && _secondPlatoon.GetCountSoliders() > 0)
            {
                _firstSoldier = _firsPlatoon.GetSoldierToBattle();
                _secondSoldier = _secondPlatoon.GetSoldierToBattle();
                _firsPlatoon.ShowInfo();
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

    class Platoon
    {
        private static Random _random = new Random();
        private List<Soldier> _soldiers = new List<Soldier>();

        private List<Soldier> _typeSoldiers = new List<Soldier>
        {
            new Sniper("Снайпер", 50, 100),
            new Engineer("Инженер", 45, 100),
            new Medic("Медик", 40, 100)
        };

        public Platoon()
        {
            int countSoldiers = 10;
            Create(countSoldiers, _soldiers, _typeSoldiers);
        }

        public void RemoveSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        public void ShowInfo()
        {
            Console.WriteLine(" Взвод ");

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

        private void Create(int countSoldiers, List<Soldier> soldiers, List<Soldier> typeSoldiers)
        {
            for (int i = 0; i < countSoldiers; i++)
            {
                soldiers.Add(CreateSoldier(typeSoldiers));
            }
        }

        private Soldier CreateSoldier(List<Soldier> typeSoldiers)
        {
            int minimumNumberClassSolider = 0;
            int maximumNumberClassSolider = 3;
            int newSolider = _random.Next(minimumNumberClassSolider, maximumNumberClassSolider);

            for (int i = 0; i < typeSoldiers.Count; i++)
            {
                if (newSolider == i)
                {
                    Soldier soldier = new Soldier(typeSoldiers[i].Name, typeSoldiers[i].Damage, typeSoldiers[i].Health);
                    return soldier;
                }
            }

            return null;
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

        public bool CanUseSpecialAttack(Soldier soldier)
        {
            int rangeMaximalNumbers = 100;
            int chanceUsingAbility = _random.Next(rangeMaximalNumbers);
            int chanceAbility = 100;
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