using Dealership.Data.Interfaces;
using Dealership.Data.Models.IdentityModels;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using System.IO;

namespace Dealership.Data.Services.ImageServices
{
    public class ProfilePictureService : IPictureService<ProfilePicture>
    {
        public ProfilePicture ConvertPicture(byte[] picture)
        {
            var profilePicture = new ProfilePicture();
            IImageFormat format;
            var image = Image.Load(picture, out format);
            var memoryStream = new MemoryStream();

            // Original Profile Pictyre
            profilePicture.Original = picture;

            // Account Index Picture
            image.Mutate(i => i.Resize(350, 350));
            image.Save(memoryStream, format);
            profilePicture.AccountIndex = memoryStream.ToArray();

            // Empty the Memorey Strean
            memoryStream = new MemoryStream();

            // Nav Picture
            image.Mutate(i => i.Resize(38, 38));
            image.Save(memoryStream, format);
            profilePicture.Nav = memoryStream.ToArray();


            return profilePicture;
        }
    }
}
