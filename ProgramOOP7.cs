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
            Dispacher dispacher = new Dispacher();
            dispacher.Work();
        }
    }

    class Dispacher
    {
        private List<Wagon> _wagons = new List<Wagon>();
        private List<Train> _trains = new List<Train>();
        public int TicketsCount { get; private set; }

        public void Work()
        {
            bool isWorking = true;

            while (isWorking)
            {
                if (_trains.Count == 0)
                {
                    Console.WriteLine("В очереди нет поездов !!!");
                    Console.WriteLine("Составление поезда ");
                    CreateTrain();
                }
                else
                {
                    for (int i = 0; i < _trains.Count; i++)
                    {
                        _trains[i].ShowInfo();
                        SendTrain();
                    }
                }
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void CreateTrain()
        {
            Console.Write("Введите точку отправления поезда : ");
            string inputBoardingPoint = Console.ReadLine();

            Console.Write("Введите точку прибытия поезда :");
            string inputDropOffPoint = Console.ReadLine();

            SellTickets();

            _trains.Add(new Train(inputBoardingPoint, inputDropOffPoint, TicketsCount));
            int countFreePlaceTrain = 0;

            while (countFreePlaceTrain < TicketsCount)
            {
                _trains[0].CreateWagons(ref countFreePlaceTrain);
            }
        }

        private void SendTrain()
        {
            Console.WriteLine("Нажмите любую клавишу для отправки поезда !");
            Console.ReadKey();

            for (int i = 0; i < _trains.Count; i++)
            {
                Console.WriteLine($"Поезд {_trains[i].Route} отправлен !");
                _trains.RemoveAt(i);
            }
        }

        private void SellTickets()
        {
            Random random = new Random();

            int minPassengerCount = 20;
            int maxPassengerCount = 58;

            TicketsCount = random.Next(minPassengerCount, maxPassengerCount);

            Console.WriteLine($"Продано {TicketsCount} билетов ");
        }
    }

    class Train
    {
        private List<Wagon> _wagons = new List<Wagon>();
        public int WagonsCount { get; private set; }
        public int PassengerCount { get; private set; }
        public string Route { get; private set; }

        public Train(string boardingPoint, string dropOffPoint, int passengerCount)
        {
            PassengerCount = passengerCount;
            Route = boardingPoint + " - " + dropOffPoint;
            WagonsCount = _wagons.Count;
        }

        public void CreateWagons(ref int countFreePlaceTrain)
        {
            _wagons.Add(new Wagon());

            for (int i = _wagons.Count - 1; i < _wagons.Count; i++)
            {
                countFreePlaceTrain += _wagons[i].CountFreePlace;
                Console.WriteLine($"Вместимость {i + 1 } вагона - {_wagons[i].CountFreePlace} мест");
                WagonsCount = _wagons.Count;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Рейс {Route} | {PassengerCount} пассажиров | Выделено {WagonsCount} вагона");
        }
    }

    class Wagon
    {
        public int CountFreePlace { get; private set; }

        public Wagon()
        {
            Random random = new Random();
            int minCountFreePlace = 10;
            int maxCountFreePlace = 20;
            CountFreePlace = random.Next(minCountFreePlace, maxCountFreePlace);
        }
    }
}