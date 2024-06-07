using HouseBuying.Data;
using HouseBuying.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace HouseBuying.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _context;
        public HomeController(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allHouses = await _context.Houses.Include(n => n.Address).ToListAsync();
     
            return View(allHouses);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var query = _context.Houses.Include(n => n.Address).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(h => h.Title.Contains(searchString) || h.Address.Street.Contains(searchString) || h.Address.Ward.Contains(searchString) || h.Address.District.Contains(searchString) || h.Address.Province.Contains(searchString));
            }

            var filteredHouses = await query.ToListAsync();

            ViewBag.CurrentFilterString = searchString; // Store the current filter value for redisplaying in the form

            return View("Index",filteredHouses);


        }


        // GET: House/Details/5
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || _context.Houses == null)
            {
                return NotFound();
            }

            var house = await _context.Houses
                .Include(h => h.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            return View("Detail", house);
        }


    }
}
