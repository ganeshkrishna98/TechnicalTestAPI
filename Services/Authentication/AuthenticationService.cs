using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using UniversityOfNottinghamAPI.Database;
using UniversityOfNottinghamAPI.Models.ServerModels;

namespace UniversityOfNottinghamAPI.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DatabaseContext _dbContext;

        public AuthenticationService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AuthenticateUser(string email, string password)
        {
            try
            {
                var user = await _dbContext.UserAuthentication
                    .SingleOrDefaultAsync(u => u.userEmail.ToLower() == email.ToLower());

                if (user != null && VerifyPassword(password, user.passwordHash, user.passwordSalt))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in AuthenticateUser: {ex}");
                return false;
            }
        }

        public async Task<bool> CreateUser(string email, string password)
        {
            try
            {
                if (_dbContext.UserAuthentication.Any(u => u.userEmail == email))
                {
                    return false;
                }

                var (hash, salt) = GeneratePasswordHash(password);

                var newUser = new UserAuthenticationModel
                {
                    userId = Guid.NewGuid().ToString(),
                    userEmail = email,
                    passwordHash = hash,
                    passwordSalt = salt
                };

                _dbContext.UserAuthentication.Add(newUser);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in CreateUser: {ex}");
                return false;
            }
        }

        private (string Hash, string Salt) GeneratePasswordHash(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 16, 10000))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] hash = deriveBytes.GetBytes(32);

                return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
            }
        }

        private bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            try
            {
                byte[] salt = Convert.FromBase64String(storedSalt);
                byte[] storedHashBytes = Convert.FromBase64String(storedHash);

                using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000))
                {
                    byte[] computedHashBytes = deriveBytes.GetBytes(32);

                    return computedHashBytes.SequenceEqual(storedHashBytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in VerifyPassword: {ex}");
                return false;
            }
        }

        public async Task<string> GetUserId(string email)
        {
            var userAcc = await _dbContext.UserAuthentication.FirstOrDefaultAsync(x =>x.userEmail== email);

            return userAcc?.userId;
        }
    }
}