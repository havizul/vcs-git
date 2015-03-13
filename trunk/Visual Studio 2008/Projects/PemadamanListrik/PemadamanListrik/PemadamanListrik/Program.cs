using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PemadamanListrik
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "inputNumber.txt";
            string outputFile = "urutanPemadaman.txt";
            string strKecPadam = string.Empty;
            
            string[] lines = File.ReadAllLines(inputFile);
            bool IsValidInput = validateInputFile(lines);
            Random random = new Random();

            //Validasi Input File dan Exit Jika Input tidak valid
            if (!IsValidInput)
            {
                Console.WriteLine("Input tidak valid.\n");
                Console.WriteLine("\n\nPress any key to exit...");
                Console.ReadKey();
                System.Environment.Exit(0);
            }

            //Proses Input File
            int N = int.Parse(lines[0].Substring(2));
            int L = int.Parse(lines[1].Substring(2));
            //int N = 17;
            //int L = 7;

            tampil("INPUT : N = ", N.ToString() + ", L = " + L.ToString());

            List<int[]> MValues = new List<int[]>();
            
            //Get All M Values and Its Sequence
            for (int i = 1; i <= N; i++)
            {
                MValues.Add(getMValue(N, L, i));                
            }

            int cnt = 1;
            //Store All MValues to String
            foreach (int[] kecPdm in MValues)
            {

                strKecPadam += "Nilai M = " + cnt.ToString() + " => ";

                for (int i = 0; i < kecPdm.Count(); i++)
                {
                    
                        if (i < kecPdm.Count() - 1)
                        {
                            strKecPadam += kecPdm[i].ToString() + ", ";
                        }
                        else
                        {
                            strKecPadam += "dan " + kecPdm[i].ToString();
                        }                    
                }

                strKecPadam += "\n";
                cnt++;
            }

            int randomM = random.Next(1, MValues.Count());
            File.WriteAllText(outputFile, "Daftar Kecamatan Padam :\n===============================================================================\n" + strKecPadam + "\n===============================================================================\n" + "Random M = " + randomM.ToString());
            
            tampil("OUTPUT :\n", strKecPadam);
            tampil("RANDOM M : ", randomM.ToString() + "\nOutput File : \\bin\\debug\\urutanPemadaman.txt\nSilahkan buka menggunakan Wordpad (Windows) atau Gedit (Linux)");
            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }

        static bool validateInputFile(string[] lines)
        {
            bool retVal = false;
            int iG = 0;

           
            if (lines.Length != 2)
            {
                Console.WriteLine("Input tidak boleh kurang atau lebih dari 2 baris !");
                //retVal = false;
            }
            else if (lines[0].Length < 3 || lines[0].Length > 4 || lines[1].Length < 3 || lines[1].Length > 4)
            {
                Console.WriteLine("Jumlah Karakter perbaris dalam input file tidak boleh kurang atau lebih dari 4 karakter.\nDengan format :\nN=17 -> Baris 1\nL=NomorKecamatan -> Baris 2");                
            }
            else if (lines[0].IndexOf("N=") != 0 || lines[1].IndexOf("L=") != 0)
            {
                Console.WriteLine("Gunakan Format yang benar dalam input file :\nN=17 -> Baris 1\nL=NomorKecamatan -> Baris 2");
            }
            else if (!int.TryParse(lines[1].Substring(2), out iG))
            {
                Console.WriteLine("Nilai L harus berupa angka !");
            }
            else if (int.Parse(lines[0].Substring(2)) != 17)
            {
                Console.WriteLine("Nilai N yang diizinkan adalah 17 !");
            }
            else if (int.Parse(lines[1].Substring(2)) > 17 || int.Parse(lines[1].Substring(2)) < 1)
            {
                Console.WriteLine("Nilai L yang diizinkan adalah 1-17 !");
            }
            else
            {
                retVal = true;
            }

            return retVal;
        }

        static void tampil(string str1, string str2)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("{0}{1}", str1, str2);
            Console.WriteLine("==============================================");
        }

        static int[] getMValue(int N, int L, int M)
        {
            int[] daftarKecamatan = new int[N];           

            //kecamatanPadam[kecamatanPadam.Count() - 1] = L;
            //Console.WriteLine((kecamatanPadam.Count() - 1).ToString());

            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    daftarKecamatan[i] = 1;
                    daftarKecamatan[daftarKecamatan.Count() - 1] = L;
                }
                else if ((stepVal(daftarKecamatan[i - 1], M) != L) && (stepVal(daftarKecamatan[i - 1], M) > 0) && (stepVal(daftarKecamatan[i - 1], M) <= N) && (!Array.Exists(daftarKecamatan, kcPdm => kcPdm == (stepVal(daftarKecamatan[i - 1], M)))) && (i != daftarKecamatan.Count() - 1))
                {
                    daftarKecamatan[i] = daftarKecamatan[i - 1] + M;
                }
                else
                {
                    for (int a = 1; a <= N; a++)
                    {

                        if ((!Array.Exists(daftarKecamatan, kcPdm => kcPdm == (stepVal((daftarKecamatan[i - 1] + a), M)) - N)) && (((stepVal((daftarKecamatan[i - 1] + a), M)) - N) > 0) && (i != daftarKecamatan.Count() - 1) && (((stepVal((daftarKecamatan[i - 1] + a), M)) - N) <= N))
                        {
                            daftarKecamatan[i] = ((daftarKecamatan[i - 1] + a) + M) - N;
                            break;
                        }

                        else
                        {
                            for (int b = 1; b <= N; b++)
                            {

                                if (!Array.Exists(daftarKecamatan, kcPdm => kcPdm == a))
                                {
                                    daftarKecamatan[i] = a;
                                    break;
                                }
                            }
                        }
                    }
                }                
            }

            return daftarKecamatan;
        }

        static int stepVal(int dftKcmtn, int M)
        {
            return dftKcmtn + M;
        }            
        
    }
}
