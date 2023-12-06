using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestAPI.Models.ServiceModels;
using TechnicalTestAPI.Services.DatabaseManagement;

namespace TechnicalTestAPI.Controllers.DatabaseManagement
{
    [Route("api/database-management")]
    [EnableCors]
    public class DatabaseManagementController : Controller
    {
        private readonly IDatabaseManagementService _databaseManagementService;
        public DatabaseManagementController(IDatabaseManagementService databaseManagementService)
        {
            _databaseManagementService = databaseManagementService;
        }
        [HttpDelete]
        [Route("delete-all-values")]
        public async Task<IActionResult> DeleteAllValues([FromBody] string tableName)
        {
            var result = await _databaseManagementService.DeleteAllValues(tableName);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
