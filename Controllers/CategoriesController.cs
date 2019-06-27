using Microsoft.AspNetCore.Mvc;
using SearchEngine.API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SearchEngine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Category.ToListAsync();
            return Ok(categories);
        }
    }
}