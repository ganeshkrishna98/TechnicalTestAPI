using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
