using System;
using System.Collections.Generic;
using System.Linq;

namespace Т55
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            stock.Work();
        }
    }

    class Stock
    {
        private List<Stew> _stews = new List<Stew>();

        private int _currentYear = 2023;

        public Stock()
        {
            _stews.Add(new Stew("Свинная", 2005, 20));
            _stews.Add(new Stew("Свинная", 1994, 18));
            _stews.Add(new Stew("Свинная", 2004, 20));
            _stews.Add(new Stew("Свинная", 1986, 19));
            _stews.Add(new Stew("Свинная", 1999, 17));
            _stews.Add(new Stew("Говяжья", 2004, 20));
            _stews.Add(new Stew("Говяжья", 1989, 19));
            _stews.Add(new Stew("Говяжья", 2005, 20));
            _stews.Add(new Stew("Говяжья", 2001, 18));
            _stews.Add(new Stew("Говяжья", 2006, 18));
        }

        public void Work()
        {
            Console.WriteLine("Вся тушенка на складе !!\n");
            ShowInfo();
            Console.WriteLine("\nЧто бы получить все просроченные банки тушенки нажми любую клавишу!\n");
            Console.ReadKey();
            ShowSpoiledStew();
        }

        private void ShowSpoiledStew()
        {
            _stews = _stews.Where(stew => stew.ProductionYear + stew.BestBeforeDate <= _currentYear).ToList();

            ShowInfo();
        }

        private void ShowInfo()
        {
            foreach (var stew in _stews)
            {
                stew.ShowInfo();
            }
        }
    }

    class Stew
    {
        public Stew(string name, int productionYear, int bestBeforeDate)
        {
            Name = name;
            ProductionYear = productionYear;
            BestBeforeDate = bestBeforeDate;
        }

        public string Name { get; private set; }
        public int ProductionYear { get; private set; }
        public int BestBeforeDate { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} , Сделана в {ProductionYear} году, Срок годности {BestBeforeDate} лет !");
        }
    }
}
