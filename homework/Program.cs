using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework
{
    class Program
    {
        static string decode(string[] passarr, string str)
        {
            char[] array = str.ToLower().ToCharArray();
            str = str.Replace(" ", string.Empty);
            int numOfBytes = str.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; i++)
            {
                string oneBinaryByte = str.Substring(8 * i, 8);
                bytes[i] = Convert.ToByte(oneBinaryByte, 2);
            }
            byte[] bytesOfNewString = bytes;
            string password = Encoding.UTF8.GetString(bytesOfNewString);


            for (int i = 0; i < passarr.Length; i++)
            {
                if (password == passarr[i])
                {
                    return passarr[i];
                }

            }
            return "false";
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Домашнее задание 1");
            string[] passarr = new string[] { "password321", "админ", "пользователя admin1" };
            Console.WriteLine(decode(passarr, "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011"));


            Console.WriteLine("Домашнее задание 2");
            Console.WriteLine("Введите строку");
            string stR = Console.ReadLine();
            string[] words = stR.Split(new char[] { ' ' });
            string word1 = words[0];
            string word2 = words[1];
            string word3 = words[2];
            string word4 = words[3];
            string alfavit = "ЕЁИОУЫЭЮЯ";
            for (int i = 0; i < 4; i++)
            {

                words[i] = words[i].ToUpper();
                words[i] = words[i] + "!!!!";
                words[i] = words[i].Replace("А", "@");
                foreach (var k in alfavit)
                {
                    words[i] = words[i].Replace(k, '*');
                }

            }
            for (int i = 0; i < 4; i++)
            {
                Console.Write(words[i]);
            }
            Console.ReadKey();
        }
    }
}
