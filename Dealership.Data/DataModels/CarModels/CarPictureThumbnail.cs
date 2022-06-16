using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Data.DataModels.CarModels
{
    public class CarPictureThumbnail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Path { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}