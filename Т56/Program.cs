using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Т56
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Army army = new Army();
            army.Work();
        }
    }

    class Army
    {
        private List<Soldier> _soldiers = new List<Soldier>();
        
        public Army()
        {
            _soldiers.Add(new Soldier("Александр", "Дробовик", "Рядовой", 14));
            _soldiers.Add(new Soldier("Андрей", "Снайперская винтовка", "Лейтенант", 6));
            _soldiers.Add(new Soldier("Виктор", "Пулемет", "Прапорщик", 8));
            _soldiers.Add(new Soldier("Давид", "Гранатомет", "Старший Сержант", 10));
            _soldiers.Add(new Soldier("Дмитрий", "Автомат Колашникова", "Сержант", 14));
        }

        public void Work()
        {
            Console.WriteLine("Вся информация по солдатам !!\n");
            ShowInfo();
            Console.WriteLine("\nНажмите любую клавишу что бы посмотреть сокращенную информацию по солдатам !\n");
            Console.ReadKey();
            AbbreviatedInformationSoldier();
        }

        private void AbbreviatedInformationSoldier()
        {
            var abbreviatedInformation = from Soldier soldier in _soldiers select new {Name = soldier.Name, Rank = soldier.Rank};

            foreach (var soldier in abbreviatedInformation)
            {
                Console.WriteLine($"{soldier.Name} , Звание - {soldier.Rank}");
            }
        }

        private void ShowInfo()
        {
            foreach (var soldier in _soldiers)
            {
                soldier.ShowInfo();
            }
        }
    }

    class Soldier
    {
        public Soldier(string name, string armament, string rank, int lifeTime)
        {
            Name = name;
            Armament = armament;
            Rank = rank;
            LifeTime = lifeTime;
        }

        public string Name { get; private set; }
        public string Armament { get; private set; }
        public string Rank { get; private set; }
        public int LifeTime { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} , Вооружение : {Armament} , Звание : {Rank} , Срок службы : {LifeTime} месяцев");
        }
    }
}
