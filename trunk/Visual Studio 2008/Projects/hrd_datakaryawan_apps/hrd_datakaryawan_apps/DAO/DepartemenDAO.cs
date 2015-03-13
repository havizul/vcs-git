using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class DepartemenDAO
    {
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public DepartemenDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Departemen MappingRowToObject(NpgsqlDataReader dtr)
        {
            Departemen dept = new Departemen();

            dept.Kode_Departemen = dtr["kode_departemen"] is DBNull ? string.Empty : dtr["kode_departemen"].ToString();
            dept.Nama_Departemen = dtr["nama_departemen"] is DBNull ? string.Empty : dtr["nama_departemen"].ToString();

            return dept;
        }

        public bool cekRecord(string kodDept)
        {
            Departemen dept = GetByKodeDepartemen(kodDept);

            if (dept != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method CRUD (Insert, Update, Delete, Select)
        public int Save(Departemen dept)
        {
            strSql = "INSERT INTO departemen (kode_departemen, nama_departemen) VALUES (@1, @2)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", dept.Kode_Departemen);
                cmd.Parameters.AddWithValue("@2", dept.Nama_Departemen);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Departemen dept)
        {
            strSql = "UPDATE departemen SET nama_departemen = @1 WHERE kode_departemen = @2";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", dept.Nama_Departemen);
                cmd.Parameters.AddWithValue("@2", dept.Kode_Departemen);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string kodDept)
        {
            strSql = "DELETE FROM departemen WHERE kode_departemen = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodDept);

                return cmd.ExecuteNonQuery();
            }
        }

        public Departemen GetByKodeDepartemen(string kodDept)
        {
            Departemen dept = null;

            strSql = "SELECT * FROM departemen WHERE kode_departemen = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodDept);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        dept = MappingRowToObject(dtr);
                    }
                }
            }

            return dept;
        }

        public List<Departemen> GetAll()
        {
            List<Departemen> daftarDept = new List<Departemen>();

            strSql = "SELECT kode_departemen AS Kode_Departemen, nama_departemen AS Nama_Departemen FROM departemen ORDER BY nama_departemen";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarDept.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarDept;
        }
    }
}
