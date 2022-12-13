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
            BookStorage bookStorage = new BookStorage();
            bool isWork = true;

            const string ShowAllBooks = "Показать все книги в хранилище ";
            const string AddBooks = "Добавить книгу ";
            const string DeleteBooks = "Удалить книгу ";
            const string Exit = "Выход";
            const string SearchBook = "Поиск книги";

            while (isWork == true)
            {
                Console.WriteLine($"\n1. {ShowAllBooks}\n2. {AddBooks}\n3. {DeleteBooks}\n4. {SearchBook}\n5. {Exit}");
                switch (Console.ReadLine())
                {
                    case "1":
                        bookStorage.ShowAllBook();
                        break;

                    case "2":
                        bookStorage.Add();
                        break;

                    case "3":
                        bookStorage.Delete();
                        break;

                    case "4":
                        bookStorage.Search();
                        break;

                    case "5":
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
        public int YearRelease { get; private set; }

        public Book(string title, string author, int yearRelease)
        {
            Title = title;
            Author = author;
            YearRelease = yearRelease;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\nНазвание книги: {Title} \nАвтор: {Author} \nГод релиза : {YearRelease}\n");
        }
    }

    class BookStorage
    {
        private List<Book> _books = new List<Book>();

        public void Add()
        {
            Console.WriteLine("Введите название книги");
            string title = Console.ReadLine();

            Console.WriteLine("\nВведите автора книги: \n");
            string author = Console.ReadLine();          

            Console.WriteLine("\nВведите год релиза книги: \n");
            bool userInput = int.TryParse(Console.ReadLine(), out int yearRelease);

            if (userInput != false)
            {
                Book book = new Book(title, author, yearRelease);
                _books.Add(book);

                Console.WriteLine("\nКнига добавлена!\n");
            }
            else
            {
                Console.WriteLine("\nНеккоректный ввод\n");
            }
        }

        public void Delete()
        {
            if (_books.Count != 0)
            {
                const string PositiveAnswer = "Да";
                const string NegativeAnswer = "Нет и продолжить поиск";

                bool isFound = false;
                bool isWork;

                Console.WriteLine("\nВведите полное название книги\n");
                string input = Console.ReadLine();

                for (int i = 0; i < _books.Count; i++)
                {
                    if (_books[i].Title == input)
                    {
                        isWork = true;
                        isFound = true;
                        Console.WriteLine("\nНайдена книга\n");
                        _books[i].ShowInfo();

                        while (isWork == true)
                        {
                            Console.WriteLine($"\nУдалить данную книгу ?\n1. {PositiveAnswer} \n2. {NegativeAnswer}");
                            string input2 = Console.ReadLine();

                            switch (input2)
                            {
                                case "1":
                                    DeleteBook(i, ref isWork);
                                    break;

                                case "2":
                                    isWork = false;
                                    break;

                                default:
                                    Console.WriteLine("\nНеккоректный ввод\n");
                                    break;
                            }
                        }
                    }
                    else if (isFound == false)
                    {
                        Console.WriteLine("\nКниги с данным названием не найдено\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nВ хранилище ещё нет книг\n");
            }
        }

        public void ShowAllBook()
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
                Console.WriteLine("\nВ хранилище ещё нет книг\n");
            }
        }

        public void Search()
        {
            const string ByName = "По названию"; 
            const string ByAuthor = "По автору";
            const string ByYearOfRelese = "По году релиза"; 
            const string Exit = "Выход";

            if (_books.Count > 0)
            {
                bool isWork = true;

                while (isWork == true)
                {
                    Console.WriteLine($"\n1. {ByName}\n2. {ByAuthor}\n3. {ByYearOfRelese}\n4. {Exit}");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            SearchTitle();
                            break;

                        case "2":
                            SearchAuthor();
                            break;

                        case "3":
                            SearchYearRelease();
                            break;

                        case "4":
                            isWork = false;
                            break;

                        default:
                            Console.WriteLine("\nНеккоректный ввод\n");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nВ хранилище ещё нет книг\n");
            }
        }

        private void DeleteBook(int key, ref bool isWork)
        {
            _books.RemoveAt(key);
            isWork = false;
            Console.WriteLine("\nКнига удалена!\n");
        }

        private void SearchTitle()
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
                        Console.WriteLine("\nРезультаты поиска\n");
                    }
                    book.ShowInfo();
                    isFound = true;
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("\nКнига с данным названием не найдена\n");
            }
        }

        private void SearchAuthor()
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
                        Console.WriteLine("\nРезультаты поиска\n");
                    }
                    book.ShowInfo();
                    isFound = true;
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("\nКнига от данного автора не найдена\n");
            }
        }

        private void SearchYearRelease()
        {
            bool isFound = false;

            Console.WriteLine("\nВведите год релиза\n");
            bool userInput = int.TryParse(Console.ReadLine(), out int input);

            if (userInput != false)
            {
                foreach (Book book in _books)
                {
                    if (book.YearRelease == input)
                    {
                        if (isFound == false)
                        {
                            Console.WriteLine("\nРезультаты поиска\n");
                        }
                        book.ShowInfo();
                        isFound = true;
                    }
                }

                if (isFound == false)
                {
                    Console.WriteLine("\nКнига данного года релиза не найдена\n");
                }
            }
            else
            {
                Console.WriteLine("\nНеккоректный ввод\n");
            }
        }
    }
}