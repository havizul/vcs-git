using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Departemen
    {
        private string kode_departemen;
        public string Kode_Departemen
        {
            set { kode_departemen = value; }
            get { return kode_departemen; }
        }

        private string nama_departemen;
        public string Nama_Departemen
        {
            set { nama_departemen = value; }
            get { return nama_departemen; }
        }
    }
}
