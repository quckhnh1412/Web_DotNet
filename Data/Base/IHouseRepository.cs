using HouseBuying.Models;

namespace HouseBuying.Data.Base
{
    public interface IHouseRepository
    {
        IEnumerable<House> GetHousesByName(string name);
    }
}
