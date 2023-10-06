using System;

namespace Key_encryption
{
    internal class Program
    {
        static Random RandomNumber = new Random();
        static void Main(string[] args)
        {
            // Стоит вынести как меню в будущем
            while (true)
            {
                char[] charArray = InputForm("Введите предложение:").ToCharArray();

                char[,] charMatrix = CreateMatrix(charArray);

                int[] key = CreateKey(charMatrix);

                Console.WriteLine($"Ключ: {string.Join("", key)}");
                Console.Write("Результат: ");
                OutputMatrix(charMatrix, key);
                Console.ReadKey();
                Console.Clear();
            }
            
        }

        static string InputForm(string label)
        {
            Console.Write($"{label} ");
            return Console.ReadLine();
        }

        static int[] CreateKey(char[,] array)
        {
            int[] randomKey = new int[array.GetLength(0)];


            for (int i = 0; i < array.GetLength(0); i++)
            { randomKey[i] = i - 1; }


            for (int i = 0; i < array.GetLength(0); i++)
            {
                int j = RandomNumber.Next(i + 1);

                if (j != i)
                { randomKey[i] = randomKey[j]; }

                randomKey[j] = i;
            }
            return randomKey;
        }

        static char[,] CreateMatrix(char[] array)
        {
            int size = Convert.ToInt32(Math.Ceiling(Math.Sqrt(array.Length)));
            char[,] charMatrix = new char[size, size];
            //Запись и создание матрицы 
            int k = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    try
                    { charMatrix[i, j] = array[k]; }
                    catch
                    { charMatrix[i, j] = Convert.ToChar(' '); }
                    k++;
                }
            }
            return charMatrix;
        }

        static void OutputMatrix(char[,] array, int[] key)
        {
            //конвертация в строку и вывод вместе с ключом
            char[,] mixedArr = new char[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    mixedArr[i, j] = array[i, key[j]];
                    Console.Write(mixedArr[i, j]);
                }
            }
        }

        /*
        static void Deshifr()
        {

        } */
    }
}