using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Visnor.BusinessLogic.Interfaces;
using Visnor.Common.DTO_S.AuthDto;
using Visnor.Common.DTO_S.UserDto;
using Visnor.Common.Enums;
using Visnor.Models;
using Visnor.Models.Models;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Visnor.BusinessLogic.Services;

public class AuthService : IAuthService
{
    private readonly string? _jwtSubject;
    private readonly string? _jwtKey;
    private readonly string? _jwtIssuer;
    private readonly string? _jwtAudience;

    private readonly IHashService _hashService;
    private readonly IUserService _userService;
    private readonly ApplicationContext _applicationContext;

    public AuthService(IConfiguration configuration, IHashService hashService, IUserService userService, 
        ApplicationContext applicationContext)
    {
        _jwtSubject = configuration["Jwt:Subject"];
        _jwtKey = configuration["Jwt:Key"];
        _jwtIssuer = configuration["Jwt:Issuer"];
        _jwtAudience = configuration["Jwt:Audience"];
        
        _hashService = hashService;
        _userService = userService;
        _applicationContext = applicationContext;
    }
    
    public AuthResponse Login(LoginDto model)
    {
        var hashPassword = _hashService.VerifyHashPassword(model.Email, model.Password);

        var searchUserDto = new SearchUserDto
        {
            Email = model.Email,
            Password = hashPassword
        };

        var user = _userService.GetUser(searchUserDto);

        if (user != null)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _jwtSubject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)),
                new Claim("Id", user.Id.ToString()),
                new Claim("Login", model.Email),
                new Claim("Password", hashPassword)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _jwtIssuer,
                _jwtAudience,
                claims,
                expires: DateTime.UtcNow.AddYears(1),
                signingCredentials: signIn);


            var authResponse = new AuthResponse
            {
                UserId = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                Role = (Role)user.Role
            };
            
            return authResponse;
        }

        return new AuthResponse();
    }

    public string Registration(RegistrationDto model)
    {
        var users = _userService.GetAllUser().AsQueryable();

        var userCheck = users.Where(u => u.Email == model.Email).ToList();

        if (userCheck.Count == 0)
        {
            var hashPassword = _hashService.CreateHashPassword(model.Email, model.Password);

            var user = new User
            {
                Email = model.Email,
                Password = hashPassword,
                Favorite = model.Favorite,
                Role = (int)Role.User
            };

            _applicationContext.Users.Add(user);

            return $"{DateTime.UtcNow}: Registration user with {user.Email} was successfully";
        }
        
        return string.Empty;
    }
}