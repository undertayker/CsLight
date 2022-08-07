using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            float rubToUsd = 60, usdToRub = 60, rubToEur = 61, eurToRub = 61, usdToEur = 1, eurToUsd = 1;
            float rub;
            float usd;
            float eur;
            string userInput;
            float currencyCount;
            bool bankOpening = true;

            string number1 = "1";
            string number2 = "2";
            string number3 = "3";
            string number4 = "4";
            string number5 = "5";
            string number6 = "6";

            while (bankOpening)
            {
                Console.WriteLine("Добро пожаловать в наш банк, у нас вы можете обменять следующие валюты : ");
                Console.WriteLine("Рубли в доллары, доллары в рубли, рубли в евро, евро в рубли, доллары в евро и евро в доллары. ");
                Console.WriteLine("Для выхода из банка введите слово : выход ");
                Console.WriteLine("Для продолжения введите ваш баланс. ");

                Console.Write("Введите ваш баланс рублей : ");
                rub = Convert.ToSingle(Console.ReadLine());
                Console.Write("Введите ваш баланс долларов : ");
                usd = Convert.ToSingle(Console.ReadLine());
                Console.Write("Введите ваш баланс евро : ");
                eur = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine(number1 + " - Обменять рубли на доллары ");
                Console.WriteLine(number2 + " - Обменять доллары на рубли ");
                Console.WriteLine(number3 + " - Обменять рубли на евро ");
                Console.WriteLine(number4 + " - Обменять евро на рубли ");
                Console.WriteLine(number5 + " - Обменять доллары на евро ");
                Console.WriteLine(number6 + " - Обменять евро на доллары ");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Вы хотите обменять рубли на доллары. ");
                        Console.Write("Сколько рублей вы хотите обменять ? : ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (rub >= currencyCount)
                        {
                            rub -= currencyCount;
                            usd += currencyCount / rubToUsd;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств. ");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Вы хотите обменять доллары на рубли. ");
                        Console.WriteLine("Сколько долларов вы хотите обменять ?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            rub += currencyCount * usdToRub;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств ");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Вы хотите обменять рубли на евро. ");
                        Console.WriteLine("Сколько рублей вы хотите обменять ?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (rub >= currencyCount)
                        {
                            rub -= currencyCount;
                            eur += currencyCount / rubToEur;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств ");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Вы хотите обменять евро на рубли. ");
                        Console.WriteLine("Сколько евро вы хотите обменять ? ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (eur >= currencyCount)
                        {
                            eur -= currencyCount;
                            rub += currencyCount * eurToRub;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств ");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Вы хотите обменять доллары на евро. ");
                        Console.WriteLine("Сколько долларов вы хотите обменять ?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            eur += currencyCount * usdToEur;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств ");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Вы хотите обменять евро на доллары. ");
                        Console.WriteLine("Сколько евро вы хотите обменять ?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (eur >= currencyCount)
                        {
                            eur -= currencyCount;
                            usd += currencyCount * eurToUsd;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств ");
                        }
                        break;
                    case "выход":
                        bankOpening = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели недопустимую команду ");
                        break;
                }

                Console.WriteLine("Ваш баланс " + rub + " рублей " + usd + " долларов " + eur + " евро ");
                Console.ReadKey();
            }
        }
    }
}


