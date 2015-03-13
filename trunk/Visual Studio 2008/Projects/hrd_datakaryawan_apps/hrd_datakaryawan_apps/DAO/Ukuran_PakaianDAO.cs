using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class Ukuran_PakaianDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public Ukuran_PakaianDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Ukuran_Pakaian MappingRowToObject(NpgsqlDataReader dtr)
        {
            Ukuran_Pakaian upk = new Ukuran_Pakaian();

            upk.NIK = dtr["nik"] is DBNull ? string.Empty : dtr["nik"].ToString();
            upk.Ukuran_Baju = dtr["ukuran_baju"] is DBNull ? string.Empty : dtr["ukuran_baju"].ToString();
            upk.Ukuran_Celana = dtr["ukuran_celana"] is DBNull ? string.Empty : dtr["ukuran_celana"].ToString();
            upk.Ukuran_Sepatu = dtr["ukuran_sepatu"] is DBNull ? string.Empty : dtr["ukuran_sepatu"].ToString();

            return upk;
        }

        public bool cekRecord(string nik)
        {
            Ukuran_Pakaian upk = GetByNIK(nik);

            if (upk != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public Ukuran_Pakaian GetByNIK(string nik)
        {
            Ukuran_Pakaian upk = null;

            strSql = "SELECT * FROM ukuran_pakaian WHERE nik = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        upk = MappingRowToObject(dtr);
                    }
                }
            }

            return upk;
        }

        public List<Ukuran_Pakaian> GetAll()
        {
            List<Ukuran_Pakaian> daftarUpk = new List<Ukuran_Pakaian>();

            strSql = "SELECT nik, ukuran_baju, ukuran_celana, ukuran_sepatu ORDER BY nik";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarUpk.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarUpk;
        }

        //Method CRUD. Insert, Update, Delete, Select
        public int Save(Ukuran_Pakaian upk)
        {
            strSql = "INSERT INTO ukuran_pakaian (nik, ukuran_baju, ukuran_celana, ukuran_sepatu) VALUES (@1, @2, @3, @4)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", upk.NIK);
                cmd.Parameters.AddWithValue("@2", upk.Ukuran_Baju);
                cmd.Parameters.AddWithValue("@3", upk.Ukuran_Celana);
                cmd.Parameters.AddWithValue("@4", upk.Ukuran_Sepatu);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Ukuran_Pakaian upk)
        {
            strSql = "UPDATE ukuran_pakaian SET ukuran_baju = @1, ukuran_celana = @2, ukuran_sepatu = @3 WHERE nik = @4";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", upk.Ukuran_Baju);
                cmd.Parameters.AddWithValue("@2", upk.Ukuran_Celana);
                cmd.Parameters.AddWithValue("@3", upk.Ukuran_Sepatu);
                cmd.Parameters.AddWithValue("@4", upk.NIK);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string nik)
        {
            strSql = "DELETE FROM ukuran_pakaian WHERE nik = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
