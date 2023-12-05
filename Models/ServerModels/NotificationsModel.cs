using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTestAPI.Models.ServerModels
{
    public class NotificationsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string notificationId { get; set; }
        public string notificationName { get; set; }
        public string notificationContent { get; set; }
        public string createdDate { get; set; }
        public string createdTime { get; set; }
        public string createdUserId { get; set; }
        public string createdUserName { get; set; }
    }
}
