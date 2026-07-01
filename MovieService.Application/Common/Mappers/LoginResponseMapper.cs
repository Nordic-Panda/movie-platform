using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Common.Mappers
{
    public static class LoginResponseMapper
    {
        public static LoginResponseDto ToDto(string accesstoken, int expiresIn, UserDto dto) 
        {
            return new LoginResponseDto(accesstoken, expiresIn, dto);
        }
    }
}
