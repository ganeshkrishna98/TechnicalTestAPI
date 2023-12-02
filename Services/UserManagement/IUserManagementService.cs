namespace UniversityOfNottinghamAPI.Services.UserManagement
{
    public interface IUserManagementService
    {
        public Task<dynamic> ReadUsers();
        public Task<dynamic> CreateUsers(Models.ServiceModels.UserAccounts userManagementInput);
        public Task<dynamic> UpdateUsers(Models.ServiceModels.UserAccounts userManagementInput);
        public Task<dynamic> DeleteUsers(Models.ServiceModels.UserAccounts userManagementInput);
    }
}
