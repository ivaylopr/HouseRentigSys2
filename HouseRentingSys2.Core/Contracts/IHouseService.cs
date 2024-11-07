using HouseRentingSys2.Core.Models.Home;
using HouseRentingSys2.Core.Models.House;

namespace HouseRentingSys2.Core.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();

        Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(HouseFormModel model, int agentId);
    }
}
