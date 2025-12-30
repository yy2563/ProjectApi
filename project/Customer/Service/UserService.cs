using project.Customer.Dto;
using project.Customer.Interface;
using project.Models.Customer;

namespace project.Customer.Servise
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserDto.registerDto> CreateUser(UserDto.registerDto register)
        {
            var user = new UserModel

            {
                Name = register.Name,
                Email = register.Email,
                Password = register.Password,
                Phone = register.Phone,
                UserName = register.UserName,

            };
            var createdUser = await _userRepository.CreateUser(user);
            return MapToResponseDto(createdUser);

        }
        private static UserDto.registerDto MapToResponseDto(UserModel user)
        {
            return new UserDto.registerDto
            {
                //Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                UserName = user.UserName,
                CreatedAt = user.CreatedAt
            };
        }
        public async Task<UserDto.loginDto> LoginUser(UserDto.loginDto login)
        {
            var user = await _userRepository.GetUserByUserName(login.UserName);
            if (user == null || user.Password != login.Password)
            {
                throw new ArgumentException("Invalid username or password.");
            }
            return new UserDto.loginDto
            {
                UserName = user.UserName,
                Password = user.Password
            };


        }
        public async Task<IEnumerable<UserDto.getUserDto>> GetAllUsers() {
            var allUsers = await _userRepository.GetAllUsers();
            return (IEnumerable<UserDto.getUserDto>)allUsers;
        } 
   }
}
