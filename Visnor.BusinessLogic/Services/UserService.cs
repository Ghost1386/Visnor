using AutoMapper;
using Visnor.BusinessLogic.Interfaces;
using Visnor.Common.DTO_S.UserDto;
using Visnor.Common.Enums;
using Visnor.Models;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly ApplicationContext _applicationContext;
    private readonly IPremiumService _premiumService;
    private readonly IMapper _mapper;
    
    public UserService(ApplicationContext applicationContext, IPremiumService premiumService, 
        IMapper mapper)
    {
        _applicationContext = applicationContext;
        _premiumService = premiumService;
        _mapper = mapper;
    }
    
    public List<User> GetAllUser()
    {
        return _applicationContext.Users.ToList();
    }

    public User GetUser(SearchUserDto model)
    {
        var user = _applicationContext.Users.FirstOrDefault(u => u.Email == model.Email &&
                                                                 u.Password == model.Password);

        return user ?? new User();
    }

    public string CreateUser(CreateUserDto model)
    {
        if (_applicationContext.Users.Any(u => u.Email == model.Email))
        {
            return $"The user with this {model.Email} is already registered.";
        }
        
        var user = _mapper.Map<CreateUserDto, User>(model);

        _applicationContext.Users.Add(user);

        _premiumService.CreatePremium(user.Id);

        return string.Empty;
    }

    public string BannedUser(string email, string reason)
    {
        var user = _applicationContext.Users.FirstOrDefault(u => u.Email == email);
        
        if (user != null)
        {
            user.Role = (int)Role.Banned;

            _applicationContext.Users.Update(user);

            var ban = new Ban
            {
                UserId = user.Id,
                Email = email,
                Reason = reason
            };

            _applicationContext.Bans.Add(ban);

            return $"User with this {email} was banned successfully";
        }

        return $"User with this {email} does not exist";
    }
}