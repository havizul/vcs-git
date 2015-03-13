using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Ukuran_Pakaian
    {
        private string nik;
        public string NIK
        {
            get { return nik; }
            set { nik = value; }
        }

        private string ukuran_baju;
        public string Ukuran_Baju
        {
            get { return ukuran_baju; }
            set { ukuran_baju = value; }
        }

        private string ukuran_celana;
        public string Ukuran_Celana
        {
            get { return ukuran_celana; }
            set { ukuran_celana = value; }
        }

        private string ukuran_sepatu;
        public string Ukuran_Sepatu
        {
            get { return ukuran_sepatu; }
            set { ukuran_sepatu = value; }
        }
    }
}
