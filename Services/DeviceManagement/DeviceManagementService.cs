﻿using Microsoft.AspNetCore.Mvc;
using TechnicalTestAPI.Constants;
using TechnicalTestAPI.ModelMapping.DeviceManagement;
using TechnicalTestAPI.Models.ServiceModels;
using TechnicalTestAPI.Services.Common;

namespace TechnicalTestAPI.Services.DeviceManagement
{
    public class DeviceManagementService : IDeviceManagementService
    {
        private readonly ICommonService _commonService;
        private readonly IDeviceManagementModelMapping _deviceManagementModelMapping;

        public DeviceManagementService(ICommonService commonService, IDeviceManagementModelMapping deviceManagementModelMapping)
        {
            _commonService = commonService;
            _deviceManagementModelMapping = deviceManagementModelMapping;
        }

        public async Task<dynamic> ReadDevices()
        {
            var result = await _commonService.ExecuteRequest(typeof(DeviceManagementService).Name.ToString(), Constant.Read, string.Empty);
            if (result.GetType() == typeof(ErrorModel))
            {
                return result;
            }
            else
                return await _deviceManagementModelMapping.DeviceManagementMapping(result);
        }

        public async Task<dynamic> CreateDevices(Devices deviceManagementInput)
        {
            deviceManagementInput.deviceId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(DeviceManagementService).Name.ToString(), Constant.Create, deviceManagementInput);
        }

        public async Task<dynamic> UpdateDevices(Devices deviceManagementInput)
        {
            return await _commonService.ExecuteRequest(typeof(DeviceManagementService).Name.ToString(), Constant.Update, deviceManagementInput);
        }

        public async Task<dynamic> DeleteDevices(Devices deviceManagementInput)
        {
            var result = await _commonService.ExecuteRequest(typeof(DeviceManagementService).Name.ToString(), Constant.Delete, deviceManagementInput);
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