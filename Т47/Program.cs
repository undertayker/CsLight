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
                Console.WriteLine(new string('-', 40));
                _secondPlatoon.ShowInfo();

                _firstSoldier.Attack(_secondSoldier);
                _secondSoldier.Attack(_firstSoldier);

                DeliteDeadSoldiers();
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

        private void DeliteDeadSoldiers()
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

        private List<Soldier> _soldiers = new List<Soldier>();

        public PlatoonCreator()
        {
            _soldiers.Add(new Sniper("Снайпер", 50, 100));
            _soldiers.Add(new Engineer("Инжeнер", 45, 100));
            _soldiers.Add(new Medic("Медик", 40, 100));
        }

        public List<Soldier> CreateSoldiers()
        {
            int maxCount = 10;
            int minCount = 9;
            int count = _random.Next(minCount, maxCount + 1);

            List<Soldier> newSoldiers = new List<Soldier>();

            for (int i = 0; i < count; i++)
            {
                Soldier soldier = _soldiers[_random.Next(_soldiers.Count)].Clone();
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

        public Soldier()
        {
            Name = "Дух";
            Damage = 0;
            Health = 1;
        }

        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        public int Health { get; protected set; }

        public virtual void Attack(Soldier soldier)
        {
            soldier.TakeDamage(Damage);
        }

        public virtual bool CanUseSkill(int percent)
        {
            int maxSkillChance = 100;
            int chance = _random.Next(maxSkillChance + 1);

            return percent > chance;
        }

        public virtual Soldier Clone()
        {
            return new Soldier();
        }

        public virtual void TakeDamage(int damageSoldier)
        {
            Health -= damageSoldier;
            Console.WriteLine();
            Console.WriteLine($"{Name} нанес {Damage} урона, а получил {damageSoldier} урона");
        }
    }

    class Sniper : Soldier
    {
        private int _specialSkillChance = 34;
        private int _damageBuff = 40;

        public Sniper(string name, int damage, int health) : base(name, damage, health) { }

        public override Soldier Clone()
        {
            return new Sniper("Снайпер", 50, 100);
        }

        public override void Attack(Soldier soldier)
        {
            if (CanUseSkill(_specialSkillChance))
            {
                Console.WriteLine($"\n{Name} выстрелил точно в голову, урона  нанесено {Damage} ");
                Damage += _damageBuff;
            }
            else
            {
                base.Attack(soldier);
            }
        }
    }

    class Engineer : Soldier
    {
        private int _dodgeChance = 34;

        public Engineer(string name, int damage, int health) : base(name, damage, health) { }

        public override Soldier Clone()
        {
            return new Engineer("Инженер", 45, 100);
        }

        public override void TakeDamage(int damageSolider)
        {
            int damageReduction = 2;
            int blockedDamage = damageSolider / damageReduction;

            if (CanUseSkill(_dodgeChance))
            {
                Health -= damageSolider / damageReduction;
                Console.WriteLine($"\nИнженер ставит щит блокируя урон , заблокировано {blockedDamage}");
            }
            else
            {
                base.TakeDamage(damageSolider);
            }
        }
    }

    class Medic : Soldier
    {
        private int _healthBuff = 20;
        private int _chanceToHeal = 34;

        public Medic(string name, int damage, int health) : base(name, damage, health) { }

        public override Soldier Clone()
        {
            return new Medic("Медик", 40, 100);
        }

        public override void TakeDamage(int damageSolider)
        {
            if (CanUseSkill(_chanceToHeal))
            {
                Console.WriteLine($"{Name} перебинтовывается , увеличивая здоровье");
                Health += _healthBuff;
            }
            else
            {
                base.TakeDamage(damageSolider);
            }
        }
    }
}