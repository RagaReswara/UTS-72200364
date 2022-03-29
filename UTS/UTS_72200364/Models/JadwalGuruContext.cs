using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace UTS_72200364.Models
{
    public class JadwalGuruContext : DbContext
    {
        public JadwalGuruContext(DbContextOptions<JadwalGuruContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = kelas; Uid = root; Pwd =");
        }

        public List<ItemJadwalGuru> GetAllJadwal()
        {
            List<ItemJadwalGuru> list = new List<ItemJadwalGuru>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM jadwal_guru", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ItemJadwalGuru()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            smst = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")
                        });
                    }
                }
            }
            return list;
        }

        public List<ItemJadwalGuru> GetJadwal(string id_mapel)
        {
            List<ItemJadwalGuru> list = new List<ItemJadwalGuru>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM jadwal_guru WHERE id_mapel = @id_mapel", conn);
                cmd.Parameters.AddWithValue("@id_mapel", id_mapel);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ItemJadwalGuru()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            smst = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")
                        });
                    }
                }
            }
            return list;
        }

        public List<ItemJadwalGuru> GetViewJadwal(string nip)
        {
            List<ItemJadwalGuru> list = new List<ItemJadwalGuru>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT jadwal_guru.id_jadwal_guru, jadwal_guru.tahun_akademik, " +
                    "jadwal_guru.semester, jadwal_guru.id_guru, jadwal_guru.hari, jadwal_guru.id_kelas, jadwal_guru.id_mapel," +
                    " jadwal_guru.jam_mulai, jadwal_guru.jam_selesai, guru.nip FROM jadwal_guru INNER JOIN guru ON guru.id_guru = jadwal_guru.id_guru WHERE guru.nip = @nip", conn);
                cmd.Parameters.AddWithValue("@nip", nip);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ItemJadwalGuru()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            smst = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai"),
                            nip = reader.GetString("nip")
                        });
                    }
                }
            }
            return list;
        }

        public ItemJadwalGuru AddJadwalGuru(ItemJadwalGuru jwl)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO jadwal_guru(tahun_akademik, semester, id_guru, hari, id_kelas, id_mapel, jam_mulai, jam_selesai) values (@tahun_akademik, @semester, @id_guru, @hari, @id_kelas, @id_mapel, @jam_mulai, @jam_selesai)", conn);
                cmd.Parameters.AddWithValue("@tahun_akademik", jwl.tahun_akademik);
                cmd.Parameters.AddWithValue("@semester", jwl.smst);
                cmd.Parameters.AddWithValue("@id_guru", jwl.id_guru);
                cmd.Parameters.AddWithValue("@hari", jwl.hari);
                cmd.Parameters.AddWithValue("@id_kelas", jwl.id_kelas);
                cmd.Parameters.AddWithValue("@id_mapel", jwl.id_mapel);
                cmd.Parameters.AddWithValue("@jam_mulai", jwl.jam_mulai);
                cmd.Parameters.AddWithValue("@jam_selesai", jwl.jam_selesai);
                cmd.ExecuteReader();
            }
            return jwl;
        }
    }
}

