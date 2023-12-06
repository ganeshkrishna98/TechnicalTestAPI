using Microsoft.AspNetCore.Mvc;
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
            return await _commonService.DeleteAllValues(tableName);
        }
    }
}
