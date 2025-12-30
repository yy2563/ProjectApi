using project.Customer.Dto;
using project.Customer.Interface;
using project.Data;
using project.Manage.Models;
using Microsoft.EntityFrameworkCore;
using project.Models.Customer;

namespace project.Customer.Repository
{
    public class GiftRepository : IGiftRepository
    {
        private readonly ApplicationDbContext _context;

        public GiftRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all gifts
        public async Task<IEnumerable<GiftsDto.GetGift>> GetGift()
        {
            return await _context.DonationsModel
                .Include(d => d.Category)
                .Select(u => new GiftsDto.GetGift
                {
                    Description = u.Description,
                    Name = u.Name,
                    Category = u.Category,
                    PriceTiket = u.PriceTiket,
                    ImageUrl = u.ImageUrl
                })
                .OrderBy(g => g.PriceTiket)
                .ThenBy(g => g.Category)
                .ToListAsync();
        }

        // Save shopping cart
        public async Task CreateShoppingCart(ShoppingCartModel cart)
        {
            await _context.ShoppingCartModel.AddAsync(cart);
        }

        // Find gift by id
        public async Task<DonationsModel?> FindGiftById(int giftId)
        {
            return await _context.DonationsModel.FindAsync(giftId);
        }

        // Save changes
        public async Task<bool> SaveChangesInShoppingCart()
        {
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }
    }
}
