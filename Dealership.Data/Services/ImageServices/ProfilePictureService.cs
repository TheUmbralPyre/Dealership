using Dealership.Data.Interfaces.PictureInterfaces;
using Dealership.Data.Models.IdentityModels;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System.IO;

namespace Dealership.Data.Services.ImageServices
{
    public class ProfilePictureService : IProfilePictureService
    {
        private const int manageIndexHeight = 350;

        private const int manageIndexWidth = 350;

        private const int commonHeight = 75;

        private const int commonWidth = 75;

        private const int navHeight = 38;

        private const int navWidth = 38;

        private const string profilePicturesFolderName = "profile-pictures";

        private const string jpegFormatExtension = ".jpeg";

        private const int jpegEncoderQuality = 75;

        public ProfilePicture ConvertPicture(MemoryStream picture, string webRootPath, string username)
        {
            // Initialize a New Profile Picture to be Returned
            var profilePicture = new ProfilePicture();

            // Set the Position of the Picture Memory Stream to its Start, so that it can be Loaded
            picture.Position = 0;

            // Load the Recieved Picture
            using var imageResult = Image.Load(picture);

            // Decalre and Initialize the Pictures Save Path of the Original Picture
            var savePath = Path.Combine(webRootPath + "\\" + profilePicturesFolderName, username + "_Original" + jpegFormatExtension);
            // Set the Path of the Original Picture
            profilePicture.ProfilePictureOriginalPath = profilePicturesFolderName + "\\" + username + "_Original" + jpegFormatExtension;
            // Save the Original Picture
            imageResult.Save(savePath, new JpegEncoder
            {
                Quality = jpegEncoderQuality
            });

            // Resize the the Image fit the Width and Height of an Manage Picture
            imageResult.Mutate(i => i.Resize(manageIndexWidth, manageIndexHeight));
            // Decalre and Initialize the Pictures Save Path of the Original Picture
            savePath = Path.Combine(webRootPath + "\\" + profilePicturesFolderName, username + "_Manage" + jpegFormatExtension);
            // Set the Path of the Original Picture
            profilePicture.ProfilePictureManagePath = profilePicturesFolderName + "\\" + username + "_Manage" + jpegFormatExtension;
            // Save the Original Picture
            imageResult.Save(savePath, new JpegEncoder
            {
                Quality = jpegEncoderQuality
            });

            // Resize the the Image fit the Width and Height of an Common Picture
            imageResult.Mutate(i => i.Resize(commonWidth, commonHeight));
            // Decalre and Initialize the Pictures Save Path of the Original Picture
            savePath = Path.Combine(webRootPath + "\\" + profilePicturesFolderName, username + "_Common" + jpegFormatExtension);
            // Set the Path of the Original Picture
            profilePicture.ProfilePictureCommonPath = profilePicturesFolderName + "\\" + username + "_Common" + jpegFormatExtension;
            // Save the Original Picture
            imageResult.Save(savePath, new JpegEncoder
            {
                Quality = jpegEncoderQuality
            });

            // Resize the the Image fit the Width and Height of an Navbar Picture
            imageResult.Mutate(i => i.Resize(navWidth, navHeight));
            // Decalre and Initialize the Pictures Save Path of the Original Picture
            savePath = Path.Combine(webRootPath + "\\" + profilePicturesFolderName, username + "_Navbar" + jpegFormatExtension);
            // Set the Path of the Original Picture
            profilePicture.ProfilePictureNavbarPath = profilePicturesFolderName + "\\" + username + "_Navbar" + jpegFormatExtension;
            // Save the Original Picture
            imageResult.Save(savePath, new JpegEncoder
            {
                Quality = jpegEncoderQuality
            });

            return profilePicture;
        }
    }
}
