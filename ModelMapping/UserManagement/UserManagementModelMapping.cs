using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.ModelMapping.UserManagement
{
    public class UserManagementModelMapping : IUserManagementModelMapping
    {
        public async Task<List<UserAccounts>> UserManagementMapping(List<object[]> array)
        {
            var outputList = new List<UserAccounts>();
            foreach (var item in array)
            {
                var output = new UserAccounts
                {
                    userId = item[0].ToString(),
                    userEmail = item[1].ToString(),
                    userName = item[2].ToString(),
                    lastAccessTime = item[3].ToString(),
                    lastAccessDevice = item[4].ToString(),
                    lastAccessIp = item[5].ToString(),
                    accountType = item[6].ToString()
                };
                outputList.Add(output);
            }
            return outputList;
        }
    }
}
