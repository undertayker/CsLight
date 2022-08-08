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
            float usdToRub = 61;
            float rubToUsd = 1 / usdToRub;
            float eurToRub = 61;
            float rubToEur = 1 / eurToRub;
            float usdToEur = 1;
            float eurToUsd = 1;
            float balanceOfRub;
            float balanceOfUsd;
            float balanceOfTheEur;
            float moneyReceived;

            string userInput;
            float currencyCount;
            bool isBankOpening = true;
            string exit = "выход";
            string exchangeRubToUsd = "rub-usd";
            string exchangeUsdToRub = "usd-rub";
            string exchangeRubToEur = "rub-eur";
            string exchangeEurToRub = "eur-rub";
            string exchangeUsdToEur = "usd-eur";
            string exchangeEurToUsd = "eur-usd";

            Console.WriteLine("Добро пожаловать в наш банк, у нас вы можете обменять следующие валюты : ");
            Console.WriteLine("Рубли в доллары, доллары в рубли, рубли в евро, евро в рубли, доллары в евро и евро в доллары. ");
            Console.WriteLine("Для выхода из банка введите слово : " + exit);
            Console.WriteLine("Для продолжения введите ваш баланс. ");

            while (isBankOpening)
            {
                Console.Write("Введите ваш баланс рублей : ");
                balanceOfRub = Convert.ToSingle(Console.ReadLine());
                Console.Write("Введите ваш баланс долларов : ");
                balanceOfUsd = Convert.ToSingle(Console.ReadLine());
                Console.Write("Введите ваш баланс евро : ");
                balanceOfTheEur = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine("Что бы обменять рубли на доллары введите : " + exchangeRubToUsd);
                Console.WriteLine("Что бы обменять доллары на рубли введите : " + exchangeUsdToRub);
                Console.WriteLine("Что бы обменять рубли на евро введите : " + exchangeRubToEur);
                Console.WriteLine("Что бы бменять евро на рубли введите : " + exchangeEurToRub);
                Console.WriteLine("Что бы обменять доллары на евро введите : " + exchangeUsdToEur);
                Console.WriteLine("Что бы обменять евро на доллары введите : " + exchangeEurToUsd);
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "rub-usd":
                        Console.WriteLine("Вы хотите обменять рубли на доллары. ");
                        Console.Write("Сколько рублей вы хотите обменять ? : ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (balanceOfRub >= currencyCount)
                        {
                            balanceOfRub -= currencyCount;
                            moneyReceived = currencyCount * rubToUsd;
                            balanceOfUsd += moneyReceived;
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

                        if (balanceOfUsd >= currencyCount)
                        {
                            balanceOfUsd -= currencyCount;
                            moneyReceived = currencyCount* usdToRub;
                            balanceOfRub += moneyReceived;
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

                        if (balanceOfRub >= currencyCount)
                        {
                            balanceOfRub -= currencyCount;
                            moneyReceived = currencyCount * rubToEur; 
                            balanceOfTheEur += moneyReceived;
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

                        if (balanceOfTheEur >= currencyCount)
                        {
                            balanceOfTheEur -= currencyCount;
                            moneyReceived = currencyCount * eurToRub;
                            balanceOfRub += moneyReceived;
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

                        if (balanceOfUsd >= currencyCount)
                        {
                            balanceOfUsd -= currencyCount;
                            moneyReceived = currencyCount * usdToEur;
                            balanceOfTheEur += moneyReceived;
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

                        if (balanceOfTheEur >= currencyCount)
                        {
                            balanceOfTheEur -= currencyCount;
                            moneyReceived = currencyCount * eurToUsd;
                            balanceOfUsd += moneyReceived;
                        }
                        else
                        {
                            Console.WriteLine("К сожелению обмен не произведем, у вас не достаточно средств ");
                        }
                        break;
                    case "выход":
                        isBankOpening = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели недопустимую команду ");
                        break;
                }

                Console.WriteLine("Ваш баланс " + balanceOfRub + " рублей " + balanceOfUsd + " долларов " + balanceOfTheEur + " евро ");
                Console.ReadKey();
            }
        }
    }
}


