using System;

namespace Exercise1 
{
    class Program1
    {
        static void Main(string[] args)
        {

            int allPictures = 52;
            int pictures;
            pictures = allPictures;
            int picturesInRow = 3;
            int falledRow = pictures / picturesInRow;
            pictures -= falledRow * picturesInRow;

            Console.WriteLine($"Заполняных рядов : {falledRow}");
            Console.WriteLine($"Сверх меры : {pictures}");
        }
    }
} 
    
