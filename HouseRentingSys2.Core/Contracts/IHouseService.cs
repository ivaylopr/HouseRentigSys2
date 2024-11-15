using HouseRentingSys2.Core.Enumerations;
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

        Task<HouseQueryServiceModel> AllAsync(
            string? category = null,
            string? searchedTerm =null,
            HouseSorting sorting = HouseSorting.Newest,
            int currentPage=1,
            int housesPerPage=1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();
    }
}
