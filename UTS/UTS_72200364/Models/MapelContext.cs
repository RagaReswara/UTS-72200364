using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace UTS_72200364.Models
{
    public class MapelContext : DbContext
    {
        public MapelContext(DbContextOptions<MapelContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = kelas; Uid = root; Pwd =");
        }

        public List<ItemMapel> GetAllMapel()
        {
            List<ItemMapel> list = new List<ItemMapel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM mapel", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ItemMapel()
                        {
                            id_mapel = reader.GetInt32("id_mapel"),
                            nama_mapel = reader.GetString("nama_mapel"),
                            deskripsi = reader.GetString("deskripsi")
                        });
                    }
                }
            }
            return list;
        }

        public List<ItemMapel> GetMapel(string id)
        {
            List<ItemMapel> list = new List<ItemMapel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM mapel WHERE id_mapel = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ItemMapel()
                        {
                            id_mapel = reader.GetInt32("id_mapel"),
                            nama_mapel = reader.GetString("nama_mapel"),
                            deskripsi = reader.GetString("deskripsi")
                        });
                    }
                }
            }
            return list;
        }
        public ItemMapel AddMapel(ItemMapel mp)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO mapel(nama_mapel, deskripsi) values (@nama_mapel, @deskripsi)", conn);
                cmd.Parameters.AddWithValue("@nama_mapel", mp.nama_mapel);
                cmd.Parameters.AddWithValue("@deskripsi", mp.deskripsi);
                cmd.ExecuteReader();
            }
            return mp;
        }
    }
}
