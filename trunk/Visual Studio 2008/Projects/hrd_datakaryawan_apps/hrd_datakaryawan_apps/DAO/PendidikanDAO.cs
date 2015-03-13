using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class PendidikanDAO
    {
        //Variabel global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public PendidikanDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Pendidikan MappingRowToObject(NpgsqlDataReader dtr)
        {
            Pendidikan pdk = new Pendidikan();

            pdk.Id_Pendidikan = dtr["id_pendidikan"] is DBNull ? 0 : (int)dtr["id_pendidikan"];
            pdk.Jenjang_Pendidikan = dtr["jenjang_pendidikan"] is DBNull ? string.Empty : dtr["jenjang_pendidikan"].ToString();
            pdk.Lembaga = dtr["lembaga"] is DBNull ? string.Empty : dtr["lembaga"].ToString();
            pdk.Jurusan = dtr["jurusan"] is DBNull ? string.Empty : dtr["jurusan"].ToString();
            pdk.Tahun_masuk = dtr["tahun_masuk"] is DBNull ? DateTime.MinValue : DateTime.Parse(dtr["tahun_masuk"].ToString());
            pdk.Tahun_lulus = dtr["tahun_lulus"] is DBNull ? DateTime.MinValue : DateTime.Parse(dtr["tahun_lulus"].ToString());
            pdk.Jenis_Pendidikan = dtr["jenis_pendidikan"] is DBNull ? string.Empty : dtr["jenis_pendidikan"].ToString();
            pdk.NIK = dtr["nik"] is DBNull ? string.Empty : dtr["nik"].ToString();

            return pdk;
        }

        //CRUD Operation
        public int Save(Pendidikan pdk)
        {
            strSql = "INSERT INTO pendidikan (id_pendidikan, jenjang_pendidikan, lembaga, jurusan, tahun_masuk, tahun_lulus, jenis_pendidikan, nik) VALUES (DEFAULT, @2, @3, @4, @5, @6, @7, @8)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@2", pdk.Jenjang_Pendidikan);
                cmd.Parameters.AddWithValue("@3", pdk.Lembaga);
                cmd.Parameters.AddWithValue("@4", pdk.Jurusan);
                cmd.Parameters.AddWithValue("@5", pdk.Tahun_masuk);
                cmd.Parameters.AddWithValue("@6", pdk.Tahun_lulus);
                cmd.Parameters.AddWithValue("@7", pdk.Jenis_Pendidikan);
                cmd.Parameters.AddWithValue("@8", pdk.NIK);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Pendidikan pdk)
        {
            strSql = "UPDATE pendidikan SET jenjang_pendidikan = @1, lembaga = @2, jurusan = @3, tahun_masuk = @4, tahun_lulus = @5, jenis_pendidikan = @6, nik = @7 WHERE id_pendidikan = @8";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", pdk.Jenjang_Pendidikan);
                cmd.Parameters.AddWithValue("@2", pdk.Lembaga);
                cmd.Parameters.AddWithValue("@3", pdk.Jurusan);
                cmd.Parameters.AddWithValue("@4", pdk.Tahun_masuk);
                cmd.Parameters.AddWithValue("@5", pdk.Tahun_lulus);
                cmd.Parameters.AddWithValue("@6", pdk.Jenis_Pendidikan);
                cmd.Parameters.AddWithValue("@7", pdk.NIK);
                cmd.Parameters.AddWithValue("@8", pdk.Id_Pendidikan);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int id_pendidikan)
        {
            strSql = "DELETE FROM pendidikan WHERE id_pendidikan = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", id_pendidikan);

                return cmd.ExecuteNonQuery();
            }
        }

        public Pendidikan getInfoPendidikanByJenjang(string jenjang, string nik)
        {
            Pendidikan Pdk = null;

            strSql = "SELECT * FROM pendidikan WHERE jenjang_pendidikan = @1 AND nik = @2";
            //strSql = "SELECT * FROM pendidikan WHERE jenjang_pendidikan = 'SD' AND nik = '1.1.12.0045'";
            
            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", jenjang);
                cmd.Parameters.AddWithValue("@2", nik);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        Pdk = MappingRowToObject(dtr);                     
                    }
                }

                return Pdk;
            }
        }

        public List<Pendidikan> getInfoPendidikanByNik(string nik)
        {
            List<Pendidikan> daftarPdk = new List<Pendidikan>();

            strSql = "SELECT * FROM pendidikan WHERE nik = @1";
            
            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarPdk.Add(MappingRowToObject(dtr));
                    }
                }

                return daftarPdk;
            }
        }

        //Extra Method
        
    }
}
