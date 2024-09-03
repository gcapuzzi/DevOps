using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly WebAPIContext _context;
        public DocumentController(WebAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetAll()
        {
            return await _context.Document.ToListAsync();
        }

        [HttpGet("{id}/{include=0}")]
        public async Task<ActionResult<Product>> GetDocumentById(int id, int include)
        {
            Document document;
            if(include == 0)
            {
                document = await _context.Document.FindAsync(id);
            }
            else
            {
                document = await _context.Document.Include(p => p.products)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            
            if(document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }
    }
}
