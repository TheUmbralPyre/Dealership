using System;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Data.DataModels.CarModels
{
    public class CarPictureThumbnail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Path { get; set; }

    }
}