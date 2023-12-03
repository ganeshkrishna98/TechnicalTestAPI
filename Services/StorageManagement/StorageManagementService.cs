﻿using UniversityOfNottinghamAPI.ModelMapping.StorageManagement;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.AccessLogs;
using UniversityOfNottinghamAPI.Services.Common;
using UniversityOfNottinghamAPI.Constants;

namespace UniversityOfNottinghamAPI.Services.StorageManagement
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
            return await _commonService.ExecuteRequest(typeof(StorageManagementService).Name.ToString(), Constant.Delete, storageManagementInput);
        }
    }
}