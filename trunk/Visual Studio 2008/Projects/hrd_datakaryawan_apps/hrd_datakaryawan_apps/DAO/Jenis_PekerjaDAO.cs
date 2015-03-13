using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class Jenis_PekerjaDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public Jenis_PekerjaDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Jenis_Pekerja MappingRowToObject(NpgsqlDataReader dtr)
        {
            Jenis_Pekerja jp = new Jenis_Pekerja();

            
            jp.Kode_Jenis_Pekerja = dtr["kode_jenis_pekerja"] is DBNull ? string.Empty : dtr["kode_jenis_pekerja"].ToString();
            jp.Nama_Jenis_Pekerja = dtr["nama_jenis_pekerja"] is DBNull ? string.Empty : dtr["nama_jenis_pekerja"].ToString();

            return jp;
        }

        public bool cekRecord(string kodJP)
        {
            Jenis_Pekerja jp = GetByKodeJenisPekerja(kodJP);

            if (jp != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method CRUD. Insert, Update, Delete, Select
        public int Save(Jenis_Pekerja jp)
        {
            strSql = "INSERT INTO jenis_pekerja (kode_jenis_pekerja, nama_jenis_pekerja) VALUES (@1, @2)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", jp.Kode_Jenis_Pekerja);
                cmd.Parameters.AddWithValue("@2", jp.Nama_Jenis_Pekerja);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Jenis_Pekerja jp)
        {
            strSql = "UPDATE jenis_pekerja SET nama_jenis_pekerja = @1 WHERE kode_jenis_pekerja = @2";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", jp.Nama_Jenis_Pekerja);
                cmd.Parameters.AddWithValue("@2", jp.Kode_Jenis_Pekerja);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string kodJP)
        {
            strSql = "DELETE FROM jenis_pekerja WHERE kode_jenis_pekerja = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodJP);

                return cmd.ExecuteNonQuery();
            }
        }

        public Jenis_Pekerja GetByKodeJenisPekerja(string kodJP)
        {
            Jenis_Pekerja jp = null;

            strSql = "SELECT * FROM jenis_pekerja WHERE kode_jenis_pekerja = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodJP);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        jp = MappingRowToObject(dtr);
                    }
                }
            }

            return jp;
        }

        public List<Jenis_Pekerja> GetAll()
        {
            List<Jenis_Pekerja> daftarJP = new List<Jenis_Pekerja>();

            strSql = "SELECT kode_jenis_pekerja, nama_jenis_pekerja FROM jenis_pekerja ORDER BY nama_jenis_pekerja";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarJP.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarJP;
        }
    }
}
