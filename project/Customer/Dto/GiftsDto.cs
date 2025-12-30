using project.Manage.Models;

namespace project.Customer.Dto
{
    public class GiftsDto
    {
        public class GetGift
        {
            public string Description { get; set; }
            public string Name { get; set; }
            public Category Category { get; set; }
            public int PriceTiket { get; set; } // או סוג נתון אחר תלוי בהגדרה שלך
            public string ImageUrl { get; set; }
        }
        public class AddToCartDto
        {
            public string Name { get; set; }
            public int PriceTiket { get; set; } 
            public string ImageUrl { get; set; }
            public int UserId { get; set; }


        }
    }
}
