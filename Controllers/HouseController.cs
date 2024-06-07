using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseBuying.Data;
using HouseBuying.Models;
using Microsoft.AspNetCore.Authorization;

namespace HouseBuying.Controllers
{
    [Authorize(Roles="Admin")]
    public class HouseController : Controller
    {
        private readonly AppDBContext _context;

        public HouseController(AppDBContext context)
        {
            _context = context;
        }

        // GET: House
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Houses.Include(h => h.Address);
            return View(await appDBContext.ToListAsync());
        }

        // GET: House/Details/5
        public async Task<IActionResult> Details(int? id)
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

            return View(house);
        }


        public IActionResult GetDistricts(string province)
        {
            var districts = _context.Addresses
                .Where(a => a.Province == province)
                .Select(a => a.District)
                .Distinct()
                .ToList();

            return Json(districts);
        }

        public IActionResult GetWards(string province, string district)
        {
            var wards = _context.Addresses
                .Where(a => a.Province == province && a.District == district)
                .Select(a => a.Ward)
                .Distinct()
                .ToList();

            return Json(wards);
        }

        public IActionResult GetStreets(string province, string district, string ward)
        {
            var streets = _context.Addresses
                .Where(a => a.Province == province && a.District == district && a.Ward == ward)
                .Select(a => a.Street)
                .Distinct()
                .ToList();

            return Json(streets);
        }
        public IActionResult GetAddressId(string province, string district, string ward, string street)
        {
            var addressId = _context.Addresses
                .Where(a => a.Province == province && a.District == district && a.Ward == ward && a.Street == street)
                .Select(a => a.Id)
                .FirstOrDefault();

            return Json(addressId);
        }

        // GET: House/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");

            // Lấy danh sách tỉnh
            ViewBag.Provinces = _context.Addresses.Select(a => a.Province).Distinct().ToList();


            return View();
        }

        // POST: House/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Bedrooms,Bathrooms,Price,ImageURL,Status,AddressId")] House house)
        {
           
            if (house!=null)
            {
                _context.Add(house);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", house.AddressId);


            return View(house);
        }

        // GET: House/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Houses == null)
            {
                return NotFound();
            }

            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", house.AddressId);
            return View(house);
        }

        // POST: House/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Bedrooms,Bathrooms,Price,ImageURL,Status,AddressId")] House house)
        {
            try
            {
                if (id != house.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _context.Update(house);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", house.AddressId);
                return View(house);
            }
            catch (Exception ex)
            {
                // Log or display the exception
                Console.WriteLine(ex.Message);
                throw; // Rethrow the exception to see details in the browser
            }
            // Repopulate the ViewBag.Provinces in case of an error

            
        }

        // GET: House/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            return View(house);
        }

        // POST: House/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Houses == null)
            {
                return Problem("Entity set 'AppDBContext.Houses'  is null.");
            }
            var house = await _context.Houses.FindAsync(id);
            if (house != null)
            {
                _context.Houses.Remove(house);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseExists(int id)
        {
          return (_context.Houses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
