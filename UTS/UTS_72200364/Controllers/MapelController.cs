using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UTS_72200364.Models;

namespace UTS_72200364.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapelController : ControllerBase
    {
        private MapelContext _context;

        public MapelController(MapelContext context)
        {
            this._context = context;
        }

        // GET: api/mapel
        [HttpGet]
        public ActionResult<IEnumerable<ItemMapel>> GetMapelItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetAllMapel();
        }

        //Get : api/mapel/{id}
        [HttpGet("{id}", Name = "GetMapel")]
        public ActionResult<IEnumerable<ItemMapel>> GetItemMapel(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetMapel(id);
        }

        // Post: api/mapel
        [HttpPost]
        public ActionResult<ItemMapel> AddMapel([FromForm] String nama_mapel, [FromForm] String deskripsi)
        {
            ItemMapel mp = new ItemMapel();
            mp.nama_mapel = nama_mapel;
            mp.deskripsi = deskripsi;

            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.AddMapel(mp);
        }
    }
}
