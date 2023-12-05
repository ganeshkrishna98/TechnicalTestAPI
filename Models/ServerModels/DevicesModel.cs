using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTestAPI.Models.ServerModels
{
    public class DevicesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string deviceId { get; set; }
        public string deviceName { get; set; }
        public string deviceType { get; set; }
        public string deviceOs { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string lastAccessedDate { get; set; }
        public string lastAccessedTime { get; set; }
    }
}
