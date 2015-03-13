using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;  //Tambahkan Namespace untuk mengakses database mysql
using AplikasiPayrollDAO.Model; //Tambahkan namespace untuk mengakses class Jabatan.cs

namespace AplikasiPayrollDAO.DAO
{
    public class JabatanDAO
    {
        private MySqlConnection conn;
        private string strSql = string.Empty;

        //constructor
        public JabatanDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public int Save(Jabatan jbt)
        {
            strSql = "INSERT INTO Jabatan (Kode_Jabatan, Nama_Jabatan, Gaji_Pokok, TJ_Jabatan) VALUES (@1, @2, @3, @4)";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", jbt.Kode_Jabatan);
                cmd.Parameters.AddWithValue("@2", jbt.Nama_Jabatan);
                cmd.Parameters.AddWithValue("@3", jbt.Gaji_Pokok);
                cmd.Parameters.AddWithValue("@4", jbt.TJ_Jabatan);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Jabatan jbt)
        {
            strSql = "UPDATE Jabatan SET Nama_Jabatan = @1, Gaji_Pokok = @2, TJ_Jabatan = @3 WHERE Kode_Jabatan = @4";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", jbt.Nama_Jabatan);
                cmd.Parameters.AddWithValue("@2", jbt.Gaji_Pokok);
                cmd.Parameters.AddWithValue("@3", jbt.TJ_Jabatan);
                cmd.Parameters.AddWithValue("@4", jbt.Kode_Jabatan);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string Kode_Jabatan)
        {
            strSql = "DELETE FROM Jabatan WHERE Kode_Jabatan = @1";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", Kode_Jabatan);

                return cmd.ExecuteNonQuery();
            }
        }

        //Method MappingRowToObject, GetAll & GetByKodeJabatan
        public Jabatan MappingRowToObject(MySqlDataReader dtr)
        {
            Jabatan jbt = new Jabatan();

            jbt.Kode_Jabatan = dtr["Kode_Jabatan"] is DBNull ? string.Empty : dtr["Kode_Jabatan"].ToString();
            jbt.Nama_Jabatan = dtr["Nama_Jabatan"] is DBNull ? string.Empty : dtr["Nama_Jabatan"].ToString();
            jbt.Gaji_Pokok = dtr["Gaji_Pokok"] is Nullable ? 0 : (int)dtr["Gaji_Pokok"];
            jbt.TJ_Jabatan = dtr["TJ_Jabatan"] is Nullable ? 0 : (int)dtr["TJ_Jabatan"];

            return jbt;
        }

        public List<Jabatan> GetAll()
        {
            List<Jabatan> daftarJbt = new List<Jabatan>();
            strSql = "SELECT * FROM Jabatan ORDER BY Kode_Jabatan";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarJbt.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarJbt;
        }

        public Jabatan GetByKodeJabatan(string Kode_Jabatan)
        {
            Jabatan jbt = null;

            strSql = "SELECT * FROM Jabatan WHERE Kode_Jabatan = @1";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", Kode_Jabatan);

                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        jbt = MappingRowToObject(dtr);
                    }
                }
            }

            return jbt;
        }

        public bool CheckRecords(string Kode_Jabatan)
        {
            strSql = "SELECT * FROM Jabatan WHERE Kode_Jabatan = @1";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", Kode_Jabatan);

                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
