using Microsoft.AspNetCore.Mvc;
using TechnicalTestAPI.Constants;
using TechnicalTestAPI.ModelMapping.UserManagement;
using TechnicalTestAPI.Models.ServiceModels;
using TechnicalTestAPI.Services.Common;

namespace TechnicalTestAPI.Services.UserManagement
{
    public class UserManagementService : IUserManagementService
    {
        private readonly ICommonService _commonService;
        private readonly IUserManagementModelMapping _userManagementModelMapping;

        public UserManagementService(ICommonService commonService, IUserManagementModelMapping userManagementModelMapping)
        {
            _commonService = commonService;
            _userManagementModelMapping = userManagementModelMapping;
        }

        public async Task<dynamic> ReadUsers()
        {
            var result = await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Read, string.Empty);
            if (result.GetType() == typeof(ErrorModel))
            {
                return result;
            }
            else
                return await _userManagementModelMapping.UserManagementMapping(result);
        }

        public async Task<dynamic> CreateUsers(UserAccounts userManagementInput)
        {
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Create, userManagementInput);
        }

        public async Task<dynamic> UpdateUsers(UserAccounts userManagementInput)
        {
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Update, userManagementInput);
        }

        public async Task<dynamic> DeleteUsers(UserAccounts userManagementInput)
        {
            var result = await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Delete, userManagementInput);
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