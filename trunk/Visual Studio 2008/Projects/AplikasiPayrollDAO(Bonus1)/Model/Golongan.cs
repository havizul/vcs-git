using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AplikasiPayrollDAO.Model
{
    public class Golongan
    {
        private string pkgolongan;
        public string Tk_Golongan
        {
            get { return pkgolongan; }
            set { pkgolongan = value; }
        }

        private int tjSuamiIstri;
        public int TJ_Suami_Istri
        {
            get { return tjSuamiIstri; }
            set { tjSuamiIstri = value; }
        }

        private int tjAnak;
        public int TJ_Anak
        {
            get { return tjAnak; }
            set { tjAnak = value; }
        }

        private int uangMakan;
        public int Uang_Makan
        {
            get { return uangMakan; }
            set { uangMakan = value; }
        }

        private int uangLembur;
        public int Uang_Lembur
        {
            get { return uangLembur; }
            set { uangLembur = value; }
        }

        private int askes;
        public int Askes
        {
            get { return askes; }
            set { askes = value; }
            
        }
    }
}
