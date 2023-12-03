using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping.StorageManagement
{
    public interface IStorageManagementModelMapping
    {
        public Task<List<Storages>> StorageManagementMapping(List<object[]> array);
    }
}
