using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Status_Pekerja
    {
        private string kode_status;
        public string Kode_Status
        {
            get { return kode_status; }
            set { kode_status = value; }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
