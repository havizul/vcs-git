using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Upah
    {
        private string kode_upah;
        public string Kode_Upah
        {
            get { return kode_upah; }
            set { kode_upah = value; }
        }

        private string tipe_upah;
        public string Tipe_Upah
        {
            get { return tipe_upah; }
            set { tipe_upah = value; }
        }
    }
}
