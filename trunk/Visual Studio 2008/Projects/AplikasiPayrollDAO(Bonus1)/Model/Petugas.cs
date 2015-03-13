using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AplikasiPayrollDAO.Model
{
    public class Petugas
    {
        private string kode_Petugas;
        public string Kode_Petugas
        {
            get { return kode_Petugas; }
            set { kode_Petugas = value; }
        }

        private string nama_Petugas;
        public string Nama_Petugas
        {
            get { return nama_Petugas; }
            set { nama_Petugas = value; }
        }

        private string password_Petugas;
        public string Password_Petugas
        {
            get { return password_Petugas; }
            set { password_Petugas = value; }
        }

        private string status_Petugas;
        public string Status_Petugas
        {
            get { return status_Petugas; }
            set { status_Petugas = value; }
        }
    }
}
