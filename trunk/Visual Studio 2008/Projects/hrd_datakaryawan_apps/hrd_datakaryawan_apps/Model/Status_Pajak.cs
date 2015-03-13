using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Status_Pajak
    {
        private string kode_status_pajak;
        public string Kode_Status_Pajak
        {
            set { kode_status_pajak = value; }
            get { return kode_status_pajak; }
        }

        private string keterangan;
        public string Keterangan
        {
            set { keterangan = value; }
            get { return keterangan; }
        }
    }
}
