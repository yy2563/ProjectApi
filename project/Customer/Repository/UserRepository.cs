using project.Customer.Interface;
using project.Data;
using project.Models.Customer;

namespace project.Customer.Repository
{
    public class UserRepository:IUserRepository
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

        public async Task<UserModel> GetByUserName(string UserName)
        {
            
            var user= await _context.UserModel.FindAsync(UserName);
            return user;

        }
    }

}
