using project.Customer.Dto;

namespace project.Customer.Interface
{
    public interface IUserService
    {
        Task <UserDto.registerDto> CreateUser(UserDto.registerDto register);
        Task<UserDto.loginDto> LoginUser(UserDto.loginDto login);
        Task<IEnumerable<UserDto.getUserDto>> GetAllUsers();

    }
}
