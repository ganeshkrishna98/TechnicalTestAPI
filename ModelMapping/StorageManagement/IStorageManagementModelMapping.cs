using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.ModelMapping.StorageManagement
{
    public interface IStorageManagementModelMapping
    {
        public Task<List<Storages>> StorageManagementMapping(List<object[]> array);
    }
}
