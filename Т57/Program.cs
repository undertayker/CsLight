using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Т57
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
        private List<Soldier> _firstDachmentSoldier = new List<Soldier>();

        private List<Soldier> _secondDachmentSoldier = new List<Soldier>();

        public Army()
        {
            _firstDachmentSoldier.Add(new Soldier("Кострамин"));
            _firstDachmentSoldier.Add(new Soldier("Бобров"));
            _firstDachmentSoldier.Add(new Soldier("Соколов"));
            _firstDachmentSoldier.Add(new Soldier("Скворцов"));
            _firstDachmentSoldier.Add(new Soldier("Бородач"));

            _secondDachmentSoldier.Add(new Soldier("Петров"));
            _secondDachmentSoldier.Add(new Soldier("Морозов"));
            _secondDachmentSoldier.Add(new Soldier("Яковлев"));
        }
        
        public void Work()
        {
            Console.WriteLine("Солдаты первого отряда !!\n");
            ShowInfoFirstDachment();

            Console.WriteLine("\nСолдаты второго отряда !!\n");
            ShowInfoSecondDachment();

            Console.WriteLine("\nСолдаты объединенного отряда!\n");
            UnificationDetachments();
        }

        public void UnificationDetachments()
        {
            var selectSoldiers = _firstDachmentSoldier.Where(soldier => soldier.Name.StartsWith("Б"));

            var unionTwoTeams = _secondDachmentSoldier.Union(selectSoldiers);

            _firstDachmentSoldier = _firstDachmentSoldier.Except(selectSoldiers).ToList();

            ShowInfo(unionTwoTeams);
        }

        private static void ShowInfo(IEnumerable<Soldier> unionTwoTeams)
        {
            foreach (var soldier in unionTwoTeams)
            {
                Console.WriteLine(soldier.Name);
            }
        }

        public void ShowInfoFirstDachment()
        {
            ShowInfo(_firstDachmentSoldier);
        }

        public void ShowInfoSecondDachment()
        {
            ShowInfo(_secondDachmentSoldier);
        }
    }

    class Soldier
    {
        public Soldier(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя :{Name}");
        }
    }
}
