using HouseRentingSys2.Core.Models.Home;

namespace HouseRentingSys2.Core.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();
    }
}
