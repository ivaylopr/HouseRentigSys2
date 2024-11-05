using HouseRentingSys2.Core.Contracts.House;
using HouseRentingSys2.Core.Models.Home;
using HouseRentingSys2.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSys2.Core.Services.House
{
	public class HouseService : IHouseService
	{
		private readonly IRepository repository;
        public HouseService(IRepository _repository)
        {
            repository = _repository;	
        }
        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.House>()
				.OrderByDescending(x=>x.Id)
				.Take(3)
				.Select(h=> new HouseIndexServiceModel()
				{
					Id = h.Id,
					ImageUrl=h.ImageUrl,
					Title = h.Title
				})
				.ToListAsync();
		}
	}
}
