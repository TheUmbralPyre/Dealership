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

        private const string jpegFormatExtension = ".jpeg";

        private const int jpegEncoderQuality = 75;

        public IEnumerable<CarPicture> ConvertPictures(IEnumerable<MemoryStream> pictures)
        {
            var carPictures = new List<CarPicture>();

            //foreach(var picture in pictures){

                //var carPicture = new CarPicture();

                //picture.Position = 0;

                //using var imageResult = Image.Load(picture);

                //imageResult.SaveAsJpeg("Original_" + carPicture.Id);

                //carPicture.Original = "/pictures/" + "Original_" + carPicture.Id + ".jpeg";

                //imageResult.Mutate(i => i.Resize(250, 310));

                //imageResult.SaveAsJpeg("Slide_" + carPicture.Id, new JpegEncoder
                //{
                    //Quality = 75
                //});

                //carPicture.Slide = "/pictures/" + "Slide_" + carPicture.Id + ".jpeg";

                //carPictures.Add(carPicture);
            //}

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
