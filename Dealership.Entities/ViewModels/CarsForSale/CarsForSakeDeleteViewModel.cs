﻿using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.ViewModels.CarsForSale
{
    public class CarsForSakeDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [MaxLength(50, ErrorMessage = "Cannot be Longer than 50 Characters!")]
        public string ModelName { get; set; }
    }
}