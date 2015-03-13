using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Level
    {
        private string kode_level;
        public string Kode_Level
        {
            set { kode_level = value; }
            get { return kode_level; }
        }

        private string nama_level;
        public string Nama_Level
        {
            set { nama_level = value; }
            get { return nama_level; }
        }
    }
}
