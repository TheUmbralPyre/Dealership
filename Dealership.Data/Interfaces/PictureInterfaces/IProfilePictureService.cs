using Dealership.Data.Models.IdentityModels;
using System.IO;

namespace Dealership.Data.Interfaces.PictureInterfaces
{
    public interface IProfilePictureService
    {
        public ProfilePicture ConvertPicture(MemoryStream picture, string webRootPath, string username);
    }
}
