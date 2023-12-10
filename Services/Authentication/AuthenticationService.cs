using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TechnicalTestAPI.Constants;
using TechnicalTestAPI.Database;
using TechnicalTestAPI.Models.ServerModels;
using TechnicalTestAPI.Models.ServiceModels;
using TechnicalTestAPI.Services.UserManagement;

namespace TechnicalTestAPI.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DatabaseContext _dbContext;
        private readonly string _jwtSecret;
        private readonly IUserManagementService _userManagementService;
        public AuthenticationService(DatabaseContext dbContext, IUserManagementService userManagementService)
        {
            _dbContext = dbContext;
            _jwtSecret = GenerateSecureSecret();
            _userManagementService = userManagementService;
        }

        public async Task<AuthenticationOutput> AuthenticateUser(string email, string password)
        {
            try
            {
                var user = await _dbContext.UserAuthentication
                    .SingleOrDefaultAsync(u => u.userEmail.ToLower() == email.ToLower());
                if (user != null && VerifyPassword(password, user.passwordHash, user.passwordSalt))
                {
                    var token = GenerateJwtToken(email);
                    List<UserAccounts> readUsers = await _userManagementService.ReadUsers();
                    string usersId = await GetUserId(email);
                    AuthenticationOutput authenticationOutput = new()
                    {
                        loginStatus = Constant.Success,
                        userEmail = email,
                        userId = usersId,
                        Token = token,
                        accountType = readUsers.Where(x => x.userId == usersId).FirstOrDefault().accountType

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

        public async Task<bool> CreateUser(NewUserInput model)
        {
            try
            {
                if (_dbContext.UserAuthentication.Any(u => u.userEmail == model.email))
                {
                    return false;
                }
                var (hash, salt) = GeneratePasswordHash(model.password);
                var newUser = new UserAuthenticationModel
                {
                    userId = Guid.NewGuid().ToString(),
                    userEmail = model.email,
                    passwordHash = hash,
                    passwordSalt = salt
                };
                _dbContext.UserAuthentication.Add(newUser);
                await _dbContext.SaveChangesAsync();
                model.userAccounts.userId = newUser.userId;
                model.userAccounts.userEmail = model.email;
                model.userAccounts.accountType = "Standard";
                await _userManagementService.CreateUsers(model.userAccounts);
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

        private string GenerateJwtToken(string userEmail)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userEmail),
                }),
                Expires = DateTime.UtcNow.AddHours(1), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> GetUserId(string email)
        {
            var userAcc = await _dbContext.UserAuthentication.FirstOrDefaultAsync(x => x.userEmail == email);
            return userAcc?.userId;
        }

        private string GenerateSecureSecret()
        {
            const int keyLength = 32;

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[keyLength];
                randomNumberGenerator.GetBytes(randomNumber);

                return BitConverter.ToString(randomNumber).Replace("-", "").ToLower();
            }
        }
    }
}