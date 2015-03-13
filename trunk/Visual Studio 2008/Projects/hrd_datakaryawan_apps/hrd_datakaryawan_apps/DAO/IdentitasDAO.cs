using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.DAO
{
    public class IdentitasDAO
    {
        //Global Variable
        private NpgsqlConnection conn = null;
        private string strSql = string.Empty;

        //Constructor
        public IdentitasDAO(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        //CRUD Operation
        public int Save(Identitas idt)
        {
            strSql = "INSERT INTO identitas (nomor_identitas, jenis_identitas, masa_berlaku, nik) VALUES (@1, @2, @3, @4)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", idt.Nomor_Identitas);
                cmd.Parameters.AddWithValue("@2", idt.Jenis_Identitas);
                cmd.Parameters.AddWithValue("@3", idt.Masa_Berlaku);
                cmd.Parameters.AddWithValue("@4", idt.Nik);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Identitas idt)
        {
            strSql = "UPDATE identitas SET jenis_identitas = @1, masa_berlaku = @2 WHERE nomor_identitas = @3";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", idt.Jenis_Identitas);
                cmd.Parameters.AddWithValue("@2", idt.Masa_Berlaku);
                cmd.Parameters.AddWithValue("@3", idt.Nomor_Identitas);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string nomor_identitas)
        {
            strSql = "DELETE FROM identitas WHERE nomor_identitas = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nomor_identitas);

                return cmd.ExecuteNonQuery();
            }
        }

        public List<Identitas> getInfoIdentitasByNik(string nik)
        {
            List<Identitas> dftIdentitas = new List<Identitas>();

            strSql = "SELECT * FROM identitas WHERE nik = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nik);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        dftIdentitas.Add(MappingRowTOObject(dtr));
                    }
                }

                return dftIdentitas;
            }
        }

        public Identitas getInfoIdentitasByNoIdentitas(string nomor_identitas)
        {
            Identitas idt = null;

            strSql = "SELECT * FROM identitas WHERE nomor_identitas = @1";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nomor_identitas);

                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        idt = MappingRowTOObject(dtr);
                    }
                }

                return idt;
            }
        }

        /*
        public List<Identitas> getInfoIdentitas()
        {
            List<Identitas> dftIdentitas = new List<Identitas>();

            strSql = "SELECT * FROM identitas";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                using (NpgsqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        dftIdentitas.Add(MappingRowTOObject(dtr));
                    }
                }

                return dftIdentitas;
            }
        }
        */

        //Extra Method
        private Identitas MappingRowTOObject(NpgsqlDataReader dtr)
        {
            Identitas idt = new Identitas();

            idt.Nomor_Identitas = dtr["nomor_identitas"] is DBNull ? string.Empty : dtr["nomor_identitas"].ToString();
            idt.Nik = dtr["nik"] is DBNull ? string.Empty : dtr["nik"].ToString();
            idt.Jenis_Identitas = dtr["jenis_identitas"] is DBNull ? string.Empty : dtr["jenis_identitas"].ToString();
            idt.Masa_Berlaku = dtr["masa_berlaku"] is DBNull ? DateTime.MinValue : DateTime.Parse(dtr["masa_berlaku"].ToString());

            return idt;
        }

        /*
        public bool cekRecordByNoID(string nomor_identitas)
        {
            Identitas idt = getInfoIdentitasByNoIdentitas(nomor_identitas);

            if (idt != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
    }
}
