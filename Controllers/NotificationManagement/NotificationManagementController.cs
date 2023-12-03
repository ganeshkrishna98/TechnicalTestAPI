using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.NotificationManagement;

namespace UniversityOfNottinghamAPI.Controllers.NotificationManagement
{
    [Route("api/notification-management")]
    [EnableCors]
    public class NotificationManagementController : Controller
    {
        private readonly INotificationManagementService _notificationManagementService;

        public NotificationManagementController(INotificationManagementService notificationManagementService)
        {
            _notificationManagementService = notificationManagementService;
        }

        [HttpGet]
        [Route("read-notifications")]
        public async Task<IActionResult> ReadNotifications()
        {
            var result = await _notificationManagementService.ReadNotifications();
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("create-notifications")]
        public async Task<IActionResult> CreateNotifications([FromBody] Notifications notificationsInput)
        {
            var result = await _notificationManagementService.CreateNotifications(notificationsInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("update-notifications")]
        public async Task<IActionResult> UpdateNotifications([FromBody] Notifications notificationsInput)
        {
            var result = await _notificationManagementService.UpdateNotifications(notificationsInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpDelete]
        [Route("delete-notifications")]
        public async Task<IActionResult> DeleteNotifications([FromBody] Notifications notificationsInput)
        {
            var result = await _notificationManagementService.DeleteNotifications(notificationsInput);
            if (result.GetType() == typeof(ErrorModel))
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }
}