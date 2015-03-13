using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;  //Agar class DAO bisa mengakses class Model

namespace hrd_datakaryawan_apps.DAO
{
    public class Informasi_KontakDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public Informasi_KontakDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Informasi_Kontak MappingRowToObject(NpgsqlDataReader dtr)
        {
            Informasi_Kontak ikn = new Informasi_Kontak();

            ikn.Nomor_Kontak = dtr["nomor_kontak"] is DBNull ? string.Empty : dtr["nomor_kontak"].ToString();
            ikn.Jenis_Kontak = dtr["jenis_kontak"] is DBNull ? string.Empty : dtr["jenis_kontak"].ToString();
            ikn.NIK = dtr["nik"] is DBNull ? string.Empty : dtr["nik"].ToString();
            ikn.Id_Inform_Kontak = dtr["id_inform_kontak"] is DBNull ? 0 : (int)dtr["id_inform_kontak"];

            return ikn;
        }
     
        //CRUD Operation -> Insert - Read - Update - Delete
        public int Save(Informasi_Kontak ikn)
        {
            strSql = "INSERT INTO informasi_kontak (nomor_kontak, jenis_kontak, nik, id_inform_kontak) VALUES(@1, @2, @3, DEFAULT)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", ikn.Nomor_Kontak);
                cmd.Parameters.AddWithValue("@2", ikn.Jenis_Kontak);
                cmd.Parameters.AddWithValue("@3", ikn.NIK);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Informasi_Kontak ikn)
        {
            strSql = "UPDATE informasi_kontak SET nomor_kontak = @1, jenis_kontak = @2 WHERE id_inform_kontak = @3";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", ikn.Nomor_Kontak);
                cmd.Parameters.AddWithValue("@2", ikn.Jenis_Kontak);
                cmd.Parameters.AddWithValue("@3", ikn.Id_Inform_Kontak);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int id_inform_kontak)
        {
            strSql = "DELETE FROM informasi_kontak WHERE id_inform_kontak = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", id_inform_kontak);

                return cmd.ExecuteNonQuery();
            }
        }

        public List<Informasi_Kontak> getByNIK(string nik)
        {
            List<Informasi_Kontak> dftInfoKontak = new List<Informasi_Kontak>();

            strSql = "SELECT * FROM informasi_kontak WHERE nik = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        dftInfoKontak.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return dftInfoKontak;
        }

        public Informasi_Kontak getByNikNByNoKontak(string nik, string noKontak)
        {
            Informasi_Kontak ikn = null;

            strSql = "SELECT * FROM informasi_kontak WHERE nik = @1 AND nomor_kontak = @2";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);
                cmd.Parameters.AddWithValue("@2", noKontak);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        ikn = MappingRowToObject(dtr);
                    }
                }
            }

            return ikn;
        }


        //Extra method
        public bool cekRecord(string nik, string noKontak)
        {
            Informasi_Kontak ikn = getByNikNByNoKontak(nik, noKontak);

            if (ikn == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
