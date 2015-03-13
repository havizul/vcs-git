using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Lokasi_Kerja
    {
        private string kode_lokasi;
        public string Kode_Lokasi
        {
            get { return kode_lokasi; }
            set { kode_lokasi = value; }
        }

        private string lokasi;
        public string Lokasi
        {
            get { return lokasi; }
            set { lokasi = value; }
        }
    }
}
