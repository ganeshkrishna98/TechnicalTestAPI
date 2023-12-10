namespace TechnicalTestAPI.Models.ServiceModels
{
    public class AuthenticationOutput
    {
        public string userId { get; set; }
        public string userEmail { get; set; }
        public string loginStatus { get; set; }
        public string Token { get; set; }
        public string accountType {  get; set; }
    }
}
