using Dealership.Entities.Enums.Cars;

namespace Dealership.Entities.FilterClasses
{
    public class SearchFilter
    {
        public string TitleFilter { get; set; }

        public string ColorFilter { get; set; }

        public BodyType? BodyTypeFilter { get; set; }

        public Transmission? TransmissionFilter { get; set; }

        public int YearMinFilter { get; set; }

        public int YearMaxFilter { get; set; }

        public int MileageMinFilter { get; set; }

        public int MileageMaxFilter { get; set; }

    }
}
