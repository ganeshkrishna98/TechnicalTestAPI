using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.Services.UserManagement
{
    public interface IUserManagementService
    {
        public Task<List<UserAccounts>> ReadUsers();
        public Task<dynamic> CreateUsers(Models.ServiceModels.UserAccounts userManagementInput);
        public Task<dynamic> UpdateUsers(Models.ServiceModels.UserAccounts userManagementInput);
        public Task<dynamic> DeleteUsers(Models.ServiceModels.UserAccounts userManagementInput);
    }
}
