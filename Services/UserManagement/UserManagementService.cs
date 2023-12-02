﻿using System.Reflection.Metadata;
using UniversityOfNottinghamAPI.Database;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.Common;
using UniversityOfNottinghamAPI.Services.Document;
using Constant = UniversityOfNottinghamAPI.Constants.Constants;

namespace UniversityOfNottinghamAPI.Services.UserManagement
{
    public class UserManagementService :IUserManagementService
    {
        private readonly ICommonService _commonService;

        public UserManagementService(ICommonService commonService)
        {
            _commonService = commonService;
        }        
        public async Task<dynamic> ReadUser()
        {
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Read, string.Empty);
        }
        public async Task<dynamic> CreateUser(UserManagementInput userManagementInput)
        {
            userManagementInput.userId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Create, userManagementInput);
        }
        public async Task<dynamic> UpdateUser(UserManagementInput userManagementInput)
        {
            userManagementInput.userId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Update, userManagementInput);
        }
        public async Task<dynamic> DeleteUser(UserManagementInput userManagementInput)
        {
            userManagementInput.userId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Delete, userManagementInput);
        }
    }
}
