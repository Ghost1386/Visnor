using AutoMapper;
using Visnor.Common.DTO_S.AuthDto;
using Visnor.Common.DTO_S.UserDto;

namespace Visnor.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<LoginDto, SearchUserDto>();
    }
}