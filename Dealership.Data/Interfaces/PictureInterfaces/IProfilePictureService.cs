using Dealership.Data.Models.IdentityModels;

namespace Dealership.Data.Interfaces.PictureInterfaces
{
    public interface IProfilePictureService
    {
        public ProfilePicture ConvertPicture(byte[] picture);
    }
}
