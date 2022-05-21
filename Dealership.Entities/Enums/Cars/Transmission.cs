using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.Enums.Cars
{
    public enum Transmission
    {
        Manual,
        Automatic,
        [Display(Name = "Dual-Clutch")]
        DualClutch,
        CVT
    }
}
