namespace HouseRentingSys2.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistsByIdAsync(string userId);

        Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber);

        Task<bool> UserHasRentAsync(string userId);
        Task CreateAsync(string userId, string phoneNumber);
    }
}
