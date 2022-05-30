using Microsoft.AspNetCore.Identity;

namespace Dealership.Data.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        // TODO: Add Limits instead of NAVCHAR(MAX)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[] ProfilePicture { get; set; }
    }
}
