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
            const string ShowAllBookCommand = "1";
            const string AddBookCommand = "2";
            const string DeleteBookCommand = "3";
            const string SearchBookCommand = "4";
            const string ExitCommand = "5";

            BookStorage bookStorage = new BookStorage();
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{ShowAllBookCommand} - Показать все книги в хранилище\n" +
                    $"{AddBookCommand} - Добавить книгу \n" +
                    $"{DeleteBookCommand} - Удалить книгу \n" +
                    $"{SearchBookCommand} - Поиск книги \n" +
                    $"{ExitCommand} - Выход");

                switch (Console.ReadLine())
                {
                    case ShowAllBookCommand:
                        bookStorage.ShowAllBooks();
                        break;

                    case AddBookCommand:
                        bookStorage.AddBooks();
                        break;

                    case DeleteBookCommand:
                        bookStorage.DeleteBooks();
                        break;

                    case SearchBookCommand:
                        bookStorage.SearchBooks();
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("\nНеккоректный ввод\n");
                        break;
                }
            }
        }
    }

    class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int YearsRelese { get; private set; }

        public Book (string tittle, string author, int yearsRelese)
        {
            Title = tittle;
            Author = author;
            YearsRelese = yearsRelese;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название книги : {Title}, Aвтор : {Author}, Год релиза : {YearsRelese}");
        }
    }

    class BookStorage
    {
        private List<Book> _books = new List<Book>();

        public void AddBooks()
        {
            Console.WriteLine("Введите название книги : ");
            string tittle = Console.ReadLine();

            Console.WriteLine("Введите автора книги : ");
            string author = Console.ReadLine();

            Console.WriteLine("Введите год релиза книги : ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int yearsRelese);

            if (isNumber != false)
            {
                Book book = new Book(tittle, author, yearsRelese);
                _books.Add(book);

                Console.WriteLine("Книга добавлена !!");
            }
            else
            {
                Console.WriteLine("Неккоректный ввод!!");
            }
        }

        public void DeleteBooks()
        {
            if (_books.Count != 0)
            {
                const string PositiveAnswer = "1";
                const string NegativeAnswer = "2";

                bool isFound = true;

                Console.WriteLine("Введите полное название книги : ");
                string input = Console.ReadLine();

                for (int i = 0; i < _books.Count; i++)
                {
                    if (_books[i].Title == input)
                    { 
                        bool isWork = true;

                        Console.WriteLine("Найдена книга :");
                        _books[i].ShowInfo();

                        while (isWork)
                        {
                            Console.WriteLine($"Что бы удалить данную книгу нажмите - {PositiveAnswer}" +
                                $"\nЧто бы не удалять и пордолжить поиск нажмите - {NegativeAnswer}");
                            string userInput = Console.ReadLine();

                            switch (userInput)
                            {
                                case PositiveAnswer:
                                    DeleteBooks(i, ref isWork);
                                    break;

                                case NegativeAnswer:
                                    isWork = false;
                                    break;

                                    default:
                                    Console.WriteLine("Неккоректный ввод!!");
                                    break;
                            }
                        }
                    }
                    else if (isFound == false)
                    {
                        Console.WriteLine("Книги с данным названием не найдено !!");
                    }
                }
            }
            else
            {
                Console.WriteLine("В хранилище еще нет книг!");
            }
        }

        public void ShowAllBooks()
        {
            if (_books.Count > 0)
            {
                foreach (Book book in _books)
                {
                    book.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("В хранилище еще нет книг!!");
            }
        }

        public void SearchBooks()
        {
            const string SearchTitleCommand = "1";
            const string SearchAuthorCommand = "2";
            const string SearchYearReleaseCommand = "3";
            const string ExitCommand = "4";

            if (_books.Count > 0)
            {
                bool isWork = true;

                while (isWork)
                {
                    Console.WriteLine($"{SearchTitleCommand} - По названию\n" +
                        $"{SearchAuthorCommand} - По автору\n" +
                        $"{SearchYearReleaseCommand} - По году релиза\n" +
                        $"{ExitCommand} - Выход");

                    switch (Console.ReadLine())
                    {
                        case SearchTitleCommand:
                            ShowBooksByTitle();
                            break;

                            case SearchAuthorCommand:
                            ShowBooksByAuthor();
                            break;

                        case SearchYearReleaseCommand:
                            ShowBooksByYearsRelese();
                            break;

                        case ExitCommand:
                            isWork = false;
                            break;

                            default:
                            Console.WriteLine("Неккоректный ввод!!");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("В хранилище еще нет книг!!");
            }
        }

        private void DeleteBooks(int key, ref bool isWork)
        {
            _books.RemoveAt(key);
            isWork = false;
            Console.WriteLine("Книга удалена !");
        }

        private void ShowBooksByTitle()
        {
            bool isFound = false;

            Console.WriteLine("\nВведите полное название книги\n");
            string input = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.Title == input)
                {
                    if (isFound == false)
                    {
                        Console.WriteLine("Результаты поиска");
                    }
                    book.ShowInfo();
                    isFound = true;
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("Книга с данным названием не найдена");
            }
        }

        private void ShowBooksByAuthor()
        {
            bool isFound = false;
            Console.WriteLine("\nВведите автора\n");
            string input = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.Author == input)
                {
                    if (isFound == false)
                    {
                        Console.WriteLine("Результаты поиска");
                    }
                    book.ShowInfo();
                    isFound = true;
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("Книга от данного автора не найдена");
            }
        }

        private void ShowBooksByYearsRelese()
        {
            bool isFound = false;
            Console.WriteLine("\nВведите год релиза\n");
            bool isNumber = int.TryParse(Console.ReadLine(), out int input);

            if (isNumber != false)
            {
                foreach (Book book in _books)
                {
                    if (book.YearsRelese == input)
                    {
                        if (isFound == false)
                        {
                            Console.WriteLine("Результаты поиска");
                        }
                        book.ShowInfo();
                        isFound = true;
                    }
                }

                if (isFound == false)
                {
                    Console.WriteLine("Книга данного года релиза не найдена");
                }
            }
            else
            {
                Console.WriteLine("Неккоректный ввод");
            }
        }
    }
}