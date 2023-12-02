using System.Reflection.Metadata;
using UniversityOfNottinghamAPI.Database;
using UniversityOfNottinghamAPI.ModelMapping.UserManagement;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.Common;
using UniversityOfNottinghamAPI.Services.Document;
using Constant = UniversityOfNottinghamAPI.Constants.Constants;

namespace UniversityOfNottinghamAPI.Services.UserManagement
{
    public class UserManagementService :IUserManagementService
    {
        private readonly ICommonService _commonService;
        private readonly IUserManagementModelMapping _userManagementModelMapping;

        public UserManagementService(ICommonService commonService)
        {
            _commonService = commonService;
        }        
        public async Task<List<UserAccounts>> ReadUsers()
        {
            var result = _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Read, string.Empty);
            return await _userManagementModelMapping.UserManagementMapping(result);
        }
        public async Task<dynamic> CreateUsers(Models.ServiceModels.UserAccounts userManagementInput)
        {
            userManagementInput.userId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Create, userManagementInput);
        }
        public async Task<dynamic> UpdateUsers(Models.ServiceModels.UserAccounts userManagementInput)
        {
            userManagementInput.userId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Update, userManagementInput);
        }
        public async Task<dynamic> DeleteUsers(Models.ServiceModels.UserAccounts userManagementInput)
        {
            userManagementInput.userId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Delete, userManagementInput);
        }
    }
}
