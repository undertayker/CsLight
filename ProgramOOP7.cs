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
        private readonly List<Train> _trains = new List<Train>();
        private static readonly Random _random = new Random();

        public void Work()
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("На станции нет поездов !!!");
                Console.WriteLine("Создание поезда ");

                Train train = CreateTrain();
                _trains.Add(train);

                SendTrain(_trains[_trains.Count - 1]);

                Console.WriteLine();
                ShowTrains();
                Console.WriteLine();
            }
        }

        private void ShowTrains()
        {
            foreach (var train in _trains)
            {
                Console.WriteLine("Отправлен поезд : " + train.Route);
            }
        }

        private Train CreateTrain()
        {
            Console.WriteLine("Введите станцию отправления поезда : ");
            string inputBoardingPoint = Console.ReadLine();

            Console.WriteLine("Введите станцию прибытия поезда : ");
            string inputDropOffPoint = Console.ReadLine();

            int tickets = SellTickets();

            var train = new Train(inputBoardingPoint, inputDropOffPoint, tickets);

            while (train.FreePlaces < tickets)
            {
                train.CreateWagons();
            }

            return train;
        }

        private void SendTrain(Train train)
        {
            Console.WriteLine("Нажмите любую клавишу для отправки поезда !");
            Console.ReadKey();

            Console.WriteLine($"Поезд {train.Route} отправлен !!");
            train.SetSend();
        }

        private int SellTickets()
        {
            int minPassangerCount = 10;
            int maxPassangerCount = 58;

            int tickets = _random.Next(minPassangerCount, maxPassangerCount);

            Console.WriteLine($"Продано {tickets} билетов ");

            return tickets;
        }
    }

    class Train
    {
        private List<Wagon> _wagons = new List<Wagon>();

        public Train(string boardingPoint, string dropOffPoint, int passengerCount)
        {
            PassangerCount = passengerCount;
            Route = boardingPoint + " - " + dropOffPoint;
            WagonsCount = _wagons.Count;
        }

        public int FreePlaces { get; private set; }
        public int WagonsCount { get; private set; }
        public int PassangerCount { get; private set; }
        public string Route { get; private set; }
        public bool Send { get; private set; }

        public void CreateWagons()
        {
            _wagons.Add(new Wagon());

            for (int i = _wagons.Count -1; i < _wagons.Count; i++)
            {
                FreePlaces += _wagons[i].CountFreePlace;
                Console.WriteLine($"Вместимость {i + 1} вагона -  {_wagons[i].CountFreePlace}");
                WagonsCount = _wagons.Count;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Рейс :{Route}\nПассажиров :{PassangerCount}\nВыделено ваговов :{WagonsCount}");
        }

        public void SetSend()
        {
            Send = true;
        }
    }

    class Wagon
    {
        private static Random random = new Random();

        public Wagon()
        {
            int minCountFreePlace = 10;
            int maxCountFreePlace = 20;
            CountFreePlace = random.Next(minCountFreePlace, maxCountFreePlace);
        }

        public int CountFreePlace { get; private set; }
    }
}

