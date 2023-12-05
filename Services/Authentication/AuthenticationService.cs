using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using UniversityOfNottinghamAPI.Constants;
using UniversityOfNottinghamAPI.Database;
using UniversityOfNottinghamAPI.Models.ServerModels;
using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DatabaseContext _dbContext;

        public AuthenticationService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AuthenticationOutput> AuthenticateUser(string email, string password)
        {
            try
            {
                var user = await _dbContext.UserAuthentication
                    .SingleOrDefaultAsync(u => u.userEmail.ToLower() == email.ToLower());
                if (user != null && VerifyPassword(password, user.passwordHash, user.passwordSalt))
                {
                    AuthenticationOutput authenticationOutput = new()
                    {
                        loginStatus = Constant.Success,
                        userEmail = email,
                        userId = await GetUserId(email)
                    };
                    return authenticationOutput;
                }
                else
                {
                    if (user != null)
                    {
                        AuthenticationOutput authenticationOutput = new()
                        {
                            loginStatus = Constant.Failed,
                            userEmail = email,
                            userId = await GetUserId(email)
                        };
                        return authenticationOutput;
                    }
                    else
                    {
                        AuthenticationOutput authenticationOutput = new()
                        {
                            loginStatus = Constant.Failed,
                            userEmail = email
                        };
                        return authenticationOutput;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in AuthenticateUser: {ex}");
                AuthenticationOutput authenticationOutput = new()
                {
                    loginStatus = Constant.Failed,
                    userEmail = email
                };
                return authenticationOutput;
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
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
            int iterations = 10000;
            byte[] salt = GenerateRandomSalt();
            using var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm);
            byte[] hash = deriveBytes.GetBytes(32);
            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        private byte[] GenerateRandomSalt()
        {
            byte[] salt = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            try
            {
                byte[] salt = Convert.FromBase64String(storedSalt);
                byte[] storedHashBytes = Convert.FromBase64String(storedHash);
                HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
                int iterations = 10000;
                using var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm);
                byte[] computedHashBytes = deriveBytes.GetBytes(32);
                return computedHashBytes.SequenceEqual(storedHashBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in VerifyPassword: {ex}");
                return false;
            }
        }


        public async Task<string> GetUserId(string email)
        {
            var userAcc = await _dbContext.UserAuthentication.FirstOrDefaultAsync(x => x.userEmail == email);
            return userAcc?.userId;
        }
    }
}