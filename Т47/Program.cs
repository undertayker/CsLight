using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Т47
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Battlefield battlefield = new Battlefield();
            battlefield.Battle();
        }
    }

    class Battlefield
    {
        private Platoon _platoonLight = new Platoon();
        private Platoon _platoonDark = new Platoon();
        private Soldier _firstSolider;
        private Soldier _secondSolider;

        public void Battle()
        {
            Console.WriteLine("Бой сил Света и Тьмы, Нажмите любую кнопку для начала битвы!");
            Console.ReadKey();

            while (_platoonLight.GetCountSoldiers() > 0 && _platoonDark.GetCountSoldiers() > 0)
            {
                _firstSolider = _platoonLight.GetSoldierFromPlatoon();
                _secondSolider = _platoonDark.GetSoldierFromPlatoon();
                _platoonLight.ShowPlatoon();
                _platoonDark.ShowPlatoon();
                _firstSolider.TakeDamage(_secondSolider.Damage);
                _secondSolider.TakeDamage(_firstSolider.Damage);
                _firstSolider.UseSpecialAttack();
                _secondSolider.UseSpecialAttack();
                RemoveSolider();
                System.Threading.Thread.Sleep(1000);                
                Console.Clear();            
            }

            ShowBattleResult();
        }

        private void ShowBattleResult()
        {
            if (_platoonLight.GetCountSoldiers() > 0 && _platoonDark.GetCountSoldiers() > 0)
            {
                Console.WriteLine("Ничья, оба взвода погибли!!!");
            }
            else if (_platoonLight.GetCountSoldiers() <= 0)
            {
                Console.WriteLine("Взвод сил Тьмы победил!!!");
            }
            else if (_platoonDark.GetCountSoldiers() <= 0)
            {
                Console.WriteLine("Взвод сил Света победил!!!");
            }
        }

        private void RemoveSolider()
        {
            if (_firstSolider.Health <= 0)
            {
                _platoonLight.RemoveSoldierFromPlatoon(_firstSolider);
            }

            if (_secondSolider.Health <= 0)
            {
                _platoonDark.RemoveSoldierFromPlatoon(_secondSolider);
            }
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers = new List<Soldier>();
        private static Random _random = new Random();

        public Platoon()
        {
            CreateNewPlatoon(10, _soldiers);
        }

        public void ShowPlatoon()
        {
            Console.WriteLine("Взвод");

            foreach (var soldier in _soldiers)
            {
                Console.WriteLine($"{soldier.Name}. Здоровье : {soldier.Health}. Урон : {soldier.Damage}.");
            }
        }

        public void RemoveSoldierFromPlatoon(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        public Soldier GetSoldierFromPlatoon()
        {
            return _soldiers[_random.Next(0, _soldiers.Count)];
        }

        public int GetCountSoldiers()
        {
            return _soldiers.Count;
        }

        private void CreateNewPlatoon(int numbeersOfSoldiers, List<Soldier> soldier)
        {
            for (int i = 0; i < numbeersOfSoldiers; i++)
            {
                soldier.Add(GetSoldier());
            }
        }

        private Soldier GetSoldier()
        {
            int minimumNumbersSoldier = 0;
            int maximumNumberSoldier = 3;

            int newSoldier = _random.Next(minimumNumbersSoldier, maximumNumberSoldier);

            if (newSoldier == 1)
            {
                return new Sniper("Снайпер", 100, 50);
            }
            else if (newSoldier == 2)
            {
                return new GrenadeLauncher("Гранатометчик", 100, 60);
            }
            else
            {
                return new Medic("Медик", 100, 45);
            }
        }
    }

    class Soldier
    {
        public Soldier(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        public int Health { get; protected set; }

        public void TakeDamage(int damageSoldier)
        {
            Health -= damageSoldier;
            Console.WriteLine($"\n{Name} нанес - {damageSoldier} урона !");
        }

        public void UseSpecialAttack()
        {
            Random random = new Random();
            int MaximalNumber = 100;
            int chanceUsingAbility = random.Next(MaximalNumber);
            int chanceAbillity = 10;

            if (chanceUsingAbility < chanceAbillity)
            {
                UsePower();
            }
        }

        protected virtual void UsePower() { }
    }

    class Sniper : Soldier
    {
        private int _damageBuff = 10;

        public Sniper(string name, int health, int damage) : base(name, health, damage) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} делает глубойкий вдох, задерживает дыхание и стреляет точнее !");
            Damage += _damageBuff;
        }
    }

    class Medic : Soldier
    {
        private int _damageBuff = 100;

        public Medic (string name, int health, int damage) : base (name, health, damage) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} Достает дефибрилятор и поражает противника эл.током !");
            Damage += _damageBuff;
        }
    }

    class GrenadeLauncher : Soldier
    {
        private int _damageBuff = 100;

        public GrenadeLauncher(string name, int health, int damage) : base(name, health, damage) { }

        protected override void UsePower()
        {
            Console.WriteLine($"{Name} Стреляет с гранатомета и наносит большой урон!");
            Damage += _damageBuff;
        }
    }
}
