using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Informasi_Email
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string alamat_email;
        public string Alamat_Email
        {
            get { return alamat_email; }
            set { alamat_email = value; }
        }

        private string kepemilikan_email;
        public string Kepemilikan_Email
        {
            get { return kepemilikan_email; }
            set { kepemilikan_email = value; }
        }

        private string nik;
        public string NIK
        {
            get { return nik; }
            set { nik = value; }
        }
    }
}
