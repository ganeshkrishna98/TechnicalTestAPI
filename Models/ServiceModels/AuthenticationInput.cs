namespace TechnicalTestAPI.Models.ServiceModels
{
    public class AuthenticationLoginInput
    {
        public string userEmail { get; set; }
        public string password { get; set; }
    }

    public class NewUserInput
    {
        public string email { get; set; }
        public string password { get; set; }
        public UserAccounts userAccounts { get; set; }
    }
}
