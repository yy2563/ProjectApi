using project.Customer.Dto;

namespace project.Customer.Interface
{
    public interface IGiftService
    {
        Task<IEnumerable<GiftsDto.GetGift>> GetGift();
        Task<bool> AddGiftToCart(int giftId, string userName);
    }

}
