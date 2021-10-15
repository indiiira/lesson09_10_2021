using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;



namespace _09_10_2021
{
    class Program
    {
        static string game(int[] team1, int[] team2)
        {
            int count1 = 0;
            int count2 = 0;
            for (int n = 0; n < team1.Length; n++)
            {
                if (team1[n] == 5)
                {
                    count1 += 1;
                }
            }
            for (int n = 0; n < team2.Length; n++)
            {
                if (team2[n] == 5)
                {
                    count2 += 1;
                }
            }
            if (count1 == count2)
            {
                return "Drinks All Round! Free Beers on Bjorg!";
            }
            else
            {
                return "Ой, Бьорг - пончик! Ни для кого пива!";
            }
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Домашнее задание 1");
            int n;
            Console.WriteLine("Введите количество человек в команде");
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число n");
            }
            int[] team1 = new int[n];
            int[] team2 = new int[n];
            Random rand = new Random();
            Console.WriteLine("Bavarian Beer Bears");
            for (int i=0; i<n; i++)
            {
                team1[i]= rand.Next(0,9);
                Console.WriteLine($"{i+1}- {team1[i]}");   
            }
            Console.WriteLine("Bavarian Beer Bears");
            for (int i = 0; i < n; i++)
            {
                team2[i] = rand.Next(0, 9);
                Console.WriteLine($"{i+1}- {team2[i]}");
            }
            string answer=game(team1 ,team2);
            Console.WriteLine(answer);
            
         
           


            
            Console.ReadKey();

        }
    }
}
        

    

