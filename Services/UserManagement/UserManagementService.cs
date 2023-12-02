using System.Reflection.Metadata;
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
        public async Task<dynamic> ReadUsers()
        {
            var result = _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Read, string.Empty);
            return await 
        }
        public async Task<dynamic> CreateUsers(UserManagementInput userManagementInput)
        {
            userManagementInput.userId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Create, userManagementInput);
        }
        public async Task<dynamic> UpdateUsers(UserManagementInput userManagementInput)
        {
            userManagementInput.userId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Update, userManagementInput);
        }
        public async Task<dynamic> DeleteUsers(UserManagementInput userManagementInput)
        {
            userManagementInput.userId = Guid.NewGuid().ToString();
            return await _commonService.ExecuteRequest(typeof(UserManagementService).Name.ToString(), Constant.Delete, userManagementInput);
        }
    }
}
