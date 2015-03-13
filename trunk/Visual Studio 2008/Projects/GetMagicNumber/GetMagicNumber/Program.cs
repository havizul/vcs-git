using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetMagicNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;

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
            Console.WriteLine("");


            for (var i = 0; i < maxLoop; i++)
            {
                var sNumber = string.Format("{0:" + format + "}", i);
                //Console.WriteLine("string.Format = " + string.Format("{0:" + format + "}", i));
                var magicNumber = GetMagicNumber(sNumber);

                if (int.Parse(sNumber) == magicNumber) // cetak magic number
                    Console.WriteLine(string.Format("{0} -> {1}", sNumber, magicNumber));

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
