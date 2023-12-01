using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> CreateUser(string email, string password)
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

            // User creation successful
            return true;
        }

        private (string Hash, string Salt) GeneratePasswordHash(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 16, 10000))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] hash = deriveBytes.GetBytes(32); // 32 bytes for a 256-bit hash

                return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
            }
        }

        private bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            byte[] salt = Convert.FromBase64String(storedSalt);
            byte[] storedHashBytes = Convert.FromBase64String(storedHash);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] computedHashBytes = deriveBytes.GetBytes(32); // 32 bytes for a 256-bit hash

                return computedHashBytes.SequenceEqual(storedHashBytes);
            }
        }
    }
}
