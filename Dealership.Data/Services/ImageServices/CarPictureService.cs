using Dealership.Data.DataModels.CarModels;
using Dealership.Data.Interfaces.PictureInterfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System.Collections.Generic;
using System.IO;

namespace Dealership.Data.Services.ImageServices
{
    public class CarPictureService : ICarPicturesService
    {
        private const int thumbnailHeight = 200;

        private const int thumbnailWidth = 350;

        private const string carThumbnailsFolderName = "car-thumbnails";

        private const int slideHeight = 559;

        private const int slideWidth = 966;

        private const string carPicturesFolderName = "car-pictures";

        private const string jpegFormatExtension = ".jpeg";

        private const int jpegEncoderQuality = 75;

        public List<CarPicture> ConvertPictures(IEnumerable<MemoryStream> pictures, string webRootPath)
        {
            // Initialize a New List of Car Pictures to be Returned
            var carPictures = new List<CarPicture>();

            // For each Picutre in the Recieved Pictures...
            foreach(var picture in pictures)
            {
                // Initialize a New Car Picture
                var carPicture = new CarPicture();

                // Set the Position of the Picture Memory Stream to its Start, so that it can be Loaded
                picture.Position = 0;

                // Load the Picture
                using var imageResult = Image.Load(picture);

                // Decalre and Initialize the Pictures Save Path of the Original Picture
                var savePath = Path.Combine(webRootPath + "\\" + carPicturesFolderName, carPicture.Id.ToString() + "_Original" + jpegFormatExtension);
                // Set the Path of the Original Picture
                carPicture.OriginalPath = carPicturesFolderName + "\\" + carPicture.Id.ToString() + "_Original" + jpegFormatExtension;
                // Save the Original Picture
                imageResult.Save(savePath, new JpegEncoder
                {
                    Quality = jpegEncoderQuality
                });

                // Resize the Picture
                imageResult.Mutate(i => i.Resize(slideWidth, slideHeight));
                // Decalre and Initialize the Pictures Save Path of the Slide Picture
                savePath = Path.Combine(webRootPath + "\\" + carPicturesFolderName, carPicture.Id.ToString() + "_Slide" + jpegFormatExtension);
                // Save The Path of the Slide Picture
                carPicture.SlidePath = carPicturesFolderName + "\\" + carPicture.Id.ToString() + "_Slide" + jpegFormatExtension;
                // Save the Slide Picture
                imageResult.Save(savePath, new JpegEncoder
                {
                    Quality = jpegEncoderQuality
                });

                // Add the Car Picture into the List
                carPictures.Add(carPicture);
            }

            // Return the Car Pictures
            return carPictures;
        }

        public CarPictureThumbnail ConvertToThumbnail(MemoryStream picture, string webRootPath)
        {
            // Declare a Car Thumbnail to Return
            var carThumbnail = new CarPictureThumbnail();

            // Set the Position of the Picture Memorey Stream to its Start, so that it can be Loaded
            picture.Position = 0;

            // Load the Picture
            using var imageResult = Image.Load(picture);

            // Resize the Picture
            imageResult.Mutate(i => i.Resize(thumbnailWidth, thumbnailHeight));

            // Decalre and Initialize the Thumbnail Save Path
            var savePath = Path.Combine(webRootPath + "\\" + carThumbnailsFolderName, carThumbnail.Id.ToString() + jpegFormatExtension);

            // Save the Thumbnail 
            imageResult.Save(savePath, new JpegEncoder
            {
                Quality = jpegEncoderQuality
            });

            // Set the Path of the Thumbnail
            carThumbnail.Path = carThumbnailsFolderName + "\\" + carThumbnail.Id.ToString() + jpegFormatExtension;

            // Return the Thumbnail
            return carThumbnail;
        }
    }
}
