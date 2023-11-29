namespace UniversityOfNottinghamAPI.Services.UserManagement
{
    public interface IUserManagementService
    {
        public Task<dynamic> CreateUser(string username, string password);
    }
}
