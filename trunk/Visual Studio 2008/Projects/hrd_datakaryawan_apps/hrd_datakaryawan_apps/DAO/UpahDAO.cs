using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class UpahDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public UpahDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Upah MappingRowToObject(NpgsqlDataReader dtr)
        {
            Upah up = new Upah();


            up.Kode_Upah = dtr["kode_upah"] is DBNull ? string.Empty : dtr["kode_upah"].ToString();
            up.Tipe_Upah = dtr["tipe_upah"] is DBNull ? string.Empty : dtr["tipe_upah"].ToString();

            return up;
        }

        public bool cekRecord(string kodUP)
        {
            Upah up = GetByKodeUpah(kodUP);

            if (up != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public Upah GetByKodeUpah(string kodUP)
        {
            Upah up = null;

            strSql = "SELECT * FROM upah WHERE kode_upah = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodUP);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        up = MappingRowToObject(dtr);
                    }
                }
            }

            return up;
        }

        public List<Upah> GetAll()
        {
            List<Upah> daftarUP = new List<Upah>();

            strSql = "SELECT kode_upah, tipe_upah FROM upah ORDER BY tipe_upah";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarUP.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarUP;
        }

        //Method CRUD. Insert, Update, Delete, Select
        public int Save(Upah up)
        {
            strSql = "INSERT INTO upah (kode_upah, tipe_upah) VALUES (@1, @2)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", up.Kode_Upah);
                //cmd.Parameters.AddWithValue("@1", "1");
                cmd.Parameters.AddWithValue("@2", up.Tipe_Upah);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Upah up)
        {
            strSql = "UPDATE upah SET tipe_upah = @1 WHERE kode_upah = @2";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", up.Tipe_Upah);
                cmd.Parameters.AddWithValue("@2", up.Kode_Upah);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string kodUP)
        {
            strSql = "DELETE FROM upah WHERE kode_upah = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodUP);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
