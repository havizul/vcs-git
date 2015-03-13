using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class LevelDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public LevelDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Level MappingRowToObject(NpgsqlDataReader dtr)
        {
            Level lv = new Level();

            lv.Kode_Level = dtr["kode_level"] is DBNull ? string.Empty : dtr["kode_level"].ToString();
            lv.Nama_Level = dtr["nama_level"] is DBNull ? string.Empty : dtr["nama_level"].ToString();

            return lv;
        }

        public bool cekRecord(string kodLv)
        {
            Level lv = GetByKodeLevel(kodLv);

            if (lv != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public Level GetByKodeLevel(string kodLv)
        {
            Level lv = null;

            strSql = "SELECT * FROM Level WHERE kode_level = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodLv);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        lv = MappingRowToObject(dtr);
                    }
                }
            }

            return lv;
        }

        public List<Level> GetAll()
        {
            List<Level> daftarLv = new List<Level>();

            strSql = "SELECT kode_level, nama_level FROM level ORDER BY kode_level";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarLv.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarLv;
        }

        //Method CRUD. Insert, Update, Delete, Select
        public int Save(Level lv)
        {
            strSql = "INSERT INTO level (kode_level, nama_level) VALUES (@1, @2)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", lv.Kode_Level);
                cmd.Parameters.AddWithValue("@2", lv.Nama_Level);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Level lv)
        {
            strSql = "UPDATE level SET nama_level = @1 WHERE kode_level = @2";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", lv.Nama_Level);
                cmd.Parameters.AddWithValue("@2", lv.Kode_Level);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string kodLv)
        {
            strSql = "DELETE FROM level WHERE kode_level = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodLv);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
