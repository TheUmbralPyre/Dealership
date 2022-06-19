using Dealership.Data.DataModels;
using Dealership.Data.DataModels.CarModels;
using Dealership.Data.DataModels.IdentityModels;
using Dealership.Data.Interfaces;
using Dealership.Data.Interfaces.PictureInterfaces;
using Dealership.Entities.ViewModels.CarsForSale;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var carsForSale = await db.GetAllAsync();

            var model = carsForSale.Select(c => mapper.Map<CarsForSaleIndexViewModel>(c));

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
            else if ((Request.Form.Files.Where(i => i.Length > maxAllowedImageSize)).Count() > 0)
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

        public async Task<IActionResult> Details(int Id)
        {
            var carForSale = await db.GetAsync(Id);

            var model = new CarsDetailsViewModel() { CarPictures = carForSale.Car.CarPictures }; //mapper.Map<CarsDetailsViewModel>(carForSale);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int Id)
        {
            var carForSale = await db.GetAsync(Id);

            var model = mapper.Map<CarsEditViewModel>(carForSale);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarsEditViewModel carVm)
        {
            var carForSale = new CarForSale();

            carForSale = carVm.Adapt(carForSale, mapper.Config);

            await db.UpdateAsync(carForSale);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            var carForSale = await db.GetAsync(Id);

            var model = mapper.Map<CarsDeleteViewModel>(carForSale);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CarsDeleteViewModel carVm)
        {
            await db.DeleteAsync(carVm.Id);
            return RedirectToAction("Index");
        }
    }
}
