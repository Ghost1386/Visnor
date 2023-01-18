using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Visnor.BusinessLogic.Interfaces;
using Visnor.Models;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Services;

public class HashService : IHashService
{
    private readonly ApplicationContext _applicationContext;

    public HashService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    public string CreateHashPassword(string email, string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

        var hashedPassword = Hashing(salt, password);

        var auth = new Auth
        {
            Email = email,
            Salt = salt
        };

        _applicationContext.Auths.Add(auth);

        return hashedPassword;
    }

    public string VerifyHashPassword(string email, string password)
    {
        var auth = _applicationContext.Auths.FirstOrDefault(a => a.Email == email);

        if (auth != null)
        {
            var hashedPassword = Hashing(auth.Salt, password);

            return hashedPassword;
        }

        return string.Empty;
    }

    private string Hashing(byte[] salt, string password)
    {
        string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return hashedPassword;
    }
}