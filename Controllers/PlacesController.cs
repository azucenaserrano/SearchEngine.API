using Microsoft.AspNetCore.Mvc;
using SearchEngine.API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SearchEngine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly DataContext _context;
        public PlacesController(DataContext context)
        {
            _context = context;
        }

        /* GET
        *  Fileter places by specified parameters
        *  Get category and location from a list separeted by ,
        */
        [HttpGet]
        public async Task<IActionResult> GetPlace([FromQuery(Name = "search")] string search, [FromQuery(Name = "category")] string category, [FromQuery(Name = "location")] string location)
        {
            var places = await _context.Place.ToListAsync();

            if (search != null && search != "")
            {
                search = search.ToLower();
                places = (from s in places
                          where s.Name.ToLower().Contains(search) ||
                                     s.Description.ToLower().Contains(search)
                          select s).ToList();
            }
            if (category != null)
            {
                var ids = category.Split(',');
                places = (from p in places
                          where ids.Contains(System.Convert.ToString(p.CategoryId))
                          select p).ToList();
            }
            if (location != null)
            {
                var ids = location.Split(',');
                places = (from p in places
                          where ids.Contains(System.Convert.ToString(p.LocationId))
                          select p).ToList();
            }

            return Ok(places);
        }
    }
}