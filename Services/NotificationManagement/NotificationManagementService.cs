﻿using UniversityOfNottinghamAPI.ModelMapping.NotificationManagement;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.AccessLogs;
using UniversityOfNottinghamAPI.Services.Common;
using UniversityOfNottinghamAPI.Constants;

namespace UniversityOfNottinghamAPI.Services.NotificationManagement
{
    public class NotificationManagementService : INotificationManagementService
    {
        private readonly ICommonService _commonService;
        private readonly INotificationManagementModelMapping _notificationManagementModelMapping;

        public NotificationManagementService(ICommonService commonService, INotificationManagementModelMapping notificationManagementModelMapping)
        {
            _commonService = commonService;
            _notificationManagementModelMapping = notificationManagementModelMapping;
        }

        public async Task<dynamic> ReadNotifications()
        {
            var result = await _commonService.ExecuteRequest(typeof(AccessLogsService).Name.ToString(), Constant.Read, string.Empty);
            if (result.GetType() == typeof(ErrorModel))
            {
                return result;
            }
            else
                return await _notificationManagementModelMapping.NotificationManagementMapping(result);
        }

        public async Task<dynamic> CreateNotifications(Notifications notificationsInput)
        {
            return await _commonService.ExecuteRequest(typeof(AccessLogsService).Name.ToString(), Constant.Create, notificationsInput);
        }

        public async Task<dynamic> UpdateNotifications(Notifications notificationsInput)
        {
            return await _commonService.ExecuteRequest(typeof(AccessLogsService).Name.ToString(), Constant.Update, notificationsInput);
        }

        public async Task<dynamic> DeleteNotifications(Notifications notificationsInput)
        {
            return await _commonService.ExecuteRequest(typeof(AccessLogsService).Name.ToString(), Constant.Delete, notificationsInput);
        }
    }
}