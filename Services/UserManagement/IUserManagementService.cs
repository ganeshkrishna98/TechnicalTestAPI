using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.Services.UserManagement
{
    public interface IUserManagementService
    {
        public Task<dynamic> ReadUsers();
        public Task<dynamic> CreateUsers(UserManagementInput userManagementInput);
        public Task<dynamic> UpdateUsers(UserManagementInput userManagementInput);
        public Task<dynamic> DeleteUsers(UserManagementInput userManagementInput);
    }
}
