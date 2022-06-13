using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Data.DataModels
{
    public enum BodyType
    {
        Hatchback,
        Sedan,
        StationWagon,
        Coupe,
        FourDoorCoupe,
        SUV
    }

    public enum Transmission
    {
        Manual,
        Automatic,
        DualClutch,
        CVT
    }

    public enum Status
    {
        New,
        Used
    }

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string ModelName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string Generation { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public BodyType BodyType { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string Color { get; set; }

        [Required]
        public Transmission Transmission { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Engine Engine { get; set; }

        public virtual CarForSale CarForSale { get; set; }
    }
}
