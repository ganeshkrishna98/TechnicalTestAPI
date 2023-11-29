using UniversityOfNottinghamAPI.Database;

namespace UniversityOfNottinghamAPI.Services.UserManagement
{
    public class UserManagementService :IUserManagementService
    {
        private readonly DatabaseContext _databaseContext;

        public UserManagementService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<dynamic> CreateUser(string username, string password)
        {



            return null;
        }
    }
}
