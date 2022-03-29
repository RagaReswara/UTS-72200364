namespace UTS_72200364.Models
{
    public class ItemGuru
    {
        private GuruContext context;
        public int id_guru { get; set; }
        public string rfid { get; set; }
        public string nip { get; set; }
        public string nama_guru { get; set; }
        public string alamat { get; set; }
        public int status_guru { get; set; }
    }
}
