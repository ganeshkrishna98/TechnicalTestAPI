using Microsoft.AspNetCore.Mvc;
using TechnicalTestAPI.Models.ServiceModels;
using TechnicalTestAPI.Services.Common;

namespace TechnicalTestAPI.Services.DatabaseManagement
{
    public class DatabaseManagementService : IDatabaseManagementService
    {
        private readonly ICommonService _commonService;

        public DatabaseManagementService(ICommonService commonService)
        {
            _commonService = commonService;
        }
        public async Task<IActionResult> DeleteAllValues(string tableName)
        {
            var result = await _commonService.DeleteAllValues(tableName);
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
