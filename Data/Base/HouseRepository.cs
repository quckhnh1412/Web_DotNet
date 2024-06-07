using HouseBuying.Models;
using System;

namespace HouseBuying.Data.Base
{
    public class HouseRepository : IHouseRepository
    {
        private readonly AppDBContext _context;
        public HouseRepository(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<House> GetHousesByName(string name)
        {
            var query = _context.Houses.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(h => h.Title.Contains(name));
            }
            return query.ToList();
        }
    }
}
