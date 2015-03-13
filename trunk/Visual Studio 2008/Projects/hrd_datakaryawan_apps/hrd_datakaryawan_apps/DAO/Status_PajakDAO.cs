using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class Status_PajakDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public Status_PajakDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Status_Pajak MappingRowToObject(NpgsqlDataReader dtr)
        {
            Status_Pajak stPj = new Status_Pajak();

            stPj.Kode_Status_Pajak = dtr["kode_status_pajak"] is DBNull ? string.Empty : dtr["kode_status_pajak"].ToString();
            stPj.Keterangan = dtr["keterangan"] is DBNull ? string.Empty : dtr["keterangan"].ToString();

            return stPj;
        }

        public bool cekRecord(string kodStp)
        {
            Status_Pajak stPj = GetByKodeStatus(kodStp);

            if (stPj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method CRUD. Insert, Update, Delete, Select
        public int Save(Status_Pajak stPj)
        {
            strSql = "INSERT INTO status_pajak (kode_status_pajak, keterangan) VALUES (@1, @2)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", stPj.Kode_Status_Pajak);
                cmd.Parameters.AddWithValue("@2", stPj.Keterangan);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Status_Pajak stPj)
        {
            strSql = "UPDATE status_pajak SET kode_status_pajak = @1, keterangan = @2 WHERE kode_status_pajak = @3";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", stPj.Kode_Status_Pajak);
                cmd.Parameters.AddWithValue("@2", stPj.Keterangan);
                cmd.Parameters.AddWithValue("@3", stPj.Kode_Status_Pajak);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string kodStp)
        {
            strSql = "DELETE FROM status_pajak WHERE kode_status_pajak = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodStp);

                return cmd.ExecuteNonQuery();
            }
        }

        public Status_Pajak GetByKodeStatus(string kodStp)
        {
            Status_Pajak stPj = null;

            strSql = "SELECT * FROM status_pajak WHERE kode_status_pajak = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodStp);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        stPj = MappingRowToObject(dtr);
                    }
                }
            }

            return stPj;
        }

        public List<Status_Pajak> GetAll()
        {
            List<Status_Pajak> daftarStPj = new List<Status_Pajak>();

            strSql = "SELECT kode_status_pajak, keterangan FROM status_pajak ORDER BY kode_status_pajak";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarStPj.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarStPj;
        }
    }
}
