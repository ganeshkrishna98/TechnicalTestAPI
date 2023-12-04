namespace UniversityOfNottinghamAPI.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<bool> AuthenticateUser(string email, string password);
        public Task<bool> CreateUser(string email, string password);
        public Task<string> GetUserId(string email);
    }
}
