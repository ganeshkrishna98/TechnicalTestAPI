using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityOfNottinghamAPI.Models.ServerModels
{
    public class UserAuthenticationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string userId { get; set; }
        public string userEmail { get; set; }
        public string passwordHash { get; set; }
        public string passwordSalt { get; set; }
    }
}
