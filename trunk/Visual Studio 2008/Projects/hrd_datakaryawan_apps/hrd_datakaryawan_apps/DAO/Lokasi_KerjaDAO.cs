using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class Lokasi_KerjaDAO
    {
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //constructor
        public Lokasi_KerjaDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        //Method CRUD PostgreSQL
        public int Update(Lokasi_Kerja lokja)
        {
            strSql = "UPDATE lokasi_kerja SET lokasi = @1 WHERE kode_lokasi = @2";
 
            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", lokja.Lokasi); 
                cmd.Parameters.AddWithValue("@2", lokja.Kode_Lokasi);
                  
                return cmd.ExecuteNonQuery();
            }
        }

        public int Save(Lokasi_Kerja lokja)
        {
            strSql = "INSERT INTO lokasi_kerja (kode_lokasi, lokasi) VALUES (@1, @2)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", lokja.Kode_Lokasi);
                cmd.Parameters.AddWithValue("@2", lokja.Lokasi);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string lokja)
        {
            strSql = "DELETE FROM lokasi_kerja WHERE kode_lokasi = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", lokja);

                return cmd.ExecuteNonQuery();
            }
        }

        public Lokasi_Kerja GetByKodeLokasi(string kodLok)
        {
            Lokasi_Kerja lokja = null;

            strSql = "SELECT * FROM lokasi_kerja WHERE kode_lokasi = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kodLok);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        lokja = MappingRowToObject(dtr);
                    }
                }
            }

            return lokja;            
        }

        public List<Lokasi_Kerja> GetAll()
        {
            List<Lokasi_Kerja> daftarLokJa = new List<Lokasi_Kerja>();

            strSql = "SELECT kode_lokasi, lokasi FROM lokasi_kerja ORDER BY lokasi";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarLokJa.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarLokJa;
        }

        public bool cekRecord(string kodLok)
        {
            Lokasi_Kerja lokJa = GetByKodeLokasi(kodLok);

            if (lokJa != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Lokasi_Kerja MappingRowToObject(NpgsqlDataReader dtr)
        {
            Lokasi_Kerja lokja = new Lokasi_Kerja();

            lokja.Kode_Lokasi = dtr["kode_lokasi"] is DBNull ? string.Empty : dtr["kode_lokasi"].ToString();
            lokja.Lokasi = dtr["lokasi"] is DBNull ? string.Empty : dtr["lokasi"].ToString();

            return lokja;
        }
    }
}
