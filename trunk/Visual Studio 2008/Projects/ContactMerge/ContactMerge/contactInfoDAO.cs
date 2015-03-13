using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace ContactMerge
{
    public class contactInfoDAO
    {
        private contactInfo mappingLineToObject(string lineFile)
        {
            string[] column = lineFile.Split(',');
            contactInfo conInfo = new contactInfo();

            conInfo.Name = column[0];
            conInfo.Email = column[1];
            conInfo.Facebook = column[2];
            conInfo.Twitter = column[3];

            //Console.WriteLine("Hasil : {0} {1} {2} {3}", conInfo.Name, conInfo.Email, conInfo.Facebook, conInfo.Twitter);
            return conInfo;
        }

        public string readFile(string fileName)
        {
            string inputFile = File.ReadAllText("customers.csv");

            return inputFile;
        }

        public int countFileLine(string fileName)
        {
            int jmlBrsFile = File.ReadAllLines("customers.csv").Length;

            return jmlBrsFile;
        }

        public bool writeFile(string outFile)
        {
            File.WriteAllText("customers_merge.csv", outFile);

            return true;
        }

        public List<contactInfo> getAll(string fileName)
        {
            List<contactInfo> conInfoLine = new List<contactInfo>();
            string[] filePerLine = File.ReadAllLines(fileName);
            
            
            foreach (string lineFile in filePerLine)
            {
                conInfoLine.Add(mappingLineToObject(lineFile));
            }


            //TES========================
            List<string> conInfoLineStrTes = new List<string>();
            //======================


            //=============================
            //For test
            //==============================
            List<string> conInfoLineStr = new List<string>();
            foreach (string lineFile in filePerLine)
            {
                conInfoLineStrTes.Add(lineFile);
            }


            //Console.WriteLine("\nFind: Contact where name contains \"Fernando Lamb\" : {0}", conInfoLineStrTes.Find(x => x.Contains("Rita Greer")));
            //=======================================
            //conInfoLineStr = conInfoLineStrTes.Contains("Rita Greer");


            return conInfoLine;
        }


    }
}
