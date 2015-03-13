using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class GradeDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public GradeDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Grade MappingRowToObject(NpgsqlDataReader dtr)
        {
            Grade gd = new Grade();


            gd.Kode_Grade = dtr["kode_grade"] is DBNull ? string.Empty : dtr["kode_grade"].ToString();
            gd.Nama_Grade = dtr["nama_grade"] is DBNull ? string.Empty : dtr["nama_grade"].ToString();

            return gd;
        }

        public bool cekRecord(string kodGd)
        {
            Grade gd = GetByKodeGrade(kodGd);

            if (gd != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public Grade GetByKodeGrade(string kodGd)
        {
            Grade gd = null;

            strSql = "SELECT * FROM grade WHERE kode_grade = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodGd);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        gd = MappingRowToObject(dtr);
                    }
                }
            }

            return gd;
        }

        public List<Grade> GetAll()
        {
            List<Grade> daftarGd = new List<Grade>();

            strSql = "SELECT kode_grade, nama_grade FROM grade ORDER BY kode_grade";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarGd.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarGd;
        }

        //Method CRUD. Insert, Update, Delete, Select
        public int Save(Grade gd)
        {
            strSql = "INSERT INTO grade (kode_grade, nama_grade) VALUES (@1, @2)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", gd.Kode_Grade);
                cmd.Parameters.AddWithValue("@2", gd.Nama_Grade);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Grade gd)
        {
            strSql = "UPDATE grade SET nama_grade = @1 WHERE kode_grade = @2";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", gd.Nama_Grade);
                cmd.Parameters.AddWithValue("@2", gd.Kode_Grade);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string kodGd)
        {
            strSql = "DELETE FROM grade WHERE kode_grade = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodGd);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
