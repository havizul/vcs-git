using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace hrd_datakaryawan_apps.Model
{
    public class Jenis_Pekerja
    {
        private string kode_jenis_pekerja;
        public string Kode_Jenis_Pekerja
        {
            get { return kode_jenis_pekerja; }
            set { kode_jenis_pekerja = value; }
        }

        private string jenis_pekerja;
        public string Nama_Jenis_Pekerja
        {
            get { return jenis_pekerja; }
            set { jenis_pekerja = value; }
        }
    }
}
