using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Jabatan
    {
        private string kode_jabatan;
        public string Kode_Jabatan
        {
            get { return kode_jabatan; }
            set { kode_jabatan = value; }
        }

        private string nama_jabatan;
        public string Nama_Jabatan
        {
            get { return nama_jabatan; }
            set { nama_jabatan = value; }
        }

    }
}
