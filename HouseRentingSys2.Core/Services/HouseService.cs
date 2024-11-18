using HouseRentingSys2.Core.Contracts;
using HouseRentingSys2.Core.Enumerations;
using HouseRentingSys2.Core.Models.Home;
using HouseRentingSys2.Core.Models.House;
using HouseRentingSys2.Infrastructure.Common;
using HouseRentingSys2.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSys2.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;
        public HouseService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<HouseQueryServiceModel> AllAsync(
            string? category = null,
            string? searchedTerm = null,
            HouseSorting sorting = HouseSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1)
        {
            var housesToShow = repository.AllReadOnly<House>();

            if (category != null)
            {
                housesToShow = housesToShow.Where(h => h.Category.Name == category);
            }

            if (searchedTerm != null)
            {
                string normalizedSearchedTerm = searchedTerm.ToLower();
                housesToShow = housesToShow.Where(h => (h.Title.ToLower().Contains(normalizedSearchedTerm) ||
                                                        h.Address.ToLower().Contains(normalizedSearchedTerm) ||
                                                        h.Description.ToLower().Contains(normalizedSearchedTerm)));
            }

            housesToShow = sorting switch
            {
                HouseSorting.Price => housesToShow
                    .OrderBy(h => h.PricePerMonth),

                HouseSorting.NotRentedFirst => housesToShow
                    .OrderBy(h => h.RenterId != null)
                    .ThenByDescending(h => h.Id),

                _ => housesToShow
                  .OrderByDescending(h => h.Id)
            };


            var houses = await housesToShow
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ProjectToHouseServiceModel()
                .ToListAsync();

            int totalHouses = await housesToShow.CountAsync();

            return new HouseQueryServiceModel()
            {
                Houses = houses,
                TotalHousesCount = totalHouses
            };
        }

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new HouseCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId)
        {
            return await repository.AllReadOnly<House>()
                .Where(h => h.AgentId == agentId)
                .ProjectToHouseServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId)
        {
            return await repository.AllReadOnly<House>()
                .Where(h => h.RenterId == userId)
                .ProjectToHouseServiceModel()
                .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>().AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(HouseFormModel model, int agentId)
        {
            House house = new House()
            {
                Address = model.Address,
                AgentId = agentId,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                Title = model.Title
            };

            await repository.AddAsync(house);
            await repository.SaveChangesAsync();

            return house.Id;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<House>()
                .AnyAsync(h => h.Id == id);
        }

        public async Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsServiceModel()
                {
                    Id = h.Id,
                    Address = h.Address,
                    Agent = new Models.Agent.AgentServiceModel()
                    {
                        Email = h.Agent.User.Email,
                        PhoneNumber = h.Agent.PhoneNumber
                    },
                    Category = h.Category.Name,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth,
                    Title = h.Title
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.House>()
                .OrderByDescending(x => x.Id)
                .Take(3)
                .Select(h => new HouseIndexServiceModel()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title
                })
                .ToListAsync();
        }
    }
}
