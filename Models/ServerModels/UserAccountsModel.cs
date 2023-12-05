using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTestAPI.Models.ServerModels
{
    public class UserAccountsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string userId { get; set; }
        public string userEmail { get; set; }
        public string userName { get; set; }
        public string lastAccessTime { get; set; }
        public string lastAccessDevice { get; set; }
        public string lastAccessIp { get; set; }
        public string accountType { get; set; }
    }
}