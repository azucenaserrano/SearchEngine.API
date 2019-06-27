using Microsoft.AspNetCore.Mvc;
using SearchEngine.API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SearchEngine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly DataContext _context;
        public LocationsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _context.Location.ToListAsync();
            return Ok(locations);
        }
    }
}