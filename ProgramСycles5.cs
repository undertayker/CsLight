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
            float rubToUsd = 60;         
            float usdToRub = 61;
            float rubToEur = 61;
            float eurToRub = 61;
            float usdToEur = 1;
            float eurToUsd = 1;
            float balanceOfRubles;
            float balanceOfDollars;
            float balanceOfTheEuro;
            float moneyReceived;

            string userInput;
            float currencyCount;
            bool bankOpening = true;
            string exit = "выход";
            string number1 = "rub-usd";
            string number2 = "usd-rub";
            string number3 = "rub-eur";
            string number4 = "eur-rub";
            string number5 = "usd-eur";
            string number6 = "eur-usd";

            Console.WriteLine("Добро пожаловать в наш банк, у нас вы можете обменять следующие валюты : ");
            Console.WriteLine("Рубли в доллары, доллары в рубли, рубли в евро, евро в рубли, доллары в евро и евро в доллары. ");
            Console.WriteLine("Для выхода из банка введите слово : " + exit);
            Console.WriteLine("Для продолжения введите ваш баланс. ");

            while (bankOpening)
            {
                Console.Write("Введите ваш баланс рублей : ");
                balanceOfRubles = Convert.ToSingle(Console.ReadLine());
                Console.Write("Введите ваш баланс долларов : ");
                balanceOfDollars = Convert.ToSingle(Console.ReadLine());
                Console.Write("Введите ваш баланс евро : ");
                balanceOfTheEuro = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine("Что бы обменять рубли на доллары введите : " + number1);
                Console.WriteLine("Что бы обменять доллары на рубли введите : " + number2);
                Console.WriteLine("Что бы обменять рубли на евро введите : " + number3);
                Console.WriteLine("Что бы бменять евро на рубли введите : " + number4);
                Console.WriteLine("Что бы обменять доллары на евро введите : " + number5);
                Console.WriteLine("Что бы обменять евро на доллары введите : " + number6);
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "rub-usd":
                        Console.WriteLine("Вы хотите обменять рубли на доллары. ");
                        Console.Write("Сколько рублей вы хотите обменять ? : ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceOfRubles >= currencyCount)
                        {
                            balanceOfRubles -= currencyCount;
                            moneyReceived = currencyCount * rubToUsd;
                            balanceOfDollars += moneyReceived;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств. ");
                        }
                        break;
                    case "usd-rub":
                        Console.WriteLine("Вы хотите обменять доллары на рубли. ");
                        Console.WriteLine("Сколько долларов вы хотите обменять ?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceOfDollars >= currencyCount)
                        {
                            balanceOfDollars -= currencyCount;
                            moneyReceived = usdToRub;
                            balanceOfRubles += moneyReceived;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств ");
                        }
                        break;
                    case "rub-eur":
                        Console.WriteLine("Вы хотите обменять рубли на евро. ");
                        Console.WriteLine("Сколько рублей вы хотите обменять ?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceOfRubles >= currencyCount)
                        {
                            balanceOfRubles -= currencyCount;
                            moneyReceived = currencyCount * rubToEur; 
                            balanceOfTheEuro += moneyReceived;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств ");
                        }
                        break;
                    case "eur-rub":
                        Console.WriteLine("Вы хотите обменять евро на рубли. ");
                        Console.WriteLine("Сколько евро вы хотите обменять ? ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceOfTheEuro >= currencyCount)
                        {
                            balanceOfTheEuro -= currencyCount;
                            moneyReceived = currencyCount * eurToRub;
                            balanceOfRubles += moneyReceived;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств ");
                        }
                        break;
                    case "usd-eur":
                        Console.WriteLine("Вы хотите обменять доллары на евро. ");
                        Console.WriteLine("Сколько долларов вы хотите обменять ?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceOfDollars >= currencyCount)
                        {
                            balanceOfDollars -= currencyCount;
                            moneyReceived = currencyCount * usdToEur;
                            balanceOfTheEuro += moneyReceived;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств ");
                        }
                        break;
                    case "eur-usd":
                        Console.WriteLine("Вы хотите обменять евро на доллары. ");
                        Console.WriteLine("Сколько евро вы хотите обменять ?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceOfTheEuro >= currencyCount)
                        {
                            balanceOfTheEuro -= currencyCount;
                            moneyReceived = currencyCount * eurToUsd;
                            balanceOfDollars += moneyReceived;
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

                Console.WriteLine("Ваш баланс " + balanceOfRubles + " рублей " + balanceOfDollars + " долларов " + balanceOfTheEuro + " евро ");
                Console.ReadKey();
            }
        }
    }
}


