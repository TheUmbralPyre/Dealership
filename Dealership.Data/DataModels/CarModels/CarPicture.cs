using System;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Data.DataModels.CarModels
{
    public class CarPicture
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Path { get; set; } 

        public string Original { get; set; }

        public string Slide { get; set; }

    }
}