using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace UTS_72200364.Models
{
    public class GuruContext : DbContext
    {
        public GuruContext(DbContextOptions<GuruContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }

        //public KelasContext(string connectionString)
        //{
        //    this.ConnectionString = connectionString;
        //}

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = kelas; Uid = root; Pwd =");
        }

        public List<ItemGuru> GetAllGuru()
        {
            List<ItemGuru> list = new List<ItemGuru>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM guru", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ItemGuru()
                        {
                            id_guru = reader.GetInt32("id_guru"),
                            rfid = reader.GetString("rfid"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            alamat = reader.GetString("alamat"),
                            status_guru = reader.GetInt32("status_guru")

                        });
                    }
                }
            }
            return list;
        }

        public List<ItemGuru> GetGuru(string id)
        {
            List<ItemGuru> list = new List<ItemGuru>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM guru WHERE id_guru = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ItemGuru()
                        {
                            id_guru = reader.GetInt32("id_guru"),
                            rfid = reader.GetString("rfid"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            alamat = reader.GetString("alamat"),
                            status_guru = reader.GetInt32("status_guru")
                        });
                    }
                }
            }
            return list;
        }
        public ItemGuru AddGuru(ItemGuru gr)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO guru(rfid, nip, nama_guru, alamat, status_guru) values (@rfid, @nip, @nama_guru,@alamat,@status_guru)", conn);
                cmd.Parameters.AddWithValue("@rfid", gr.rfid);
                cmd.Parameters.AddWithValue("@nip", gr.nip);
                cmd.Parameters.AddWithValue("@nama_guru", gr.nama_guru);
                cmd.Parameters.AddWithValue("@alamat", gr.alamat);
                cmd.Parameters.AddWithValue("@status_guru", gr.status_guru);
                cmd.ExecuteReader();
            }
            return gr;
        }
 }
}