using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Informasi_Resign
    {
        private string nik;
        public string NIK
        {
            set { nik = value; }
            get { return nik; }
        }

        private string status_resign;
        public string Status_Resign
        {
            set { status_resign = value; }
            get { return status_resign; }
        }

        private Nullable<DateTime> tanggal_resign;
        public Nullable<DateTime> Tanggal_Resign
        {
            set { tanggal_resign = value; }
            get { return tanggal_resign; }
        }

        private string alasan_resign;
        public string Alasan_Resign
        {
            set { alasan_resign = value; }
            get { return alasan_resign; }
        }
    }
}
