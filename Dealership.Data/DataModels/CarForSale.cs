using Dealership.Data.DataModels.IdentityModels;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Data.DataModels
{
    public class CarForSale
    {
        [Key]
        public int Id { get; set; }

        public int CarId { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual Car Car { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
