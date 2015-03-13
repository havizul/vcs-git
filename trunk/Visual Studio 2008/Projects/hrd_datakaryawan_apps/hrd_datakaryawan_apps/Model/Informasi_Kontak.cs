using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Informasi_Kontak
    {
        private string nomor_kontak;
        public string Nomor_Kontak
        {
            set { nomor_kontak = value; }
            get { return nomor_kontak; }
        }

        private string jenis_kontak;
        public string Jenis_Kontak
        {
            set { jenis_kontak = value; }
            get { return jenis_kontak; }
        }

        private string nik;
        public string NIK
        {
            set { nik = value; }
            get { return nik; }
        }

        private int id_inform_kontak;
        public int Id_Inform_Kontak
        {
            set { id_inform_kontak = value; }
            get { return id_inform_kontak; }
        }
    }
}
