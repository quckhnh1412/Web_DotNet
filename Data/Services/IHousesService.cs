using HouseBuying.Data.Base;
using HouseBuying.Models;

namespace HouseBuying.Data.Services
{
    public interface IHousesService 
    {
        IEnumerable<House> GetHousesByName(string name);


    }
}
