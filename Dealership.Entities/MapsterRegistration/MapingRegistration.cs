using Dealership.Data.DataModels;
using Dealership.Data.DataModels.IdentityModels;
using Dealership.Data.Models.IdentityModels;
using Dealership.Entities.ViewModels.CarsForSale;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Entities.MapsterRegistration
{
    internal class MapingRegistration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Map a Profile Picture To an Application User
            config
                .NewConfig<ProfilePicture, ApplicationUser>()
                .Map(dest => dest.ProfilePictureNav, src => src.Nav)
                .Map(dest => dest.ProfilePictureIndex, src => src.AccountIndex)
                .Map(dest => dest.ProfilePictureOriginal, src => src.Original);

            // Map a Car For Sale to a View Model
            config
                .NewConfig<CarForSale, CarsForSaleIndexViewModel>()
                .Map(dest => dest, src => src.ApplicationUser)
                .Map(dest => dest, src => src.Car)
                .Map(dest => dest, src => src.Car.Engine)
                .Map(dest => dest.ThumbnailPath, src => src.Car.CarThumbnail.Path);

            config
                .NewConfig<CarForSale, CarsDetailsViewModel>()
                .Map(dest => dest, src => src.ApplicationUser)
                .Map(dest => dest, src => src.Car)
                .Map(dest => dest, src => src.Car.Engine)
                .Map(dest => dest, src => src.Car.CarPictures)
                .Map(dest => dest, src => src.Car.CarThumbnail);

            config
                .NewConfig<CarForSale, CarsEditViewModel>()
                .Map(dest => dest, src => src.ApplicationUser)
                .Map(dest => dest, src => src.Car)
                .Map(dest => dest, src => src.Car.Engine)
                .Map(dest => dest, src => src.Car.CarPictures)
                .Map(dest => dest, src => src.Car.CarThumbnail);

            config
                .NewConfig<CarForSale, CarsDeleteViewModel>()
                .Map(dest => dest, src => src.ApplicationUser)
                .Map(dest => dest, src => src.Car)
                .Map(dest => dest, src => src.Car.Engine)
                .Map(dest => dest, src => src.Car.CarPictures)
                .Map(dest => dest, src => src.Car.CarThumbnail);

            // Map a View Model to a Car For Sale
            config
                .NewConfig<CarsEditViewModel, CarForSale>()
                .Map(dest => dest.ApplicationUser, src => src)
                .Map(dest => dest.Car, src => src)
                .Map(dest => dest.Car.Engine, src => src);
        }
    }
}
