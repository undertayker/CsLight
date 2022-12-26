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
            const string TakeCardCommand = "1";
            const string TakeSeveralCardsCommand = "2";
            const string ShowHandCommand = "3";
            const string ExitCommand = "4";

            Deck deck = new Deck();
            Player player = new Player();
            bool isWorks = true;
           
            while (isWorks)
            {
                Console.WriteLine($"Добро пожаловать в программу! Выберете действие." +
                    $"\n{TakeCardCommand} - Взять карту из колоды\n" +
                    $"{TakeSeveralCardsCommand} - Взять несколько карт из колоды " +
                    $"\n{ShowHandCommand} - Посмотреть взятые карты \n" +
                    $"{ExitCommand} - Завершить работу программы");

                string userInput = Console.ReadLine();

                if (userInput == TakeCardCommand)
                {
                    player.TakeCard(deck.GiveCard());
                }
                else if (userInput == TakeSeveralCardsCommand)
                {
                    player.TakeSeveralCards(deck.GiveCard());
                }
                else if (userInput == ShowHandCommand)
                {
                    player.ShowHand();
                }
                else if (userInput == ExitCommand)
                {
                    isWorks = false;
                    Console.WriteLine("Работа программы завершена");
                }
                else
                {
                    Console.WriteLine("Неизвестная комманда");
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Card
    {
        public string Suit { get; private set; }
        public string Value { get; private set; }

        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;
        }
    }

    class Deck
    {
        private  List<Card> _cards = new List<Card>();

        public Deck()
        {
            string[] values = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
            string[] suits = { "Черви", "Пика", "Крести", "Буба" };

            Fill(values, suits);
            MixArray();
        }

        public int GetDeckLength()
        {
            return _cards.Count();
        }

        public Card GiveCard()
        {
            if (_cards.Count > 0)
            {
                Card card = _cards[0];
                _cards.Remove(card);
                return card;
            }
            else
            {
                Console.WriteLine("Колода пуста");
                return null;
            }
        }

        private void Fill(string[] value, string[] suit)
        {
            for (int i = 0; i < value.Length; i++)
            {
                for (int j = 0; j < suit.Length; j++)
                {
                    _cards.Add(new Card(value[i], suit[j]));
                }
            }
        }

        private void MixArray()
        {
            for (int i = _cards.Count - 1; i >= 1; i--)
            {
                Random random = new Random();
                int index = random.Next(i + 1);
                var temCard = _cards[index];
                _cards[index] = _cards[i];
                _cards[i] = temCard;
            }
        }
    }

    class Player
    {
        private List<Card> _hand = new List<Card>();
        private Deck _deck = new Deck();

        public void TakeCard(Card card)
        {
            if (card == null)
            {
                Console.WriteLine("В колоде закончились карты!");
            }
            else
            {
                _hand.Add(card);
            }
        }

        public void TakeSeveralCards(Card card)
        {
            Console.WriteLine("Сколько карт Вы хотите взять?");
            bool isNumber = int.TryParse(Console.ReadLine(), out int input);

            if (isNumber == true && input <= _deck.GetDeckLength())
            {
                for (int i = 0; i < input; i++)
                {
                    card = _deck.GiveCard();
                    _hand.Add(card);
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод или в колоде не осталось карт!");
            }
        }

        public void ShowHand()
        {
            if (_hand.Count > 0)
            {
                foreach (Card card in _hand)
                {
                    Console.WriteLine($"{card.Value} {card.Suit}");
                }
            }
            else
            {
                Console.WriteLine("У Вас в руке нет карт!");
            }
        }
    }
}