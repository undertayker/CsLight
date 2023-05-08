using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T52
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Country country = new Country();
            country.Work();               
        }
    }

    class Country
    {
        private List<Criminal> _criminals = new List<Criminal>();
        
        public Country()
        {
            _criminals.Add(new Criminal("Котович Андрей Валерьевич", "Антиправительственное преступление"));
            _criminals.Add(new Criminal("Смирнов Александр Владимирович", "Уголовное преступление"));
            _criminals.Add(new Criminal("Петров Владимер Андреевич", "Административное преступление"));
            _criminals.Add(new Criminal("Волков Анатолий Сергеевич", "Уголовное преступление"));
            _criminals.Add(new Criminal("Котович Андрей Валерьевич", "Антиправительственное преступление"));
        }

        public void Work()
        {
            Console.WriteLine("Добро пожаловать в Информационный центр\nСписок приступников до амнистии");
            ShowCriminals();
            Console.WriteLine("\nНажмите любую клавишу что бы посмотреть список приступников после амнистии\n");
            Console.ReadKey();
            AmnestyCriminals();            
        }

        private void AmnestyCriminals()
        {
            string nonpaymentTaxes = "Антиправительственное преступление";

            var filteredCriminals =  from Criminal criminal in _criminals where criminal.Offence != nonpaymentTaxes select criminal;

            _criminals = filteredCriminals.ToList();
            
            ShowCriminals();
        }

        private void ShowCriminals()
        {
            foreach (var criminal in _criminals)
            {
                criminal.ShowCriminal();
            }
        }
    }

    class Criminal
    {
        public Criminal(string name, string offence)
        {
            Name = name;
            Offence = offence;
        }

        public string Name { get; private set; }
        public string Offence { get; private set; }

        public void ShowCriminal()
        {
            Console.WriteLine($"{Name} | Преступление : {Offence}");
        }
    }
}
