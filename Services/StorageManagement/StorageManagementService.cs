using Microsoft.AspNetCore.Mvc;
using TechnicalTestAPI.Constants;
using TechnicalTestAPI.ModelMapping.StorageManagement;
using TechnicalTestAPI.Models.ServiceModels;
using TechnicalTestAPI.Services.Common;

namespace TechnicalTestAPI.Services.StorageManagement
{
    public class StorageManagementService : IStorageManagementService
    {
        private readonly ICommonService _commonService;
        private readonly IStorageManagementModelMapping _storageManagementModelMapping;

        public StorageManagementService(ICommonService commonService, IStorageManagementModelMapping storageManagementModelMapping)
        {
            _commonService = commonService;
            _storageManagementModelMapping = storageManagementModelMapping;
        }

        public async Task<dynamic> ReadStorages()
        {
            var result = await _commonService.ExecuteRequest(typeof(StorageManagementService).Name.ToString(), Constant.Read, string.Empty);
            if (result.GetType() == typeof(ErrorModel))
            {
                return result;
            }
            else
                return await _storageManagementModelMapping.StorageManagementMapping(result);
        }

        public async Task<dynamic> CreateStorages(Storages storageManagementInput)
        {
            storageManagementInput.storageId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(StorageManagementService).Name.ToString(), Constant.Create, storageManagementInput);
        }

        public async Task<dynamic> UpdateStorages(Storages storageManagementInput)
        {
            return await _commonService.ExecuteRequest(typeof(StorageManagementService).Name.ToString(), Constant.Update, storageManagementInput);
        }

        public async Task<dynamic> DeleteStorages(Storages storageManagementInput)
        {
            var result = await _commonService.ExecuteRequest(typeof(StorageManagementService).Name.ToString(), Constant.Delete, storageManagementInput);
            if (result is ErrorModel)
            {
                return result;
            }

            var jsonResult = result as string;
            return new JsonResult(jsonResult)
            {
                StatusCode = 200,
            };
        }
    }
}