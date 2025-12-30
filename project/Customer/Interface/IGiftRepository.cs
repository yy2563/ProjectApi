using project.Customer.Dto;
using project.Manage.Models;
using project.Models.Customer;

namespace project.Customer.Interface
{
    public interface IGiftRepository
    {
        Task<IEnumerable<GiftsDto.GetGift>> GetGift();
        Task CreateShoppingCart(ShoppingCartModel cart);
        Task<DonationsModel?> FindGiftById(int id);
        Task<bool> SaveChangesInShoppingCart();
    }
}
