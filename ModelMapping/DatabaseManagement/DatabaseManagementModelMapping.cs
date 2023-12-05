using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping.DatabaseManagement
{
    public class DatabaseManagementModelMapping : IDatabaseManagementModelMapping
    {
        public async Task<List<Databases>> DatabaseManagementMapping(List<object[]> array)
        {
            var outputList = new List<Databases>();
            foreach (var item in array)
            {
                var output = new Databases
                {
                    databaseId = item[0].ToString(),
                    databaseName = item[1].ToString(),
                    //fileName = item[2].ToString(),
                    //approvalStatus = item[3].ToString(),
                    //authorUserId = item[4].ToString(),
                    //authorName = item[5].ToString(),
                    //lastModifiedUserId = item[6].ToString(),
                    //lastModifiedUserName = item[7].ToString(),
                    //lastAccessedUserName = item[8].ToString(),
                    //lastAccessedUserId = item[9].ToString()
                };
                outputList.Add(output);
            }
            return outputList;
        }
    }
}
