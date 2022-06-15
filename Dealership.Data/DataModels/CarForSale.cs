using Dealership.Data.DataModels.IdentityModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Data.DataModels
{
    public class CarForSale
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateAdded { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
