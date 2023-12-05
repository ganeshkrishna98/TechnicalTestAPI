using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping.StorageManagement
{
    public class StorageManagementModelMapping : IStorageManagementModelMapping
    {
        public async Task<List<Storages>> StorageManagementMapping(List<object[]> array)
        {
            var outputList = new List<Storages>();
            foreach (var item in array)
            {
                var output = new Storages
                {
                    storageId = item[0].ToString(),
                    storageName = item[1].ToString(),
                    createdDate = item[2].ToString(),
                    createdTime = item[3].ToString(),
                    createdUserId = item[4].ToString(),
                    createdUserName = item[5].ToString()
                };
                outputList.Add(output);
            }
            return outputList;
        }
    }
}
