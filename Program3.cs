﻿using System;

namespace Exercise1 
{
    class Program1
    {
        static void Main(string[] args)
        {

            int allPictures = 52;
            int picturesOutsideRow;
            picturesOutsideRow = allPictures;
            int picturesInRow = 3;
            int falledRow = picturesOutsideRow / picturesInRow;
            picturesOutsideRow = falledRow % picturesInRow;

            Console.WriteLine($"Заполняных рядов : {falledRow}");
            Console.WriteLine($"Сверх меры : {picturesOutsideRow}");
        }
    }
}

