using HouseBuying.Data.Base;
using HouseBuying.Models;

namespace HouseBuying.Data.Services
{
    public class HouseService : IHousesService
    {
        private readonly IHouseRepository _houseRepository;

        public HouseService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public IEnumerable<House> GetHousesByName(string name)
        {
            return _houseRepository.GetHousesByName(name);
        }
    }
}
