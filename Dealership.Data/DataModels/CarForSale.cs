﻿using Dealership.Data.DataModels.CarModels;
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

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [Range(1, 1000000)]
        public int Price { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
