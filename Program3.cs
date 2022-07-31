using System;

namespace Exercise1 
{
    class Program1
    {
        static void Main(string[] args)
        {

            int allPictures = 52;
            int usedPictures;
            usedPictures = allPictures;
            int picturesInRow = 3;
            int falledRow = usedPictures / picturesInRow;
            usedPictures = falledRow % picturesInRow;

            Console.WriteLine($"Заполняных рядов : {falledRow}");
            Console.WriteLine($"Сверх меры : {usedPictures}");
        }
    }
} 
    
