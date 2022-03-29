using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UTS_72200364.Models;

namespace UTS_72200364.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuruController : ControllerBase
    {
        private GuruContext _context;

        public GuruController(GuruContext context)
        {
            this._context = context;
        }

        // GET: api/guru
        [HttpGet]
        public ActionResult<IEnumerable<ItemGuru>> GetGuruItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.GetAllGuru();
        }

        //Get : api/guru/{id}
        [HttpGet("{id}", Name = "GetGuru")]
        public ActionResult<IEnumerable<ItemGuru>> GetItemGuru(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.GetGuru(id);
        }

        // Post: api/guru
        [HttpPost]
        public ActionResult<ItemGuru> AddGuru([FromForm] String rfid, [FromForm] String nip, [FromForm] String nama_guru, [FromForm] String alamat, [FromForm] int status_guru)
        {
            ItemGuru gr = new ItemGuru();
            gr.rfid = rfid;
            gr.nip = nip;
            gr.nama_guru = nama_guru;
            gr.alamat = alamat;
            gr.status_guru = status_guru;

            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.AddGuru(gr);
        }
    }
}
