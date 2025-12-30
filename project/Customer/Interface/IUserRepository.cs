using project.Customer.Dto;
using project.Models.Customer;

namespace project.Customer.Interface
{
    public interface IUserRepository
    {
        Task<UserModel> CreateUser(UserModel user);
        Task<UserModel> GetUserByUserName(string UserName);
        Task <IEnumerable<UserDto.getUserDto>> GetAllUsers();
    }
}
