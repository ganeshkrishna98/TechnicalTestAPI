using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.Services.UserManagement
{
    public interface IUserManagementService
    {
        public Task<dynamic> CreateUser(UserManagementInput userManagementInput);
    }
}
