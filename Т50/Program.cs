using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Т50
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarServise carServise = new CarServise();
            carServise.Start();
        }
    }

    class CarServise
    {
        private const string StartCommand = "start";
        private const string ExitCommand = "exit";
        private const string RepairCommand = "repair";
        private const string RefuseCommand = "refuse";

        private Storage _storage = new Storage();
        private Queue<Car> _cars = new Queue<Car>();
        private int _carsQueueSize = 6;
        private int _totalMoney = 1500;

        public void Start()
        {
            bool isWorking = true;
            CreateCars();

            while (isWorking && _cars.Count > 0)
            {
                _storage.ShowAvailableDetails();
                Console.WriteLine();

                Console.WriteLine($"На балансе автосервиса - {_totalMoney} рублей ");
                Console.WriteLine($"В очереди на ремонт стоят - {_cars.Count} машин ");

                Console.WriteLine($"\n{StartCommand} - Начать работу автосервиса\n\n{ExitCommand} - завершить работу автосервиса");
                Console.WriteLine("\nВаши действия :");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case StartCommand:
                        ServiceCar();
                        break;

                    case ExitCommand:
                        isWorking = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка при вводе!!!");
                        break;
                }
            }
        }

        private void ServiceCar()
        {
            _storage.ShowAvailableDetails();
            Console.WriteLine();

            Car currentCar = _cars.Dequeue();
            ShowBrokenPart(currentCar);
            Console.WriteLine();

            Console.WriteLine($"{RepairCommand} - отремантировать машину\n{RefuseCommand} - отказать в ремонте\nВаши действия :");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case RepairCommand:
                    RepairCar(currentCar);
                    break;

                case RefuseCommand:
                    RefuseRepair();
                    break;

                default:
                    Console.WriteLine("Ошибка при вводе!!");
                    RefuseRepair();
                    break;
            }
        }

        private int GetRepairPrice(Detail brokenPart)
        {
            int totalRepairPrice = 0;
            int serviceCosr = 400;

            totalRepairPrice += brokenPart.Price + serviceCosr;

            return totalRepairPrice;
        }

        private int GetPenalty(Detail brokenPart)
        {
            return brokenPart.Price;
        }

        private bool TryToRapair(Car car)
        {
            _storage.ShowAvailableDetails();

            Console.WriteLine("Какую деталь вы выберите для замены ?");

            string userInput = Console.ReadLine();
            Detail requiredDetail = new Detail(userInput, 0);

            return _storage.RetutnFoundedDetail(requiredDetail) == true && car.BrokenPart.Name == userInput;
        }

        private void CreateCars()
        {
            for (int i = 0; i < _carsQueueSize; i++)
            {
                _cars.Enqueue(new Car());
            }
        }

        private void ShowBrokenPart(Car car)
        {
            Console.WriteLine($"В вашей машине нужно заменить : {car.BrokenPart.Name}");
            Console.WriteLine($"Cтоимость замены деталей с учетом работы {GetRepairPrice(car.BrokenPart)} рублей");
        }

        private void RepairCar(Car car)
        {
            Console.Clear();

            if (TryToRapair(car))
            {
                Console.WriteLine("Автомобиль успешно отремантирован!");
                Console.WriteLine($"Вы заработали : {GetRepairPrice(car.BrokenPart)} рублей\n");

                _totalMoney += GetRepairPrice(car.BrokenPart);
            }
            else
            {
                Console.WriteLine("Вы поменяли не ту деталь!!!");
                Console.WriteLine($"Вас оштрафовали на : {GetPenalty(car.BrokenPart)} рублей\n ");

                _totalMoney -= GetPenalty(car.BrokenPart);
            }
        }

        private void RefuseRepair()
        {
            int fine = 400;
            Console.Clear();
            Console.WriteLine($"Вы не отремантировали машину, с вас списан штраф в размере {fine} рублей\n");
            _totalMoney -= fine;
        }
    }

    class Storage
    {
        private List<Detail> _allDetails = new List<Detail>();
        private List<Detail> _generatedDetails = new List<Detail>();
        private Random _random = new Random();

        private int _numberDetails = 14;

        public Storage()
        {
            Fill();
        }

        public bool RetutnFoundedDetail(Detail requiredDetail)
        {
            if (IsDetailFounded(requiredDetail))
            {
                _generatedDetails.Remove(requiredDetail);

                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowAvailableDetails()
        {
            Console.WriteLine("На складе остались следующие детали : ");

            foreach (Detail detail in _generatedDetails)
            {
                Console.WriteLine($"Деталь - {detail.Name}, Цена - {detail.Price}");
            }
        }

        private void Fill()
        {
            CreateDetailsList();

            for (int i = 0; i < _numberDetails; i++)
            {
                _generatedDetails.Add(_allDetails[_random.Next(_allDetails.Count)]);
            }
        }

        private void CreateDetailsList()
        {
            _allDetails.Add(new Detail("Двигатель", 4000));
            _allDetails.Add(new Detail("Амортизатор", 3000));
            _allDetails.Add(new Detail("Омывайка", 700));
            _allDetails.Add(new Detail("Комплект колес", 4000));
            _allDetails.Add(new Detail("Лобое стекло", 1000));
            _allDetails.Add(new Detail("Комплект рычагов", 2000));
            _allDetails.Add(new Detail("Комплект фильтров", 1000));
        }

        private bool IsDetailFounded(Detail requiredDetail)
        {
            foreach (Detail detail in _generatedDetails)
            {
                if (requiredDetail.Name == detail.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }

    class Car
    {
        private static Random _random = new Random();
        private List<Detail> _details = new List<Detail>();

        public Car()
        {
            CreateDetailsList();
            CreateBrokenPart();
        }

        public Detail BrokenPart { get; private set; }

        private void CreateDetailsList()
        {
            _details.Add(new Detail("Двигатель", 4000));
            _details.Add(new Detail("Амортизатор", 3000));
            _details.Add(new Detail("Омывайка", 700));
            _details.Add(new Detail("Комплект колес", 2000));
            _details.Add(new Detail("Лобое стекло", 1000));
            _details.Add(new Detail("Комплект рычагов", 2000));
            _details.Add(new Detail("Комплект фильтров", 1000));
        }

        private void CreateBrokenPart()
        {
            BrokenPart = _details[_random.Next(_details.Count)];
        }
    }

    class Detail
    {
        public Detail(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
    }
}
