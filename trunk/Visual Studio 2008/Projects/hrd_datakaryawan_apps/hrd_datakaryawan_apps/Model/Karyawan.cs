using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Karyawan
    {
        private string nik;
        public string NIK
        {
            set { nik = value; }
            get { return nik; }
        }

        private string nama;
        public string Nama
        {
            set { nama = value; }
            get { return nama; }
        }

        private string nick_name;
        public string Nick_Name
        {
            set { nick_name = value; }
            get { return nick_name; }
        }

        private string tempat_lahir;
        public string Tempat_lahir
        {
            set { tempat_lahir = value; }
            get { return tempat_lahir; }
        }

        private Nullable<DateTime> tanggal_lahir;
        public Nullable<DateTime> Tanggal_Lahir
        {
            set { tanggal_lahir = value; }
            get { return tanggal_lahir; }
        }

        private string jenis_kelamin;
        public string Jenis_Kelamin
        {
            set { jenis_kelamin = value; }
            get { return jenis_kelamin; }
        }

        private string status_nikah;
        public string Status_Nikah
        {
            set { status_nikah = value; }
            get { return status_nikah; }
        }

        private string kewarganegaraan;
        public string Kewaganegaraan
        {
            set { kewarganegaraan = value; }
            get { return kewarganegaraan; }
        }

        private string golongan_darah;
        public string Golongan_Darah
        {
            set { golongan_darah = value; }
            get { return golongan_darah; }
        }
        

        private string asuransi;
        public string Asuransi
        {
            set { asuransi = value; }
            get { return asuransi; }
        }

        private string jamsostek;
        public string Jamsostek
        {
            set { jamsostek = value; }
            get { return jamsostek; }
        }

        private string npwp;
        public string NPWP
        {
            set { npwp = value; }
            get { return npwp; }
        }
        
        private Status_Pekerja status_pekerja = new Status_Pekerja();
        public Status_Pekerja Status_Pekerja
        {
            set { status_pekerja = value; }
            get { return status_pekerja; }
        }

        /*
        private string status_pekerja;
        public string Status_Pekerja
        {
            set { status_pekerja = value; }
            get { return status_pekerja; }
        }
        */

        private Jenis_Pekerja jenis_pekerja = new Jenis_Pekerja();
        public Jenis_Pekerja Jenis_Pekerja
        {
            set { jenis_pekerja = value; }
            get { return jenis_pekerja; }
        }

        private Upah upah = new Upah();
        public Upah Upah
        {
            set { upah = value; }
            get { return upah; }
        }

        private Agama agama = new Agama();
        public Agama Agama
        {
            set { agama = value; }
            get { return agama; }
        }

        private Grade grade = new Grade();
        public Grade Grade
        {
            set { grade = value; }
            get { return grade; }
        }

        private Level level = new Level();
        public Level Level
        {
            set { level = value; }
            get { return level; }
        }

        private Status_Pajak status_pajak = new Status_Pajak();
        public Status_Pajak Status_Pajak
        {
            set { status_pajak = value; }
            get { return status_pajak; }
        }
    }
}
