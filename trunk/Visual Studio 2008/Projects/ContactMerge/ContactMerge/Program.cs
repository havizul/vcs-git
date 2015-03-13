using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ContactMerge
{
    class Program
    {       
        static void Main(string[] args)
        {
            string fileName = "customers.csv";

            contactInfo contInfo = new contactInfo();
            contactInfoDAO contInfoDAO = new contactInfoDAO();

            string inputFile = contInfoDAO.readFile(fileName);

            List<contactInfo> conInfoList = contInfoDAO.getAll(fileName);

            foreach (contactInfo conInfo in conInfoList)
            {
                //Console.WriteLine("{0} {1} {2} {3}", conInfo.Name, conInfo.Email, conInfo.Facebook, conInfo.Twitter);
            }
            
            
            Console.WriteLine("");
            Console.WriteLine("Press Enter To Exit...");
            Console.ReadKey();                
        }
    }
}
