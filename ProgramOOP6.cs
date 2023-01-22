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
            Shop shop = new Shop();
            shop.Work();
        }
    }

    class Shop
    {
        private Seller _seller = new Seller(0);
        private Buyer _buyer = new Buyer(20);

        public void Work()
        {
            const string SeePlayerInventoryCommand = "1";
            const string SeeProductCommand = "2";
            const string BuyProductCommand = "3";
            const string ExitCommand = "4";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Ваш баланс - {_buyer.Money}\nБаланс продовца - {_seller.Money}\n" +
                    $"{SeePlayerInventoryCommand} - Посмотреть свой покет\n" +
                    $"{SeeProductCommand} - Посмотреть список товаров на прилавке\n" +
                    $"{BuyProductCommand} - Купить продукты\n" +
                    $"{ExitCommand} - Выйти из магазина");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case SeePlayerInventoryCommand:
                        _buyer.ShowProducts();
                        break;

                    case SeeProductCommand:
                        _seller.ShowProducts();
                        break;

                    case BuyProductCommand:
                        Trade();
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка ввода команды!!!");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void Trade()
        {
            _seller.ShowProducts();

            Console.Write("Введите номер товара который хотели бы преобрести :");
            string inputProduct = Console.ReadLine();

            if (int.TryParse(inputProduct, out int indexProduct) == false)
            {
                Console.WriteLine("Вы ввели некорректное значение !");
            }
            else if (_seller.TryGetProduct(indexProduct, out Product product))
            {
                if (_buyer.Money >= product.Cost)
                {
                    _buyer.BuyProduct(product);
                    _seller.SellProduct(product);
                }
                else
                {
                    Console.WriteLine($"Вам не хватает {product.Cost - _buyer.Money} рублей");
                }
            }
        }
    }

    class Human
    {
        protected List<Product> Products;

        public Human(int money)
        {
            Money = money;
        }

        public int Money { get; protected set; }

        public void ShowProducts()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Products[i].Name} - {Products[i].Cost} ");
            }
        }
    }

    class Seller : Human
    {
        public Seller(int money) : base(money)
        {
            Products = new List<Product>();

            Products.Add(new Product("Молоко", 2));
            Products.Add(new Product("Хлеб", 3));
            Products.Add(new Product("Ботон", 2));
            Products.Add(new Product("Колбаса", 10));
            Products.Add(new Product("Яйца", 5));
            Products.Add(new Product("Кефир", 4));
        }

        public bool TryGetProduct(int indexProduct, out Product product)
        {
            if (indexProduct < 1 || indexProduct > Products.Count)
            {
                Console.WriteLine("Вы ввели неверное число, попробуйте еще раз!!!");
                product = null;
                return false;
            }
            else
            {
                product = Products[indexProduct - 1];
                return true;
            }
        }

        public void SellProduct(Product product)
        {
            Money += product.Cost;
            Products.Remove(product);
        }
    }

    class Buyer : Human
    {
        public Buyer(int money) : base(money)
        {
            Products = new List<Product>();
        }

        public void BuyProduct(Product product)
        {
            Products.Add(product);
            Money -= product.Cost;
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
}