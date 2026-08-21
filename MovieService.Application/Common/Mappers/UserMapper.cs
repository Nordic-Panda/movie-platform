using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Common.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto(user.Id, user.Email);
        }
    }
}
