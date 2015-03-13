using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace MagicNumbers2
{
    class Program
    {
        static void Main(string[] args)
        {
            int jmlBrsFile = File.ReadAllLines("magicNumbers.txt").Length;
            string strMagicNumbers = File.ReadAllText("magicNumbers.txt");


            //Validasi Input file
            //Baris tidak boleh lebih dari 1
            if (jmlBrsFile > 1)
            {
                Console.WriteLine("File tidak boleh berisi lebih dari 1 baris !!!");
                Console.ReadKey();
                System.Environment.Exit(0);
            }

            //Validasi Input file
            //Semua karakter harus berupa angka
            ArrayList strPrimaArr = new ArrayList();
            foreach (char ch in strMagicNumbers)
            {
                if (char.IsDigit(ch) == false)
                {
                    Console.WriteLine("File hanya boleh berisi angka !!!");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
            }


            //Syarat file terpenuhi, proses dilanjutkan
            Console.WriteLine("===========================================");
            Console.Write("INPUT : ");
            Console.WriteLine(strMagicNumbers);
            Console.WriteLine("===========================================");
            Console.WriteLine();
            
            int n = int.Parse(strMagicNumbers); //Nilai n

            var format = "";
            for (var i = 0; i < n; i++)
            {
                format += "0";
            }

            //Console.WriteLine(format);
            //double value;
            //value = 123;
            //Console.WriteLine(value.ToString("00000"));
            //Console.WriteLine(String.Format("{0:00000}", value));
            // Displays 00123 

            var maxLoop = int.Parse("1" + string.Format("{0:" + format + "}", 0));  //Jumlah digit
            //Console.WriteLine("string.Format = " + string.Format("{0:" + format + "}", 0));
            //Console.WriteLine("");

            var magicNumber = 0;
            string[] magicNumberArr = new string[maxLoop.ToString().Length];
            int count = 0;
            for (var i = 0; i < maxLoop; i++)
            {
                var sNumber = string.Format("{0:" + format + "}", i);
                //Console.WriteLine("string.Format = " + string.Format("{0:" + format + "}", i));
                magicNumber = GetMagicNumber(sNumber);
                //Console.WriteLine(magicNumber);

                if (int.Parse(sNumber) == magicNumber) // cetak magic number
                {
                    //Console.WriteLine(magicNumber);
                    magicNumberArr[count] = sNumber;
                    //Console.WriteLine(sNumber);
                    //Console.WriteLine(magicNumberArr[count]);
                    count++;
                } 
            }

            //Console.WriteLine("Jumlah array magicNumberArr = " + magicNumberArr.Count().ToString());
            if (magicNumberArr.Count() == 1)
            {
                Console.Write(string.Format("{0:" + format + "}", magicNumber));
            }
            else
            {
                string strA = "";
                int countArr = magicNumberArr.Count();
                foreach (string str in magicNumberArr)
                {
                    if (!(str.Equals(magicNumberArr[countArr - 1])))                    
                    {
                        strA += str + ", ";
                    }
                    else
                    {
                        strA += "dan " + str;
                    }                    
                }

                Console.WriteLine(strA);
            }            
                        

            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
        }

        static int GetMagicNumber(string number)
        {
            var result = 0;

            var lengthNumber = number.Length;
            var center = lengthNumber / 2;

            var number1 = number.Substring(0, center);
            var number2 = number.Substring(center);

            result = (int)Math.Pow((double.Parse(number1) + double.Parse(number2)), 2.0);

            return result;
        }
    }
}
