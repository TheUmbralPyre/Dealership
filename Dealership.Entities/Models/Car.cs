using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Entities.Models
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
        [Display(Name = "SUV")]
        SUV
    }

    public enum Transmission
    {
        Manual,
        Automatic,
        [Display(Name = "Dual-Clutch")]
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

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Model")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [MaxLength(50, ErrorMessage = "Cannot be Longer than 50 Characters!")]
        public string ModelName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [MaxLength(50, ErrorMessage = "Cannot be Longer than 50 Characters!")]
        public string Generation { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        public int Year { get; set; }

        [Display(Name = "Body Type")]
        [Required(ErrorMessage = "This Field Is Required!")]
        public BodyType BodyType { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [MaxLength(50, ErrorMessage = "Cannot be Longer than 50 Characters!")]
        public string Color { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        public Transmission Transmission { get; set; }

        [DisplayFormat(DataFormatString = "{0} km")]
        [Required(ErrorMessage = "This Field Is Required!")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        public Status Status { get; set; }

        #nullable enable
        public Engine? Engine { get; set; }
        #nullable disable
    }
}
