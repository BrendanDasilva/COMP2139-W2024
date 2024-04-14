using Microsoft.AspNetCore.Identity;

namespace Assignment1.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int UsernameChangeLimit { get; set; } = 10;
        public byte[]? ProfilePicture { get; set; }

        public string? HotelLoyaltyID { get; set; }

        public string? FrequentFlyerNumber { get; set; }

    }

}
