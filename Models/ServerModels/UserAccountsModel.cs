using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityOfNottinghamAPI.Models.ServerModels
{
    public class UserAccountsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string userId { get; set; }
        public string userEmail { get; set; }
        public string userSecret { get; set; }
        public string userName { get; set; }
        public string lastAccessTime { get; set; }
        public string lastAccessDevice { get; set; }
        public string lastAccessIP { get; set; }
        public string accountType { get; set; }
    }
}