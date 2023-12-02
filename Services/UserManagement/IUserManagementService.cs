using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.Services.UserManagement
{
    public interface IUserManagementService
    {
        public Task<dynamic> ReadUser();
        public Task<dynamic> CreateUser(UserManagementInput userManagementInput);
        public Task<dynamic> UpdateUser(UserManagementInput userManagementInput);
        public Task<dynamic> DeleteUser(UserManagementInput userManagementInput);
    }
}
