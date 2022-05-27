namespace Dealership.Entities.ViewModels.Cars
{
    public class CarsEditViewModel : CarsCreateAndEditViewModel
    {
        public int CarId { get; set; }

        public int EngineId { get; set; }
    }
}
