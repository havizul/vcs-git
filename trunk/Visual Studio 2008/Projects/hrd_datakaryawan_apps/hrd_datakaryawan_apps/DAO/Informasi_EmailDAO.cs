using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class Informasi_EmailDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public Informasi_EmailDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Informasi_Email MappingRowToObject(NpgsqlDataReader dtr)
        {
            Informasi_Email iem = new Informasi_Email();

            iem.Id = dtr["id_inform_email"] is DBNull ? 0 : (int)dtr["id_inform_email"];
            iem.Alamat_Email = dtr["alamat_email"] is DBNull ? string.Empty : dtr["alamat_email"].ToString();
            iem.Kepemilikan_Email = dtr["kepemilikan_email"] is DBNull ? string.Empty : dtr["kepemilikan_email"].ToString();
            iem.NIK = dtr["nik"] is DBNull ? string.Empty : dtr["nik"].ToString();

            return iem;
        }     
        
        public bool cekRecord(string emailAddr, string nik)
        {
            Informasi_Email iem = GetByAlamatEmailAndNik(emailAddr, nik);

            if (iem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Informasi_Email cekRecordIEM(string emailAddr, string nik)
        {
            Informasi_Email iem = GetByAlamatEmailAndNik(emailAddr, nik);

            return iem;
        }

        public Informasi_Email GetByAlamatEmail(string emailAddr)
        {
            Informasi_Email iem = null;

            strSql = "SELECT * FROM informasi_email WHERE alamat_email = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", emailAddr);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        iem = MappingRowToObject(dtr);
                    }
                }
            }

            return iem;
        }

        public Informasi_Email GetByAlamatEmailAndNik(string emailAddr, string nik)
        {
            Informasi_Email iem = null;

            strSql = "SELECT * FROM informasi_email WHERE alamat_email = @1 AND nik = @2";
            //strSql = "SELECT * FROM informasi_email WHERE alamat_email = 'havizul@wanasl.com' AND nik = '1.1.12.0153'";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", emailAddr);
                cmd.Parameters.AddWithValue("@2", nik);
                //cmd.Parameters.AddWithValue("@1", "havizul@wanasl.com");
                //cmd.Parameters.AddWithValue("@2", "1.1.12.0153");

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    //iem = MappingRowToObject(dtr);
                    if (dtr.Read())
                    {
                        iem = MappingRowToObject(dtr);
                    }
                }
            }

            return iem;
        }



        public List<Informasi_Email> GetByNIK(string nik)
        {
            List<Informasi_Email> dftEmailByNik = new List<Informasi_Email>();
            //List<Informasi_Email> dftEmailByNik = null;

            strSql = "SELECT * FROM informasi_email WHERE nik = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        dftEmailByNik.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return dftEmailByNik;
        }
        

        public List<Informasi_Email> GetAll()
        {
            List<Informasi_Email> daftarIem = new List<Informasi_Email>();

            strSql = "SELECT id_inform_email, alamat_email, kepemilikan_email, nik FROM informasi_email ORDER BY id_inform_email";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarIem.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarIem;
        }

        //Method CRUD. Insert, Update, Delete, Select
        public int Save(Informasi_Email iem)
        {
            //strSql = "INSERT INTO informasi_email (id_inform_email, alamat_email, kepemilikan_email, nik) VALUES (@1, @2, @3, @4)";
            strSql = "INSERT INTO informasi_email (id_inform_email, alamat_email, kepemilikan_email, nik) VALUES (DEFAULT, @2, @3, @4)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                //cmd.Parameters.AddWithValue("@1", iem.Id);
                cmd.Parameters.AddWithValue("@2", iem.Alamat_Email);
                cmd.Parameters.AddWithValue("@3", iem.Kepemilikan_Email);
                cmd.Parameters.AddWithValue("@4", iem.NIK);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Informasi_Email iem, string emailAddrLama)
        {
            //strSql = "UPDATE informasi_email SET alamat_email = @1, kepemilikan_email = @2, WHERE nik = @3 AND alamat_email = @4";
            strSql = "UPDATE informasi_email SET alamat_email = @1, kepemilikan_email = @2 WHERE nik = @3 AND alamat_email = @4";
            
            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", iem.Alamat_Email);
                cmd.Parameters.AddWithValue("@2", iem.Kepemilikan_Email);
                cmd.Parameters.AddWithValue("@3", iem.NIK);
                cmd.Parameters.AddWithValue("@4", emailAddrLama);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int id)
        {
            strSql = "DELETE FROM informasi_email WHERE id_inform_email = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", id);

                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteByNikNEmailAddr(string nik, string emailAddr)
        {
            strSql = "DELETE FROM informasi_email WHERE nik = @1 AND alamat_email = @2";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);
                cmd.Parameters.AddWithValue("@2", emailAddr);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
