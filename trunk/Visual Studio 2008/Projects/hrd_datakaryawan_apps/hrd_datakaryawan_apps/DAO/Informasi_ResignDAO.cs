using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class Informasi_ResignDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public Informasi_ResignDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Informasi_Resign MappingRowToObject(NpgsqlDataReader dtr)
        {
            Informasi_Resign irs = new Informasi_Resign();

            irs.NIK = dtr["nik"] is DBNull ? string.Empty : dtr["nik"].ToString();
            irs.Status_Resign = dtr["status_resign"] is DBNull ? string.Empty : dtr["status_resign"].ToString();
            irs.Tanggal_Resign = dtr["tanggal_resign"] is DBNull ? DateTime.MinValue : DateTime.Parse(dtr["tanggal_resign"].ToString());
            //irs.Tanggal_Resign = dtr["tanggal_resign"] is DBNull ? DateTime.MinValue : DateTime.Parse(string.Format("{0:dd/MM/yyyy}", dtr["tanggal_resign"].ToString()));
            irs.Alasan_Resign = dtr["alasan_resign"] is DBNull ? string.Empty : dtr["alasan_resign"].ToString();

            return irs;
        }     
                
        public bool cekRecord(string nik)
        {
            Informasi_Resign irs = GetByNIK(nik);

            if (irs != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public Informasi_Resign GetByNIK(string nik)
        {
            Informasi_Resign infoResign = null; //= new Informasi_Resign();

            strSql = "SELECT * FROM informasi_resign WHERE nik = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        infoResign = (MappingRowToObject(dtr));
                    }
                }
            }

            return infoResign;
        }

        
        /*
        public List<Informasi_Resign> GetAll()
        {
            List<Informasi_Resign> daftarIrs = new List<Informasi_Resign>();

            strSql = "SELECT nik, tanggal_resign, status_resign, alasan_resign ORDER BY nik";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarIrs.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarIrs;
        }
        */


        //Method CRUD. Insert, Update, Delete, Select
        public int Save(Informasi_Resign irs)
        {
            strSql = "INSERT INTO informasi_resign (nik, status_resign, tanggal_resign, alasan_resign) VALUES (@1, @2, @3, @4)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", irs.NIK);
                cmd.Parameters.AddWithValue("@2", irs.Status_Resign);
                cmd.Parameters.AddWithValue("@3", irs.Tanggal_Resign);
                cmd.Parameters.AddWithValue("@4", irs.Alasan_Resign);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Informasi_Resign irs)
        {
            strSql = "UPDATE informasi_resign SET status_resign = @1, tanggal_resign = @2, alasan_resign = @3 WHERE nik = @4";
            
            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", irs.Status_Resign);
                cmd.Parameters.AddWithValue("@2", irs.Tanggal_Resign);
                cmd.Parameters.AddWithValue("@3", irs.Alasan_Resign);
                cmd.Parameters.AddWithValue("@4", irs.NIK);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string nik)
        {
            strSql = "DELETE FROM informasi_resign WHERE nik = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);

                return cmd.ExecuteNonQuery();
            }
        }       
       
    }
}
 