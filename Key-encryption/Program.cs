﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Key_encryption
{
    internal class Program
    {
        static Random rnd = new Random();
        static char[] charArr;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение");
            string sentence = Console.ReadLine();
            charArr = sentence.ToCharArray();
            int n;
            n = Convert.ToInt32(Math.Ceiling(Math.Sqrt(charArr.Length)));
            MatrixInput(n);
            Console.ReadKey();
        }

        //static char[,] InputArr = new char[n, n];

        static void MatrixInput(int number)
        {
            char[,] InputArr = new char[number, number];
            //Запись и создание матрицы 
            int k = 0;
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)

                {
                    try
                    {
                        InputArr[i, j] = charArr[k];
                    }
                    catch
                    {
                        InputArr[i, j] = Convert.ToChar(' ');
                    }
                    k++;
                }
            }
            MatrixMix(number, InputArr);
        }



        static void MatrixMix(int number, char[,] Array)
        {
            //тестовый ключ
            //int[] RanKey = { 0, 2, 1, 3 };

            //шифрование и получение ключа
            int[] RanKey = new int[number];


            for (int i = 0; i < number; i++)
            {
                RanKey[i] = i - 1;
            }


            for (int i = 0; i < number; i++)
            {
                int j = rnd.Next(i + 1);
                if (j != i)
                {
                    RanKey[i] = RanKey[j];
                }
                RanKey[j] = i;
            }
            Console.WriteLine($"Ключ:");
            for (int i = 0; i < number; i++)
            {

                Console.Write(RanKey[i]);
            }
            Console.WriteLine(' ');
            Console.WriteLine("Результат:");
            MatrixOutput(number, Array, RanKey);
        }

        static void MatrixOutput(int number, char[,] Array, int[] Rankey)
        {
            //конвертация в строку и вывод вместе с ключом
            char[,] MixedArr = new char[number, number];
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    MixedArr[i, j] = Array[i, Rankey[j]];
                    Console.Write(MixedArr[i, j]);
                }
            }
        }

        static void Deshifr()
        {

        }
    }
}