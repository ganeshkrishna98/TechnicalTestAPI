using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.Services.StorageManagement
{
    public interface IStorageManagementService
    {
        public Task<dynamic> ReadStorages();

        public Task<dynamic> CreateStorages(Storages storageManagementInput);

        public Task<dynamic> UpdateStorages(Storages storageManagementInput);

        public Task<dynamic> DeleteStorages(Storages storageManagementInput);
    }
}