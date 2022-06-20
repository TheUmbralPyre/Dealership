using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Data.DataModels.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(20)")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int UsernameChangeLimit { get; set; } = 10;

        public DateTime DateJoined { get; set; }

        public string ProfilePictureOriginalPath { get; set; }

        public string ProfilePictureNavbarPath { get; set; }

        public string ProfilePictureManagePath { get; set; }

        public string ProfilePictureCommonPath { get; set; }

        public IEnumerable<CarForSale> CarsForSale { get; set; }
    }
}
