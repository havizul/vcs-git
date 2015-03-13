using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class JabatanDAO
    {
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public JabatanDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Jabatan MappingRowToObject(NpgsqlDataReader dtr)
        {
            Jabatan jbt = new Jabatan();

            jbt.Kode_Jabatan = dtr["kode_jabatan"] is DBNull ? string.Empty : dtr["kode_jabatan"].ToString();
            jbt.Nama_Jabatan = dtr["nama_jabatan"] is DBNull ? string.Empty : dtr["nama_jabatan"].ToString();

            return jbt;
        }

        public bool cekRecord(string kodJbt)
        {
            Jabatan dept = GetByKodeJabatan(kodJbt);

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
        public int Save(Jabatan jbt)
        {
            strSql = "INSERT INTO jabatan (kode_jabatan, nama_jabatan) VALUES (@1, @2)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", jbt.Kode_Jabatan);
                cmd.Parameters.AddWithValue("@2", jbt.Nama_Jabatan);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Jabatan jbt)
        {
            strSql = "UPDATE jabatan SET nama_jabatan = @1 WHERE kode_jabatan = @2";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", jbt.Nama_Jabatan);
                cmd.Parameters.AddWithValue("@2", jbt.Kode_Jabatan);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string kodJbt)
        {
            strSql = "DELETE FROM jabatan WHERE kode_jabatan = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodJbt);

                return cmd.ExecuteNonQuery();
            }
        }

        public Jabatan GetByKodeJabatan(string kodJbt)
        {
            Jabatan jbt = null;

            strSql = "SELECT * FROM jabatan WHERE kode_jabatan = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodJbt);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        jbt = MappingRowToObject(dtr);
                    }
                }
            }

            return jbt;
        }

        public List<Jabatan> GetAll()
        {
            List<Jabatan> daftarJbt = new List<Jabatan>();

            strSql = "SELECT kode_jabatan AS Kode_Jabatan, nama_jabatan AS Nama_Jabatan FROM jabatan ORDER BY nama_jabatan";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarJbt.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarJbt;
        }
    }
}
