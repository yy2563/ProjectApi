using Microsoft.EntityFrameworkCore;
using project.Customer.Dto;
using project.Customer.Interface;
using project.Data;
using project.Models.Customer;

namespace project.Customer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserModel> CreateUser(UserModel user)
        {
            user.CreatedAt = DateTime.UtcNow;

            _context.UserModel.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> GetUserByUserName(string UserName)
        {

            var user = await _context.UserModel.FirstOrDefaultAsync(x => x.UserName == UserName);
            return user;

        }
        public async Task<IEnumerable<UserDto.getUserDto>> GetAllUsers()
        {
            return await _context.UserModel.Select(u => new UserDto.getUserDto
            {
                Name = u.Name,
                Email = u.Email,
                Phone = u.Phone,
                UserName = u.UserName,
            }).ToListAsync();

        }
    }

}
