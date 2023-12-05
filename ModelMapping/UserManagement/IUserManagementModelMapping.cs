using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.ModelMapping.UserManagement
{
    public interface IUserManagementModelMapping
    {
        public Task<List<UserAccounts>> UserManagementMapping(List<object[]> array);
    }
}
