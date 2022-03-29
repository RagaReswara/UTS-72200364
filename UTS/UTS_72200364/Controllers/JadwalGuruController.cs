using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UTS_72200364.Models;

namespace UTS_72200364.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JadwalGuruController : ControllerBase
    {
            private JadwalGuruContext _context;

            public JadwalGuruController(JadwalGuruContext context)
            {
                this._context = context;
            }

            // GET: api/jadwal
            [HttpGet]
            public ActionResult<IEnumerable<ItemJadwalGuru>> GetJadwalGuruItems()
            {
                _context = HttpContext.RequestServices.GetService(typeof(JadwalGuruContext)) as JadwalGuruContext;
                return _context.GetAllJadwal();
            }

            //Get : api/jadwal/{id}
            [HttpGet("{id}", Name = "GetJadwal")]
            public ActionResult<IEnumerable<ItemJadwalGuru>> GetItemJadwal(String id)
            {
                _context = HttpContext.RequestServices.GetService(typeof(JadwalGuruContext)) as JadwalGuruContext;
                return _context.GetJadwal(id);
            }

            // Post: api/jadwal
            [HttpPost]
            public ActionResult<ItemJadwalGuru> AddJadwalGuru([FromForm] String tahun_akademik, [FromForm] String semester, [FromForm] int id_guru, [FromForm] String hari, [FromForm] int id_kelas, [FromForm] int id_mapel, [FromForm] String jam_mulai, [FromForm] String jam_selesai)
            {
                ItemJadwalGuru jwl = new ItemJadwalGuru();
                jwl.tahun_akademik = tahun_akademik;
                jwl.smst = semester;
                jwl.id_guru = id_guru;
                jwl.hari = hari;
                jwl.id_kelas = id_kelas;
                jwl.id_mapel = id_mapel;
                jwl.jam_mulai = jam_mulai;
                jwl.jam_selesai = jam_selesai;

                _context = HttpContext.RequestServices.GetService(typeof(JadwalGuruContext)) as JadwalGuruContext;
                return _context.AddJadwalGuru(jwl);
            }
        }
    }

