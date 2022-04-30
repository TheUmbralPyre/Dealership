using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Data.Models
{
    public enum BodyType
    {
        [Display(Name = "Hatcback")]
        Hatchback,
        [Display(Name = "Sedan")]
        Sedan,
        [Display(Name = "Station Wagon")]
        StationWagon,
        [Display(Name = "Coupe")]
        Coupe,
        [Display(Name = "Four-Door Coupe")]
        FourDoorCoupe,
        [Display(Name = "Hatcback")]
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

        [Required(ErrorMessage = "This Field Is Required!")]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Cannot be Longer than 50 Characters!")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Cannot be Longer than 50 Characters!")]
        public string Generation { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        [MaxLength(4, ErrorMessage = "Cannot be Longer than 4 Characters!")]
        public int Year { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        public BodyType BodyType { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Cannot be Longer than 50 Characters!")]
        public string Color { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        public Transmission Transmission { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        public Status Status { get; set; }

        #nullable enable
        public Engine? Engine { get; set; }
        #nullable disable
    }
}
