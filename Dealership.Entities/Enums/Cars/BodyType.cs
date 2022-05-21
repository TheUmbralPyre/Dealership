using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.Enums.Cars
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
}
