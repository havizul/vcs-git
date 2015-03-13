using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Agama
    {
        private int id_agama;
        public int Id_Agama
        {
            get { return id_agama; }
            set { id_agama = value; }
        }

        private string nama_agama;
        public string Nama_Agama
        {
            get { return nama_agama; }
            set { nama_agama = value; }
        }
    }
}
