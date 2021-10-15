using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab5
{
    public enum Months
    {Январь,
        Февраль,
        Март,
        Апрель,
        Май,
        Июнь,
        Июль,
        Август,
        Сентябрь,
        Октябрь,
        Ноябрь,
        Декабрь

    }
    static class MatrixExt
    {
        // метод расширения для получения количества строк матрицы
        public static int RowsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(0) + 1;
        }

        // метод расширения для получения количества столбцов матрицы
        public static int ColumnsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(1) + 1;
        }
    }
    class Program
    {
        static public void Average(int[,] temperature)
        {
            double[] average = new double[12];
            double averaget = 0;
            
            for (int j = 0; j < 12; j++)
            {
                int sum = 0;

                for (int i = 0; i < 30; i++)
                {
                    sum += temperature[j, i];
                }
                averaget = sum / 30;
                average[j] = averaget;

            }
            for (int i = 0; i < average.GetLength(0); i++)
            {

               
                Console.WriteLine($"{average[i]} "+$"{(Months)(i)}");
            }
            Array.Sort(average);
            for (int i = 0; i < average.GetLength(0); i++)
            {


                Console.WriteLine(average[i]);
            }

                }
        static int GetCount(char[] array, char[] ar)
        {
            int Count = 0;

            foreach (char ch in array)
                foreach (char cha in ar)
                    if (ch == cha)
                        Count++;

            return Count;
        }
        static int GetCountList(List<char> Array, List<char> Ar)
        {
            int count = 0;

            foreach (char ch in Array)
                foreach (char cha in Ar)
                    if (ch == cha)
                        count++;

            return count;
        }
        // метод для получения матрицы из консоли
        static int[,] GetMatrixFromConsole(string name)
        {
            Console.Write("Количество строк матрицы {0}: ", name);
            var n = int.Parse(Console.ReadLine());
            Console.Write("Количество столбцов матрицы {0}: ", name);
            var m = int.Parse(Console.ReadLine());

            var matrix = new int[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    Console.Write("{0}[{1},{2}] = ", name, i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            return matrix;
        }

        // метод для печати матрицы в консоль
        static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.RowsCount(); i++)
            {
                for (var j = 0; j < matrix.ColumnsCount(); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }

        // метод для умножения матриц
        static int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.ColumnsCount() != matrixB.RowsCount())
            {
                throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }

            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.ColumnsCount(); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }

     
        static void Main(string[] args)
        { 
            Console.WriteLine("Упражнение 6.1");

            char[] vowels = "АЕЁИОУЫЭЮЯ".ToLower().ToCharArray();
            char[] consonants = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩЬЪ".ToLower().ToCharArray(); 
            FileStream stream = new FileStream($"C:/Новый текстовый документ.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            string str = reader.ReadToEnd();
            stream.Close();
           
            char[] array = str.ToLower().ToCharArray(); //Разбиваем строку на массив символов

            int vowelsCount = GetCount(array, vowels); 
            int consonantsCount = GetCount(array, consonants); 

            Console.WriteLine("Гласных в массиве: " + vowelsCount);
            Console.WriteLine("Согласных в массиве: " + consonantsCount);


            Console.WriteLine("Упражнение 6.2");

            var a = GetMatrixFromConsole("A");
             var b = GetMatrixFromConsole("B");

             Console.WriteLine("Матрица A:");
             PrintMatrix(a);

            Console.WriteLine("Матрица B:");
             PrintMatrix(b);

             var result = MatrixMultiplication(a, b);
             Console.WriteLine("Произведение матриц:");
            PrintMatrix(result);
        

              
            Console.WriteLine("Упражнение 6.3");
            int[,] temperature = new int[12, 30];
            string [] monts = new string[12];
            Random rand = new Random();
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = rand.Next(-20, 50);
                    Console.Write(temperature[i, j] + " ");
                }
                Console.Write((Months)(i));
                Console.WriteLine();
            }
           Console.WriteLine("Средняя температура месяцев за год");
           Average(temperature);


             Console.WriteLine("Упражнение 6.1");
             List<char> Vowels = new List<char>("АЕЁИОУЫЭЮЯ".ToLower().ToCharArray());  //Гласные
             List<char> Consonants = new List<char>("БВГДЖЗЙКЛМНПРСТФХЦЧШЩЬЪ".ToLower().ToCharArray()); //Согласные
             FileStream Stream = new FileStream($"C:/Новый текстовый документ.txt", FileMode.Open);
             StreamReader Reader = new StreamReader(Stream);
             string stR = Reader.ReadToEnd();
             Stream.Close();

             List<char> Str = new List<char>(stR.ToLower().ToCharArray()); //Разбиваем строку на массив символов

             int VowelsCount = GetCountList(Str, Vowels); //Количество гласных
             int ConsonantsCount = GetCountList(Str, Consonants); //Количество согласных

             Console.WriteLine("Гласных в массиве: " + VowelsCount);
             Console.WriteLine("Согласных в массиве: " + ConsonantsCount);
            
            Console.ReadKey();
        }
        }
    }


