using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.AccessLogs;

namespace UniversityOfNottinghamAPI.Controllers.AccessLogs
{
    [Route("api/access-logs")]
    [EnableCors]
    public class AccessLogsController : Controller
    {
        private readonly IAccessLogsService _accessLogsService;

        public AccessLogsController(IAccessLogsService accessLogsService)
        {
            _accessLogsService = accessLogsService;
        }

        [HttpGet]
        [Route("read-access-logs")]
        public async Task<IActionResult> ReadAccessLogs()
        {
            var result = await _accessLogsService.ReadAccessLogs();
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("create-access-logs")]
        public async Task<IActionResult> CreateAccessLogs([FromBody] AccessLog accessLogsInput)
        {
            var result = await _accessLogsService.CreateAccessLogs(accessLogsInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("update-access-logs")]
        public async Task<IActionResult> UpdateAccessLogs([FromBody] AccessLog accessLogsInput)
        {
            var result = await _accessLogsService.UpdateAccessLogs(accessLogsInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpDelete]
        [Route("delete-access-logs")]
        public async Task<IActionResult> DeleteAccessLogs([FromBody] AccessLog accessLogsInput)
        {
            var result = await _accessLogsService.DeleteAccessLogs(accessLogsInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }
}