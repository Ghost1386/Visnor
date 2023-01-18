using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Visnor.BusinessLogic.Interfaces;
using Visnor.Common.DTO_S.AuthDto;
using Visnor.Common.DTO_S.UserDto;
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
    private readonly IMapper _mapper;

    public AuthService(IConfiguration configuration, IHashService hashService, IUserService userService, IMapper mapper)
    {
        _jwtSubject = configuration["Jwt:Subject"];
        _jwtKey = configuration["Jwt:Key"];
        _jwtIssuer = configuration["Jwt:Issuer"];
        _jwtAudience = configuration["Jwt:Audience"];
        
        _hashService = hashService;
        _userService = userService;
        _mapper = mapper;
    }
    
    public string Login(LoginDto model)
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

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        return string.Empty;
    }

    public void Registration(RegistrationDto model)
    {
        throw new NotImplementedException();
    }
}