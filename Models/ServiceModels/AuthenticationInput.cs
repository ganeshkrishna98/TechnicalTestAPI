namespace TechnicalTestAPI.Models.ServiceModels
{
    public class AuthenticationLoginInput
    {
        public string userEmail { get; set; }
        public string password { get; set; }
    }

    public class NewUserInput
    {
        public string userId { get; set; }
        public string userEmail { get; set; }
        public string passwordHash { get; set; }
        public string passwordSalt { get; set; }
    }
}
