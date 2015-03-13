using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace myAppSuperLaunch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Open specified Word file
                //openMsWord(@"C:\hidden\big.docx");

                runCPUStress(@"C:\hidden\CPUSTRES.EXE");
                //getMemoryUsed();


                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message.ToString());
                Console.ReadKey();
            }
        }

        static void openMsWord(string file)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "WINDWORD.EXE";
                startInfo.Arguments = file;
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message.ToString() + "\nMethod : openMsWord(string file)");
                Console.ReadKey();
            }           
        }

        static void getMemoryUsed()
        {
            try
            {
                Process currentProc = Process.GetCurrentProcess();
                long memoryUsed = currentProc.PrivateMemorySize64;

                Console.WriteLine("Total used memory : " + memoryUsed.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message.ToString() + "\nMethod : getMemoryUsed()");
                Console.ReadKey();
            }            
        }

        static void runCPUStress(string path)
        {
            try
            {
                //ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.FileName = "CPUSTRES.EXE";
                //startInfo.Arguments = path;
                Process.Start(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message.ToString() + "\nMethod : runMemoryStress(string path)");
                Console.ReadKey();
            }
        }
    }
}
