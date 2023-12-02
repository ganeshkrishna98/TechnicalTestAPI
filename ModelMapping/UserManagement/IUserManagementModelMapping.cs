using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping.UserManagement
{
    public interface IUserManagementModelMapping
    {
        public Task<List<UserAccounts>> UserManagementMapping(List<object[]> array);
    }
}
