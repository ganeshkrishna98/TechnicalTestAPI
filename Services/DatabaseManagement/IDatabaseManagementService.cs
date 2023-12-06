using Microsoft.AspNetCore.Mvc;

namespace TechnicalTestAPI.Services.DatabaseManagement
{
    public interface IDatabaseManagementService
    {
        public Task<IActionResult> DeleteAllValues(string tableName);
    }
}
