using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AplikasiPayrollDAO.Model
{
    public class Jabatan
    {
        private string kode_Jabatan;
        public string Kode_Jabatan
        {
            get { return kode_Jabatan; }
            set { kode_Jabatan = value; }
        }

        private string nama_Jabatan;
        public string Nama_Jabatan
        {
            get { return nama_Jabatan; }
            set { nama_Jabatan = value; }
        }

        private int gaji_Pokok;
        public int Gaji_Pokok
        {
            get { return gaji_Pokok; }
            set { gaji_Pokok = value; }
        }

        private int tj_Jabatan;
        public int TJ_Jabatan
        {
            get { return tj_Jabatan; }
            set { tj_Jabatan = value; }
        }
    }
}
