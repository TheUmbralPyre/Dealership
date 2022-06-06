using AutoMapper;
using Dealership.Data.DataModels.IdentityModels;
using Dealership.Data.Models.IdentityModels;

namespace Dealership.Entities.Profiles
{
    public class ApplicationUsersProfile : Profile
    {
        public ApplicationUsersProfile()
        {
            CreateMap<ProfilePicture, ApplicationUser>()
            .ForMember(a => a.ProfilePictureOriginal, opt => opt.MapFrom(p => p.Original))
            .ForMember(a => a.ProfilePictureIndex, opt => opt.MapFrom(p => p.AccountIndex))
            .ForMember(a => a.ProfilePictureNav, opt => opt.MapFrom(p => p.Nav));
            //.ForMember(a => a.ProfilePictureComment, opt => opt.MapFrom(p => p.Comment));
        }
    }
}
