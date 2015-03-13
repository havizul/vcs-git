using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace removeExtraWhiteSpaceByTrim_CS
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your middle name or initial: ");
            string middleName = Console.ReadLine();
            
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();
            
            Console.WriteLine();
            Console.WriteLine("You entered '{0}', '{1}', and '{2}'.", firstName, middleName, lastName);
                        
            //string name = ((firstName.Trim() + " " + middleName.Trim()).Trim() + " " + lastName.Trim()).Trim();
            string name = (firstName.Trim() + " " + middleName.Trim() + " " + lastName.Trim());

            Console.WriteLine("The result is " + name + ".");
            
            Console.ReadKey();
   
        }
    }
}
