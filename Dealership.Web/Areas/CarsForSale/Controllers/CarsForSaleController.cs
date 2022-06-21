using Dealership.Data.DataModels;
using Dealership.Data.DataModels.CarModels;
using Dealership.Data.DataModels.IdentityModels;
using Dealership.Data.Interfaces;
using Dealership.Data.Interfaces.PictureInterfaces;
using Dealership.Entities.FilterClasses;
using Dealership.Entities.ViewModels.CarsForSale;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Web.Areas.CarsForSale.Controllers
{
    [Area("CarsForSale")]
    public class CarsForSaleController : Controller
    {
        private readonly ISQLData<CarForSale> db = null;
        private readonly IMapper mapper = null;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICarPicturesService carPicturesService;
        private readonly IWebHostEnvironment hostingEnviroment;

        public CarsForSaleController(ISQLData<CarForSale> db, IMapper mapper,
            UserManager<ApplicationUser> userManager, ICarPicturesService carPicturesService,
            IWebHostEnvironment hostingEnviroment)
        {
            this.db = db;
            this.mapper = mapper;
            this.userManager = userManager;
            this.carPicturesService = carPicturesService;
            this.hostingEnviroment = hostingEnviroment;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var carsForSale = await db.GetAllAsync();

            var model = carsForSale.Select(c => mapper.Map<CarsForSaleIndexViewModel>(c));

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search(SearchFilter searchFilter)
        {
            var carsForSale = await db.GetAllAsync();

            // If a Title Filter has been Entered...
            if (searchFilter.TitleFilter != null)
            {
                // ...Remove the Cars For Sale Where the Title Does Not Contain the Title Filter
                carsForSale = carsForSale.Where(cfs => cfs.Title.ToLower().Contains(searchFilter.TitleFilter.ToLower()));
            };
            // If a Color Filter has been Entered...
            if (searchFilter.ColorFilter != null)
            {
                // ...Remove the Cars For Sale Where the Color Does Not Contain the Color Filter
                carsForSale = carsForSale.Where(cfs => cfs.Car.Color.ToLower().Contains(searchFilter.ColorFilter.ToLower()));
            };
            // If a Body Type Filter has been Entered...
            if (searchFilter.BodyTypeFilter != null)
            {
                // ...Remove the Cars For Sale Where the Body Type is Not Equal to that of the Body Type Filter
                carsForSale = carsForSale.Where(cfs => (int)cfs.Car.BodyType == (int)searchFilter.BodyTypeFilter);
            };
            // If a Transmission Filter has been Entered...
            if (searchFilter.TransmissionFilter != null)
            {
                // ...Remove the Cars For Sale Where the Transmission is Not Equal to that of the Transmission Filter
                carsForSale = carsForSale.Where(cfs => (int)cfs.Car.Transmission == (int)searchFilter.TransmissionFilter);
            };
            // If a Year Minimum Filter Or a Year Maximum Filter Has been Entered...
            if (searchFilter.YearMinFilter != 0 || searchFilter.YearMaxFilter != 0)
            {
                // ...Remove the Cars For Sale Where the Year is Higher than the Year Max Filter Or Lower then the Year Min Filter
                carsForSale = carsForSale.Where(cfs => searchFilter.YearMinFilter <= cfs.Car.Year && cfs.Car.Year <= searchFilter.YearMaxFilter );
            }
            // If a Mileage Minimum Filter Or a Milage Maximum Filter Has been Entered...
            if (searchFilter.MileageMinFilter != 0 || searchFilter.MileageMaxFilter != 0)
            {
                // ...Remove the Cars For Sale Where the Mileage is Higher than the Mileage Max Filter Or Lower then the Mileage Min Filter
                carsForSale = carsForSale.Where(cfs => searchFilter.MileageMinFilter <= cfs.Car.Mileage && cfs.Car.Mileage <= searchFilter.MileageMaxFilter);
            }

            var model = carsForSale.Select(c => mapper.Map<CarsForSaleIndexViewModel>(c));

            return View(new Tuple<IEnumerable<CarsForSaleIndexViewModel>, SearchFilter>(model, searchFilter));
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(int Id)
        {
            var carForSale = await db.GetAsync(Id);

            var model = mapper.Map<CarsForSaleDetailsViewModel>(carForSale);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var model = new CarsForSaleCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CarsForSaleCreateViewModel carVm)
        {
            const int maxAllowedImageSize = 15000000;
            const int maxNumberOfImages = 15;
            const int minNumberOfImages = 1;

            // If the Request Files are More than the Maximum Number of Images...
            if (Request.Form.Files.Count > maxNumberOfImages)
            {
                ModelState.AddModelError("Uploads", $"Only {maxNumberOfImages} Pictures Can be Uploaded!");
                return View();
            }
            // If the Request Files are Less than the Minimum Number of Images...
            else if (Request.Form.Files.Count < minNumberOfImages)
            {
                ModelState.AddModelError("Uploads", $"Atleast {minNumberOfImages} Pictures is Required!");
                return View();
            }
            // If a File is Larger then the Maximum Allowed Size...
            else if ((Request.Form.Files.Where(i => i.Length > maxAllowedImageSize)).Any())
            {
                ModelState.AddModelError("Uploads", $"The Maximum File Size for an Image is {maxAllowedImageSize / 1000000} Megabytes!");
                return View();
            }

            // Initialize a Variable to Represent the Car
            var car = mapper.Map<Car>(carVm);

            // Initialize an Array of Memory Streams to be Passed as a Parameter
            MemoryStream[] pictureStreams = new MemoryStream[Request.Form.Files.Count];

            using (var dataStream = new MemoryStream())
            {
                // For each Picture...
                for (int index = 0; index < Request.Form.Files.Count; index += 1)
                {
                    // Initialize the Memory Stream at the Index
                    pictureStreams[index] = new MemoryStream();
                    // Copy the Picture Stream to the Memory Stream at the Index
                    await Request.Form.Files[index].CopyToAsync(pictureStreams[index]);
                }
            }

            // Set the Thumbnail Property of the Car to the Returned Value of the Convert To Thumbnail Method
            car.CarThumbnail = carPicturesService.ConvertToThumbnail(pictureStreams[0], hostingEnviroment.WebRootPath);
            // Set the Pictures Property of the Car to the Returned Value of the Convert To Pictures Method
            car.CarPictures = carPicturesService.ConvertPictures(pictureStreams, hostingEnviroment.WebRootPath);

            // Initialize a Variable to Represent the Engine of the  Car
            car.Engine = mapper.Map<Engine>(carVm);

            // Initialize the Car For Sale Variable to Create
            var carForSale = new CarForSale()
            {
                ApplicationUser = userManager.GetUserAsync(User).Result,
                Car = car,
                DateAdded = System.DateTime.Now
            };

            // Map the Description and Price to the Car For Sale
            carForSale = carVm.Adapt(carForSale, mapper.Config);

            await db.AddAsync(carForSale);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int Id)
        {
            var carForSale = await db.GetAsync(Id);

            var model = mapper.Map<CarsForSaleEditViewModel>(carForSale);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(CarsForSaleEditViewModel carVm)
        {
            var originalCarForSale = await db.GetAsync(carVm.Id);

            var carForSale = new CarForSale();

            carForSale = carVm.Adapt(carForSale, mapper.Config);

            const int maxAllowedImageSize = 15000000;
            const int maxNumberOfImages = 15;

            // If new Pictures have been Submited...
            if (Request.Form.Files.Count > 0)
            {
                // If the Request Files are More than the Maximum Number of Images...
                if (Request.Form.Files.Count > maxNumberOfImages)
                {
                    ModelState.AddModelError("Uploads", $"Only {maxNumberOfImages} Pictures Can be Uploaded!");
                    return View();
                }
                // If a File is Larger then the Maximum Allowed Size...
                else if ((Request.Form.Files.Where(i => i.Length > maxAllowedImageSize)).Any())
                {
                    ModelState.AddModelError("Uploads", $"The Maximum File Size for an Image is {maxAllowedImageSize / 1000000} Megabytes!");
                    return View();
                }

                // Initialize an Array of Memory Streams to be Passed as a Parameter
                MemoryStream[] pictureStreams = new MemoryStream[Request.Form.Files.Count];

                using (var dataStream = new MemoryStream())
                {
                    // For each Picture...
                    for (int index = 0; index < Request.Form.Files.Count; index += 1)
                    {
                        // Initialize the Memory Stream at the Index
                        pictureStreams[index] = new MemoryStream();
                        // Copy the Picture Stream to the Memory Stream at the Index
                        await Request.Form.Files[index].CopyToAsync(pictureStreams[index]);
                    }
                }

                // Set the Thumbnail Property of the Car to the Returned Value of the Convert To Thumbnail Method
                carForSale.Car.CarThumbnail = carPicturesService.ConvertToThumbnail(pictureStreams[0], hostingEnviroment.WebRootPath);
                // Set the Pictures Property of the Car to the Returned Value of the Convert To Pictures Method
                carForSale.Car.CarPictures = carPicturesService.ConvertPictures(pictureStreams, hostingEnviroment.WebRootPath);
            }

            await db.UpdateAsync(carForSale);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            var carForSale = await db.GetAsync(Id);

            var model = mapper.Map<CarsForSaleDeleteViewModel>(carForSale);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(CarsForSaleDeleteViewModel carVm)
        {
            await db.DeleteAsync(carVm.Id);
            return RedirectToAction("Index");
        }
    }
}
