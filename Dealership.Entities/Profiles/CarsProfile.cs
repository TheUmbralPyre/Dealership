using AutoMapper;
using Dealership.Data.Models;
using Dealership.Entities.ViewModels.Cars;

namespace Dealership.Entities.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            // Index
            CreateMap<Car, CarsIndexViewModel>()
                .AfterMap((car, detailsCarVM, context) =>
                {
                    context.Mapper.Map(car.Engine, detailsCarVM);
                });
            CreateMap<Engine, CarsIndexViewModel>()
            .ForMember(vm => vm.Id, opt => opt.Ignore());

            // Details
            CreateMap<Car, CarsDetailsViewModel>()
                .AfterMap((car, detailsCarVM, context) =>
                {
                    context.Mapper.Map(car.Engine, detailsCarVM);
                });
            CreateMap<Engine, CarsDetailsViewModel>();

            // Edit Get
            CreateMap<Car, CarsEditViewModel>()
                .AfterMap((car, detailsCarVM, context) =>
                {
                    context.Mapper.Map(car.Engine, detailsCarVM);
                })
                .ForMember(c => c.CarId, opt => opt.MapFrom(s => s.Id));
            CreateMap<Engine, CarsEditViewModel>()
                .ForMember(e => e.EngineId, opt => opt.MapFrom(s => s.Id));

            // Edit Post
            CreateMap<CarsEditViewModel, Car>()
                .AfterMap((detailsCarVM, car, context) =>
                {
                    context.Mapper.Map(detailsCarVM, car.Engine);
                })
                .ForMember(c => c.Id, opt => opt.MapFrom(s => s.CarId));
            CreateMap<CarsEditViewModel, Engine>()
                .ForMember(e => e.Id, opt => opt.MapFrom(s => s.EngineId))
                .ForMember(e => e.CarId, opt => opt.MapFrom(s => s.CarId));

            // Create
            CreateMap<CarsCreateViewModel, Car>()
                .AfterMap((detailsCarVM, car, context) =>
                {
                    context.Mapper.Map(detailsCarVM, car.Engine);
                });
            CreateMap<CarsCreateViewModel, Engine>();

            // Delete
            CreateMap<Car, CarsDeleteViewModel>()
                .AfterMap((car, detailsCarVM, context) =>
                {
                    context.Mapper.Map(car.Engine, detailsCarVM);
                });
            CreateMap<Engine, CarsDeleteViewModel>();
        }
    }
}
