using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class AgamaDAO
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;
    
        //Constructor
        public AgamaDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        private Agama MappingRowToObject(NpgsqlDataReader dtr)
        {
            Agama ag = new Agama();
            
            ag.Id_Agama = dtr["id_agama"] is DBNull ? 0 : (int)dtr["id_agama"];
            //ag.Id_Agama = dtr["id_agama"] is DBNull ? string.Empty : dtr["id_agama"].ToString();
            ag.Nama_Agama = dtr["nama_agama"] is DBNull ? string.Empty : dtr["nama_agama"].ToString();

            return ag;
        }

        public bool cekRecordNmAg(string nmAg)
        {
            Agama ag = GetByNamaAgama(nmAg);

            if (ag != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool cekRecordIdAg(int idAg)
        {
            Agama ag = GetByIdAgama(idAg);

            if (ag != null) //Jika record sudah ada, maka kembalikan nilai true
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public Agama GetByNamaAgama(string nmAg)
        {
            Agama ag = null;

            strSql = "SELECT * FROM agama WHERE nama_agama = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nmAg);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        ag = MappingRowToObject(dtr);
                    }
                }
            }

            return ag;
        }

        public Agama GetByIdAgama(int idAg)
        {
            Agama ag = null;

            strSql = "SELECT * FROM agama WHERE id_agama = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", idAg);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        ag = MappingRowToObject(dtr);
                    }
                }
            }

            return ag;
        }


        public List<Agama> GetAll()
        {
            List<Agama> daftarAg = new List<Agama>();

            strSql = "SELECT id_agama, nama_agama FROM agama ORDER BY id_agama";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        daftarAg.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return daftarAg;
        }

        //Method CRUD. Insert, Update, Delete, Select
        public int Save(Agama Ag)
        {
            strSql = "INSERT INTO agama (id_agama, nama_agama) VALUES (DEFAULT, @2)";
            //strSql = "INSERT INTO agama (nama_agama) VALUES (@2)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                //cmd.Parameters.AddWithValue("@1", Ag.Id_Agama);
                //cmd.Parameters.AddWithValue("@1", DEFAULT);
                cmd.Parameters.AddWithValue("@2", Ag.Nama_Agama);

                return cmd.ExecuteNonQuery();
            }
        }

        public int SaveAutoID(Agama ag)
        {
            strSql = "INSERT INTO agama (id_agama, nama_agama) VALUES (DEFAULT, @2)";
            //strSql = "INSERT INTO agama (nama_agama) VALUES (@2)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                //cmd.Parameters.AddWithValue("@1", Ag.Id_Agama);
                //cmd.Parameters.AddWithValue("@1", DEFAULT);
                cmd.Parameters.AddWithValue("@2", ag.Nama_Agama);

                return cmd.ExecuteNonQuery();
            }
        }
        
        public int Update(Agama ag)
        {            
            strSql = "UPDATE agama SET nama_agama = @1 WHERE id_agama = @2";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", ag.Nama_Agama);
                cmd.Parameters.AddWithValue("@2", ag.Id_Agama);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int idAg)
        {
            strSql = "DELETE FROM agama WHERE id_agama = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", idAg);

                return cmd.ExecuteNonQuery();
            }
        }

        public int ResetCount()
        {
            strSql = "ALTER SEQUENCE agama_id_agama_seq RESTART WITH 1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                //cmd.Parameters.AddWithValue("@1", 1);

                return cmd.ExecuteNonQuery();
            }
        }

    }
}
