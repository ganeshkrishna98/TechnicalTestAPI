using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.Services.UserManagement
{
    public interface IUserManagementService
    {
        public Task<dynamic> ReadUsers();
        public Task<dynamic> CreateUsers(UserAccounts userManagementInput);
        public Task<dynamic> UpdateUsers(UserAccounts userManagementInput);
        public Task<dynamic> DeleteUsers(UserAccounts userManagementInput);
    }
}
