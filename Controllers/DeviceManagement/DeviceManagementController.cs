using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestAPI.Models.ServiceModels;
using TechnicalTestAPI.Services.DeviceManagement;

namespace TechnicalTestAPI.Controllers.DeviceManagement
{
    [Route("api/device-management")]
    [EnableCors]
    public class DeviceManagementController : Controller
    {
        private readonly IDeviceManagementService _deviceManagementService;

        public DeviceManagementController(IDeviceManagementService deviceManagementService)
        {
            _deviceManagementService = deviceManagementService;
        }

        [HttpGet]
        [Route("read-devices")]
        public async Task<IActionResult> ReadDevices()
        {
            var result = await _deviceManagementService.ReadDevices();
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("create-devices")]
        public async Task<IActionResult> CreateDevices([FromBody] Devices deviceManagementInput)
        {
            var result = await _deviceManagementService.CreateDevices(deviceManagementInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("update-devices")]
        public async Task<IActionResult> UpdateDevices([FromBody] Devices deviceManagementInput)
        {
            var result = await _deviceManagementService.UpdateDevices(deviceManagementInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpDelete]
        [Route("delete-devices")]
        public async Task<IActionResult> DeleteDevices([FromBody] Devices deviceManagementInput)
        {
            var result = await _deviceManagementService.DeleteDevices(deviceManagementInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }
}