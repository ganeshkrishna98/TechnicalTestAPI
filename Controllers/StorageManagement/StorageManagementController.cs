using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.StorageManagement;

namespace UniversityOfNottinghamAPI.Controllers.StorageManagement
{
    [Route("api/storage-management")]
    [EnableCors]
    public class StorageManagementController : Controller
    {
        private readonly IStorageManagementService _storageManagementService;

        public StorageManagementController(IStorageManagementService storageManagementService)
        {
            _storageManagementService = storageManagementService;
        }

        [HttpGet]
        [Route("read-storages")]
        public async Task<IActionResult> ReadStorages()
        {
            var result = await _storageManagementService.ReadStorages();
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("create-storages")]
        public async Task<IActionResult> CreateStorages([FromBody] Storages storageManagementInput)
        {
            var result = await _storageManagementService.CreateStorages(storageManagementInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("update-storages")]
        public async Task<IActionResult> UpdateStorages([FromBody] Storages storageManagementInput)
        {
            var result = await _storageManagementService.UpdateStorages(storageManagementInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpDelete]
        [Route("delete-storages")]
        public async Task<IActionResult> DeleteStorages([FromBody] Storages storageManagementInput)
        {
            var result = await _storageManagementService.DeleteStorages(storageManagementInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }
}