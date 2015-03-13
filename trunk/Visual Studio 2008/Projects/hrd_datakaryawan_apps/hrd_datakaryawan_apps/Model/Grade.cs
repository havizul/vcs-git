using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps.Model
{
    public class Grade
    {
        private string kode_grade;
        public string Kode_Grade
        {
            get { return kode_grade; }
            set { kode_grade = value; }
        }

        private string nama_grade;
        public string Nama_Grade
        {
            get { return nama_grade; }
            set { nama_grade = value; }
        }
    }
}
