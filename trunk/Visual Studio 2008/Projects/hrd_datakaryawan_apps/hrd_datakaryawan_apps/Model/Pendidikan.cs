using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Pendidikan
    {
        private int id_pendidikan;
        public int Id_Pendidikan
        {
            get { return id_pendidikan; }
            set { id_pendidikan = value; }
        }

        private string jenjang_pendidikan;
        public string Jenjang_Pendidikan
        {
            get { return jenjang_pendidikan; }
            set { jenjang_pendidikan = value; }
        }

        private string lembaga;
        public string Lembaga
        {
            get { return lembaga; }
            set { lembaga = value; }
        }

        private string jurusan;
        public string Jurusan
        {
            get { return jurusan; }
            set { jurusan = value; }
        }

        private DateTime tahun_masuk;
        public DateTime Tahun_masuk
        {
            get { return tahun_masuk; }
            set { tahun_masuk = value; }
        }

        private DateTime tahun_lulus;
        public DateTime Tahun_lulus
        {
            get { return tahun_lulus; }
            set { tahun_lulus = value; }
        }

        private string jenis_pendidikan;
        public string Jenis_Pendidikan
        {
            get { return jenis_pendidikan; }
            set { jenis_pendidikan = value; }
        }

        private string nik;
        public string NIK
        {
            get { return nik; }
            set { nik = value; }
        }
    }
}
