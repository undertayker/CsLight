using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T46
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket();

            const string CreateCustomerQueue = "1";
            const string ServeLineOfCustomers = "2";
            const string Exit = "3";
            bool isWork = true;

            Console.WriteLine("Добро пожаловать в программу администрирования супермаркета" +
                            "\nВзглянить на ваше меню и открывайте кассу для того что бы клиенты выстраивались в очередь!");

            while (isWork)
            {
                Console.WriteLine($"{CreateCustomerQueue} - Создать очередь клиентов" +
                    $"\n{ServeLineOfCustomers} - Обслужить очередь клиентов" +
                    $"\n{Exit} - Выход");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CreateCustomerQueue:
                        supermarket.CreateClientQueue();
                        break;

                    case ServeLineOfCustomers:
                        supermarket.ServeClient();
                        break;

                    case Exit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неверный ввод!!!");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Supermarket
    {
        private Queue<Client> _clients = new Queue<Client>();
        private List<Product> _products = new List<Product>();
        private Random _random = new Random();

        public Supermarket()
        {
            _products.Add(new Product("Хлеб", GetCostProduct()));
            _products.Add(new Product("Молоко", GetCostProduct()));
            _products.Add(new Product("Кефир", GetCostProduct()));
            _products.Add(new Product("Колбаса", GetCostProduct()));
            _products.Add(new Product("Сосиски", GetCostProduct()));
            _products.Add(new Product("Майонез", GetCostProduct()));
            _products.Add(new Product("Кетчуп", GetCostProduct()));
            _products.Add(new Product("Яблоки", GetCostProduct()));
            _products.Add(new Product("Картофель", GetCostProduct()));
            _products.Add(new Product("Макароны", GetCostProduct()));
        }

        public void CreateClientQueue()
        {
            int minimumCountClient = 2;
            int maximumCountClient = 10;
            int countClient = _random.Next(minimumCountClient, maximumCountClient);

            for (int i = 0; i < countClient; i++)
            {
                _clients.Enqueue(GetClient());
            }

            Console.WriteLine($"Очередь создана, в очереди {countClient} человек\n" +
                $"Нажмите любую клавишу и перейдите к обслуживанию клиентов !");
        }

        public void ServeClient()
        {
            while (_clients.Count > 0)
            {
                _clients.Dequeue().PurchaseProducts();
            }
        }

        private Client GetClient()
        {
            List<Product> products = new List<Product>();

            int minimumCountProduct = 2;
            int maximumCountProduct = 10;
            int minimumCountMoney = 10;
            int maximumCountMoney = 100;
            int countMoney = _random.Next(minimumCountMoney, maximumCountMoney);
            int countProduct = _random.Next(minimumCountProduct, maximumCountProduct);

            for (int i = 0; i < countProduct; i++)
            {
                products.Add(_products[_random.Next(0, _products.Count - 1)]);
            }

            return new Client(countMoney, products);
        }

        private int GetCostProduct()
        {
            int minimumCostProduct = 5;
            int maximumCostProduct = 25;
            int costProduct = _random.Next(minimumCostProduct, maximumCostProduct);
            return costProduct;
        }
    }

    class Product
    {
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; private set; }
        public int Cost { get; private set; }
    }

    class Client
    {
        private List<Product> _productsInBasket;
        private int _money;

        public Client(int money, List<Product> productsInBasket)        {
            _productsInBasket = productsInBasket;
            _money = money;
        }

        public void PurchaseProducts()
        {
            Random random = new Random();
            int purchaseAmount = GetEntireBasketCost();
            ShowProductsBasket();
            Console.WriteLine($"Итоговая сумма товаров {purchaseAmount} рублей. У клиента {_money} рублей");

            if (_money >= purchaseAmount)
            {
                Console.WriteLine($"Клиент оплатил товары на сумму {purchaseAmount} рублей и покинул магазин !");
            }
            else
            {
                RemoveUnnecessaryProductsClient();
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void RemoveUnnecessaryProductsClient()
        {
            while (GetEntireBasketCost() >= _money)
            {
                RemoveProduct();
            }
        }

        private void RemoveProduct()
        {
            Random random = new Random();
            int index = random.Next(0, _productsInBasket.Count);
            Product productToRemove = _productsInBasket[index];
            Console.WriteLine($"Клиент отказался от товара {productToRemove.Name} стоимостью {productToRemove.Cost} рублей ");
            _productsInBasket.Remove(productToRemove);
        }

        private int GetEntireBasketCost()
        {
            int purchaseAmount = 0;

            foreach (var product in _productsInBasket)
            {
                purchaseAmount += product.Cost;
            }

            return purchaseAmount;
        }

        private void ShowProductsBasket()
        {
            Console.WriteLine("В корзине клиента находятся такие товары как :");

            foreach (var item in _productsInBasket)
            {
                Console.WriteLine($"{item.Name}, стоимостью : {item.Cost} рублей");
            }
        }
    }
}