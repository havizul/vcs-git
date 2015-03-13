using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tes2
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 1;  //Step
            int L = 3;  //Kecamatan terakhir padam
            int N = 17; //Jumlah kecamatan

            int[] kecamatanPadam = new int[N];
            string kecamatanPadamStr = "";

            //kecamatanPadam[kecamatanPadam.Count() - 1] = L;
            //Console.WriteLine((kecamatanPadam.Count() - 1).ToString());

            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    //Console.WriteLine("kecamatanPadam[0] = 1 ");
                    kecamatanPadam[i] = 1;
                }
                else if (i == kecamatanPadam.Count() - 2)
                {
                    kecamatanPadam[kecamatanPadam.Count() - 2] = L;
                }
                else if ((kecamatanPadam[i - 1] + M <= N) && ((kecamatanPadam[i - 1] + M) != L) && (kecamatanPadam[i - 1] + M) > 0)// && !Array.Exists(kecamatanPadam, intVal => intVal == kecamatanPadam[i-1] + M))
                {
                    //Console.WriteLine("kecamatanPadam[{0}] + 5 < 17 = {1}", (i - 1).ToString(), (kecamatanPadam[i - 1] + M).ToString());
                   
                    kecamatanPadam[i] = kecamatanPadam[i - 1] + M;                   
                }
                else 
                {
                    if (!Array.Exists(kecamatanPadam, intVal => intVal == ((kecamatanPadam[i - 1] + M) - N)))
                    {
                        //Console.WriteLine("Index i = {0}", i.ToString());
                        if ((((kecamatanPadam[i - 1] + M) - N) != L) && (kecamatanPadam[i - 1] + M) != L)
                        {
                            kecamatanPadam[i] = (kecamatanPadam[i - 1] + M) - N;
                        }
                        else
                        {
                            for (int a = 1; a <= N; a++)
                            {
                                if (!Array.Exists(kecamatanPadam, sIntVal => sIntVal == a)&& (kecamatanPadam[i - 1] + M) > L)
                                {
                                    kecamatanPadam[i] = a;
                                }
                            }
                        }
                    }              
                   
                }                
            }

            //Save to string
            for (int i = 0; i < kecamatanPadam.Count(); i++)
            {
                if (i < kecamatanPadam.Count() - 1)
                {
                    kecamatanPadamStr += kecamatanPadam[i].ToString() + ", ";
                }
                else
                {
                    kecamatanPadamStr += "dan " + kecamatanPadam[i].ToString();
                }
            }

            Console.WriteLine("Urutan Kecamatan Padam :\n" + kecamatanPadamStr);

            // Keep the console window open in debug mode.
            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey();
             
        }        
    }
}
