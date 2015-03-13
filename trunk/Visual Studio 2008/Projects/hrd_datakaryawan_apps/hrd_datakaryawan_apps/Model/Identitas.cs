using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Identitas
    {
        private string nomor_identitas;
        public string Nomor_Identitas
        {
            set { nomor_identitas = value; }
            get { return nomor_identitas; }
        }

        private string jenis_identitas;
        public string Jenis_Identitas
        {
            set { jenis_identitas = value; }
            get { return jenis_identitas; }
        }

        private DateTime masa_berlaku;
        public DateTime Masa_Berlaku
        {
            set { masa_berlaku = value; }
            get { return masa_berlaku; }
        }

        private string nik;
        public string Nik
        {
            set { nik = value; }
            get { return nik; }
        }

    }
}
