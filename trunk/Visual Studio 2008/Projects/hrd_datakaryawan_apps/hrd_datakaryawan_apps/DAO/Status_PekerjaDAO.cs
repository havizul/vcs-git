using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class Status_PekerjaDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public Status_PekerjaDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Status_Pekerja MappingRowToObject(NpgsqlDataReader dtr)
        {
            Status_Pekerja stP = new Status_Pekerja();

            //stP.Kode_Status = dtr[0] is DBNull ? string.Empty : dtr[0].ToString();
            //stP.Status = dtr[1] is DBNull ? string.Empty : dtr[1].ToString();
            //stP.Kode_Status = dtr["kode_status_pekerja"] is DBNull ? string.Empty : dtr["kode_status_pekerja"].ToString();
            //stP.Status = dtr["status_pekerja"] is DBNull ? string.Empty : dtr["status_pekerja"].ToString();
            stP.Kode_Status = dtr["kode_status"] is DBNull ? string.Empty : dtr["kode_status"].ToString();
            stP.Status = dtr["nama_status"] is DBNull ? string.Empty : dtr["nama_status"].ToString();

            return stP;
        }
        
        public bool cekRecord(string kodStat)
        {
            Status_Pekerja stP = GetByKodeStatus(kodStat);

            if (stP != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method CRUD. Insert, Update, Delete, Select
        public int Save(Status_Pekerja stP)
        {
            strSql = "INSERT INTO status_pekerja (kode_status, nama_status) VALUES (@1, @2)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", stP.Kode_Status);
                cmd.Parameters.AddWithValue("@2", stP.Status);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Status_Pekerja stP)
        {
            strSql = "UPDATE status_pekerja SET nama_status = @1 WHERE kode_status = @2";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", stP.Status);
                cmd.Parameters.AddWithValue("@2", stP.Kode_Status);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string kodStat)
        {
            strSql = "DELETE FROM status_pekerja WHERE kode_status = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodStat);

                return cmd.ExecuteNonQuery();
            }
        }

        public Status_Pekerja GetByKodeStatus(string kodStat)
        {
            Status_Pekerja stP = null;

            strSql = "SELECT * FROM status_pekerja WHERE kode_status = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodStat);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        stP = MappingRowToObject(dtr);
                    }
                }
            }

            return stP;
        }

        public List<Status_Pekerja> GetAll()
        {
            List<Status_Pekerja> daftarStP = new List<Status_Pekerja>();

            strSql = "SELECT kode_status, nama_status FROM status_pekerja ORDER BY nama_status";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarStP.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarStP;
        }
    }
}
