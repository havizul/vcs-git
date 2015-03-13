using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class KaryawanDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;
    
        //Constructor
        public KaryawanDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Karyawan MappingRowToObject(NpgsqlDataReader dtr)
        {
            Karyawan kry = new Karyawan();

            kry.NIK = dtr["nik"] is DBNull ? string.Empty : dtr["nik"].ToString();
            kry.Nama = dtr["nama"] is DBNull ? string.Empty : dtr["nama"].ToString();
            kry.Nick_Name = dtr["nick_name"] is DBNull ? string.Empty : dtr["nick_name"].ToString();
            kry.Tempat_lahir = dtr["tempat_lahir"] is DBNull ? string.Empty : dtr["tempat_lahir"].ToString();
   
            kry.Tanggal_Lahir = dtr["tanggal_lahir"] is DBNull ? DateTime.MinValue : DateTime.Parse(dtr["tanggal_lahir"].ToString());
            kry.Jenis_Kelamin = dtr["jenis_kelamin"] is DBNull ? string.Empty : dtr["jenis_kelamin"].ToString();
            kry.Status_Nikah = dtr["status_nikah"] is DBNull ? string.Empty : dtr["status_nikah"].ToString();
            kry.Kewaganegaraan = dtr["kewarganegaraan"] is DBNull ? string.Empty : dtr["kewarganegaraan"].ToString();
            kry.Golongan_Darah = dtr["golongan_darah"] is DBNull ? string.Empty : dtr["golongan_darah"].ToString();
            kry.Asuransi = dtr["asuransi"] is DBNull ? string.Empty : dtr["asuransi"].ToString();
            kry.Jamsostek = dtr["jamsostek"] is DBNull ? string.Empty : dtr["jamsostek"].ToString();
            kry.NPWP = dtr["npwp"] is DBNull ? string.Empty : dtr["npwp"].ToString();
            kry.Status_Pekerja.Status = dtr["nama_status"] is DBNull ? string.Empty : dtr["nama_status"].ToString();
            kry.Jenis_Pekerja.Nama_Jenis_Pekerja = dtr["nama_jenis_pekerja"] is DBNull ? string.Empty : dtr["nama_jenis_pekerja"].ToString();
            kry.Upah.Tipe_Upah = dtr["tipe_upah"] is DBNull ? string.Empty : dtr["tipe_upah"].ToString();
            kry.Agama.Nama_Agama = dtr["nama_agama"] is DBNull ? string.Empty : dtr["nama_agama"].ToString();
            kry.Grade.Nama_Grade = dtr["nama_grade"] is DBNull ? string.Empty : dtr["nama_grade"].ToString();           
            kry.Level.Nama_Level = dtr["nama_level"] is DBNull ? string.Empty : dtr["nama_level"].ToString();
            kry.Status_Pajak.Kode_Status_Pajak = dtr["kode_status_pajak"] is DBNull ? string.Empty : dtr["kode_status_pajak"].ToString();

            return kry;
        }

        public bool cekRecord(string nik)
        {
            Karyawan kry = GetByNIK(nik);

            if (kry != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method CRUD. Insert, Update, Delete, Select
        public int Save(Karyawan kry)
        {
            strSql = "INSERT INTO karyawan (nik, nama, nick_name, tempat_lahir, tanggal_lahir, status_nikah, kewarganegaraan, golongan_darah, asuransi, jamsostek, npwp, kode_status_pekerja, kode_upah, id_agama, kode_grade, kode_level, kode_status_pajak, kode_jenis_pekerja, jenis_kelamin) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19)";
            //strSql = "INSERT INTO karyawan (nik, nama, nick_name, tempat_lahir, tanggal_lahir, kewarganegaraan, golongan_darah, asuransi, jamsostek, npwp, kode_status_pekerja, kode_upah, id_agama, kode_grade, kode_level, kode_status_pajak, kode_jenis_pekerja, jenis_kelamin) VALUES (@1, @2, @3, @4, @5, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19)";


            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kry.NIK);
                cmd.Parameters.AddWithValue("@2", kry.Nama);
                cmd.Parameters.AddWithValue("@3", kry.Nick_Name);
                cmd.Parameters.AddWithValue("@4", kry.Tempat_lahir);
                cmd.Parameters.AddWithValue("@5", kry.Tanggal_Lahir);
                cmd.Parameters.AddWithValue("@6", kry.Status_Nikah);
                cmd.Parameters.AddWithValue("@7", kry.Kewaganegaraan);
                cmd.Parameters.AddWithValue("@8", kry.Golongan_Darah);
                cmd.Parameters.AddWithValue("@9", kry.Asuransi);
                cmd.Parameters.AddWithValue("@10", kry.Jamsostek);
                cmd.Parameters.AddWithValue("@11", kry.NPWP);
                cmd.Parameters.AddWithValue("@12", kry.Status_Pekerja.Kode_Status);
                cmd.Parameters.AddWithValue("@13", kry.Upah.Kode_Upah);
                cmd.Parameters.AddWithValue("@14", kry.Agama.Id_Agama);
                cmd.Parameters.AddWithValue("@15", kry.Grade.Kode_Grade);
                cmd.Parameters.AddWithValue("@16", kry.Level.Kode_Level);
                cmd.Parameters.AddWithValue("@17", kry.Status_Pajak.Kode_Status_Pajak);
                cmd.Parameters.AddWithValue("@18", kry.Jenis_Pekerja.Kode_Jenis_Pekerja);
                cmd.Parameters.AddWithValue("@19", kry.Jenis_Kelamin);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Karyawan kry)
        {
            strSql = "UPDATE karyawan SET nama = @1, nick_name = @2, tempat_lahir = @3, tanggal_lahir = @4, status_nikah = @5, kewarganegaraan = @6, golongan_darah = @7, asuransi = @8, jamsostek = @9, npwp = @10, kode_status_pekerja = @11, kode_upah = @12, id_agama = @13, kode_grade = @14, kode_level = @15, kode_status_pajak = @16, kode_jenis_pekerja = @17, jenis_kelamin = @18 WHERE nik = @19";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {                
                cmd.Parameters.AddWithValue("@1", kry.Nama);
                cmd.Parameters.AddWithValue("@2", kry.Nick_Name);
                cmd.Parameters.AddWithValue("@3", kry.Tempat_lahir);
                cmd.Parameters.AddWithValue("@4", kry.Tanggal_Lahir);
                cmd.Parameters.AddWithValue("@5", kry.Status_Nikah);
                cmd.Parameters.AddWithValue("@6", kry.Kewaganegaraan);
                cmd.Parameters.AddWithValue("@7", kry.Golongan_Darah);
                cmd.Parameters.AddWithValue("@8", kry.Asuransi);
                cmd.Parameters.AddWithValue("@9", kry.Jamsostek);
                cmd.Parameters.AddWithValue("@10", kry.NPWP);
                cmd.Parameters.AddWithValue("@11", kry.Status_Pekerja.Kode_Status);
                cmd.Parameters.AddWithValue("@12", kry.Upah.Kode_Upah);
                cmd.Parameters.AddWithValue("@13", kry.Agama.Id_Agama);
                cmd.Parameters.AddWithValue("@14", kry.Grade.Kode_Grade);
                cmd.Parameters.AddWithValue("@15", kry.Level.Kode_Level);
                cmd.Parameters.AddWithValue("@16", kry.Status_Pajak.Kode_Status_Pajak);
                cmd.Parameters.AddWithValue("@17", kry.Jenis_Pekerja.Kode_Jenis_Pekerja);
                cmd.Parameters.AddWithValue("@18", kry.Jenis_Kelamin);
                cmd.Parameters.AddWithValue("@19", kry.NIK);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string nik)
        {
            strSql = "DELETE FROM karyawan WHERE nik = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);

                return cmd.ExecuteNonQuery();
            }
        }

        public Karyawan GetByNIK(string nik)
        {
            Karyawan kry = null;

            //strSql = "SELECT * FROM karyawan WHERE nik = @1";
            strSql = "SELECT karyawan.nik, karyawan.nama, karyawan.nick_name, karyawan.tempat_lahir, karyawan.tanggal_lahir, karyawan.jenis_kelamin, karyawan.status_nikah, karyawan.kewarganegaraan, karyawan.golongan_darah, karyawan.asuransi, karyawan.jamsostek, karyawan.npwp, status_pekerja.nama_status, jenis_pekerja.nama_jenis_pekerja, upah.tipe_upah, agama.nama_agama, grade.nama_grade, level.nama_level, status_pajak.kode_status_pajak FROM karyawan , status_pekerja, jenis_pekerja, upah, agama, grade, level, status_pajak WHERE status_pekerja.kode_status=karyawan.kode_status_pekerja AND jenis_pekerja.kode_jenis_pekerja=karyawan.kode_jenis_pekerja AND upah.kode_upah=karyawan.kode_upah AND agama.id_agama=karyawan.id_agama AND grade.kode_grade=karyawan.kode_grade AND level.kode_level=karyawan.kode_level AND status_pajak.kode_status_pajak=karyawan.kode_status_pajak AND nik = @1 ORDER BY nik";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        kry = MappingRowToObject(dtr);
                    }
                }
            }

            return kry;
        }


        public List<Karyawan> GetAll()
        {
            List<Karyawan> daftarKry = new List<Karyawan>();

            //strSql = "SELECT nik, nama, nick_name, tempat_lahir, tanggal_lahir, jenis_kelamin, status_nikah, kewarganegaraan, golongan_darah, asuransi, jamsostek, npwp, kode_status_pekerja, kode_upah, id_agama, kode_grade, kode_level, kode_status_pajak, kode_jenis_pekerja, kode_upah, id_agama, kode_grade, kode_level, kode_status_pajak FROM karyawan ORDER BY nik";
            strSql = "SELECT karyawan.nik, karyawan.nama, karyawan.nick_name, karyawan.tempat_lahir, karyawan.tanggal_lahir, karyawan.jenis_kelamin, karyawan.status_nikah, karyawan.kewarganegaraan, karyawan.golongan_darah, karyawan.asuransi, karyawan.jamsostek, karyawan.npwp, status_pekerja.nama_status, jenis_pekerja.nama_jenis_pekerja, upah.tipe_upah, agama.nama_agama, grade.nama_grade, level.nama_level, status_pajak.kode_status_pajak FROM karyawan , status_pekerja, jenis_pekerja, upah, agama, grade, level, status_pajak WHERE status_pekerja.kode_status=karyawan.kode_status_pekerja AND jenis_pekerja.kode_jenis_pekerja=karyawan.kode_jenis_pekerja AND upah.kode_upah=karyawan.kode_upah AND agama.id_agama=karyawan.id_agama AND grade.kode_grade=karyawan.kode_grade AND level.kode_level=karyawan.kode_level AND status_pajak.kode_status_pajak=karyawan.kode_status_pajak ORDER BY nik";
            //strSql = "SELECT karyawan.nik, karyawan.nama, karyawan.nick_name, karyawan.tempat_lahir, karyawan.tanggal_lahir, karyawan.jenis_kelamin, karyawan.status_nikah, karyawan.kewarganegaraan, karyawan.golongan_darah, karyawan.asuransi, karyawan.jamsostek, karyawan.npwp, status_pekerja.nama_status, upah.tipe_upah, agama.nama_agama, jenis_pekerja.nama_jenis_pekerja, upah.tipe_upah, agama.nama_agama, grade.nama_grade, level.nama_level, status_pajak.kode_status_pajak, FROM karyawan, status_pekerja, jenis_pekerja, upah, agama, grade, level, status_pajak WHERE karyawan.nik='12345678' ORDER BY nik";
            //strSql = "SELECT karyawan.nik, karyawan.nama, karyawan.nick_name, karyawan.tempat_lahir, karyawan.tanggal_lahir, karyawan.jenis_kelamin, karyawan.status_nikah, karyawan.kewarganegaraan, karyawan.golongan_darah, karyawan.asuransi, karyawan.jamsostek, karyawan.npwp, status_pekerja.nama_status, jenis_pekerja.nama_jenis_pekerja, upah.tipe_upah, agama.nama_agama, grade.nama_grade, level.nama_level, status_pajak.kode_status_pajak, FROM karyawan, status_pekerja, jenis_pekerja, upah, agama, grade, level, status_pajak WHERE jenis_pekerja.kode_jenis_pekerja=karyawan.kode_jenis_pekerja AND upah.kode_upah=karyawan.kode_upah AND agama.id_agama=karyawan.id_agama AND grade.kode_grade=karyawan.kode_grade AND level.kode_level=karyawan.kode_level AND status_pajak.kode_status_pajak=karyawan.kode_status_pajak ORDER BY nik";
           


            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarKry.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarKry;
        }
    }
}
