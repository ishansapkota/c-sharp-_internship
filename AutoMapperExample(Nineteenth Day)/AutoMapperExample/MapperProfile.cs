using AutoMapper;
using AutoMapperExample.Models;

namespace AutoMapperExample
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
