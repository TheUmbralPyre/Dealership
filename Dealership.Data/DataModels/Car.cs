using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Data.DataModels
{
    public enum Brand
    {
        Volkswagen,
        Opel,
        Audi,
        Mercedes,
        Smart,
        BMW,
        Mini,
        Porsche,
        Peugeot,
        Renault,
        Citroen,
        DS,
        Jaguar,
        LandRover,
        Vauxhall,
        Subaru,
        Mitsubishi,
        Nissan,
        Infiniti,
        Toyota,
        Lexus,
        Suziki,
        Mazda,
        Honda,
        Acura,
        Ford,
        Chevrolet,
        Jeep,
        GMC,
        Buick,
        Dodge,
        RAM,
        Cadillac,
        Lincoln,
        Chrysler,
        Tesla,
        Lucid,
        Rivian
    }

    public enum BodyType
    {
        Hatchback,
        Sedan,
        StationWagon,
        Coupe,
        FourDoorCoupe,
        SUV,
        Truck,
        Pickup,
        Van
    }

    public enum Transmission
    {
        Manual,
        Automatic,
        DualClutch,
        CVT
    }

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Brand Brand { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string ModelName { get; set; }

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
        public Engine Engine { get; set; }
    }
}
