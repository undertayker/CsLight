using System;

namespace Exercise 
{
    class Program
    {
        static void Main(string[] args)
        {
            int allPictures = 52;
            int picturesInRow = 3;
            int falledRow = allPictures / picturesInRow;
            allPictures -= falledRow * picturesInRow;

            Console.WriteLine($"Заполняных рядов : {falledRow}");
            Console.WriteLine($"Сверх меры : {allPictures}");
        }
    }
} 
    
