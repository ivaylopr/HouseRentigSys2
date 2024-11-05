using HouseRentingSys2.Core.Models.Home;

namespace HouseRentingSys2.Core.Contracts.House
{
	public interface IHouseService
	{
		Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();
	}
}
