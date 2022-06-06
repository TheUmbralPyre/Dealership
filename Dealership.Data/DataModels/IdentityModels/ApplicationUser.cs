using Microsoft.AspNetCore.Identity;

namespace Dealership.Data.DataModels.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        // TODO: Add Limits instead of NAVCHAR(MAX)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;

        public byte[] ProfilePictureOriginal { get; set; }

        public byte[] ProfilePictureNav { get; set; }

        public byte[] ProfilePictureIndex { get; set; }

        public byte[] ProfilePictureComment { get; set; }
    }
}
