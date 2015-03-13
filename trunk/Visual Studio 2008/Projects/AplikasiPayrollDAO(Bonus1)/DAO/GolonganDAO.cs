using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MySql.Data.MySqlClient;
using AplikasiPayrollDAO.Model;

namespace AplikasiPayrollDAO.DAO
{
    
    public class GolonganDAO
    {
        
        private MySqlConnection conn;
        private string strSql = string.Empty;

        //constructor
        public GolonganDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        private Golongan MappingRowToObject(MySqlDataReader dtr)
        {
            Golongan glg = new Golongan();

            glg.Tk_Golongan = dtr["Golongan"] is DBNull ? string.Empty : dtr["Golongan"].ToString();
            glg.TJ_Suami_Istri = dtr["TJ_Suami_Istri"] is Nullable ? 0 : (int)dtr["TJ_Suami_Istri"];
            glg.TJ_Anak = dtr["TJ_Anak"] is Nullable ? 0 : (int)dtr["TJ_Anak"];
            glg.Uang_Makan = dtr["Uang_Makan"] is Nullable ? 0 : (int)dtr["Uang_Makan"];
            glg.Uang_Lembur = dtr["Uang_Lembur"] is Nullable ? 0 : (int)dtr["Uang_Lembur"];
            glg.Askes = dtr["Askes"] is Nullable ? 0 : (int)dtr["Askes"];

            return glg;
        }

        public Golongan GetByTkGolongan(string Tk_Golongan)
        {
            Golongan glg = null;

            strSql = "SELECT * FROM Golongan WHERE Golongan = @1";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", Tk_Golongan);

                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        glg = MappingRowToObject(dtr);
                    }
                }
            }

            return glg;
        }


        public List<Golongan> GetAll()
        {           
            List<Golongan> daftarGlg = new List<Golongan>();
            strSql = "SELECT Golongan, TJ_Suami_Istri, TJ_Anak, Uang_Makan, Uang_Lembur, Askes FROM Golongan ORDER BY Golongan";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarGlg.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarGlg;
        }

        public bool CheckRecords(string Tk_Golongan)
        {
            strSql = "SELECT * FROM Golongan WHERE Golongan = @1";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", Tk_Golongan);

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

        public int Update(Golongan glg)
        {
            strSql = "UPDATE Golongan SET TJ_Suami_Istri = @1, TJ_Anak = @2, Uang_Makan = @3, Uang_Lembur = @4, Askes = @5 WHERE Golongan = @6";
            
            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", glg.TJ_Suami_Istri);
                cmd.Parameters.AddWithValue("@2", glg.TJ_Anak);
                cmd.Parameters.AddWithValue("@3", glg.Uang_Makan);
                cmd.Parameters.AddWithValue("@4", glg.Uang_Lembur);
                cmd.Parameters.AddWithValue("@5", glg.Askes);
                cmd.Parameters.AddWithValue("@6", glg.Tk_Golongan);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Save(Golongan glg)
        {
            strSql = "INSERT INTO Golongan (Golongan, TJ_Suami_Istri, TJ_Anak, Uang_Makan, Uang_Lembur, Askes) VALUES (@1, @2, @3, @4, @5, @6)";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", glg.Tk_Golongan);
                cmd.Parameters.AddWithValue("@2", glg.TJ_Suami_Istri);
                cmd.Parameters.AddWithValue("@3", glg.TJ_Anak);
                cmd.Parameters.AddWithValue("@4", glg.Uang_Makan);
                cmd.Parameters.AddWithValue("@5", glg.Uang_Lembur);
                cmd.Parameters.AddWithValue("@6", glg.Askes);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string Tk_Golongan)
        {
            strSql = "DELETE FROM Golongan WHERE Golongan = @1";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", Tk_Golongan);

                return cmd.ExecuteNonQuery();
            }
        }

    }
}
