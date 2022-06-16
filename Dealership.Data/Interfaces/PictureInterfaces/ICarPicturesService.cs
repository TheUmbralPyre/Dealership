using Dealership.Data.DataModels.CarModels;
using System.Collections.Generic;
using System.IO;

namespace Dealership.Data.Interfaces.PictureInterfaces
{
    public interface ICarPicturesService
    {
        public IEnumerable<CarPicture> ConvertPictures(IEnumerable<MemoryStream> pictures);

        public CarPictureThumbnail ConvertToThumbnail(MemoryStream picture, string webRootPath);
    }
}
