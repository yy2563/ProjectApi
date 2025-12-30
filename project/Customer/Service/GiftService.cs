using project.Customer.Dto;
using project.Customer.Interface;
using project.Models.Customer;

namespace project.Customer.Service
{
    public class GiftService : IGiftService
    {
        private readonly IGiftRepository _giftRepository;
        private readonly IUserRepository _userRepository;

        public GiftService(
            IGiftRepository giftRepository,
            IUserRepository userRepository)
        {
            _giftRepository = giftRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<GiftsDto.GetGift>> GetGift()
        {
            return await _giftRepository.GetGift();
        }

        public async Task<bool> AddGiftToCart(int giftId, string userName)
        {
            var findUser = await _userRepository.GetUserByUserName(userName);
            if (findUser == null)
                throw new ArgumentException("User not found");

            var findGift = await _giftRepository.FindGiftById(giftId);
            if (findGift == null)
                throw new ArgumentException("Gift not found");

            var activeCart = findUser.ShoppingCarts.FirstOrDefault();

            if (activeCart == null)
            {
                activeCart = new ShoppingCartModel
                {
                    UserId = findUser.Id
                };

                await _giftRepository.CreateShoppingCart(activeCart);
            }

            var existingItem = activeCart.GiftShoppingCart
                ?.FirstOrDefault(g => g.DonationId == giftId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                activeCart.GiftShoppingCart.Add(new GiftShoppingCartModel
                {
                    DonationId = giftId,
                    Quantity = 1
                });
            }

            return await _giftRepository.SaveChangesInShoppingCart();
        }
    }
}
