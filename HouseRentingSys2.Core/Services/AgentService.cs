using HouseRentingSys2.Core.Contracts;
using HouseRentingSys2.Infrastructure.Common;
using HouseRentingSys2.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSys2.Core.Services
{

    public class AgentService : IAgentService
    {
        private readonly IRepository repository;
        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });
            await repository.SaveChangesAsync();    
        }

        public async Task<bool> ExistsByIdAsync(string userId) 
            => await repository.AllReadOnly<Agent>().AnyAsync(a=> a.UserId == userId);

        public async Task<bool> UserHasRentAsync(string userId)
        {
            return await repository.AllReadOnly<House>()
                .AnyAsync(h => h.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<Agent>()
                .AnyAsync (a => a.PhoneNumber == phoneNumber);
        }
    }
}
