using HouseRentingSys2.Core.Contracts;
using HouseRentingSys2.Infrastructure.Common;
using HouseRentingSys2.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSys2.Core.Services
{

    public class AgentService : IAgentService
    {
        private readonly IRepository repository;
        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task CreateAsync(string userId, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByIdAsync(string userId) 
            => await repository.AllReadOnly<Agent>().AnyAsync(a=> a.UserId == userId);

        public Task<bool> UserHasRentAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
