using Dealership.Data.DataModels;
using Dealership.Data.DataModels.CarModels;
using Dealership.Data.DataModels.IdentityModels;
using Dealership.Data.Interfaces;
using Dealership.Data.Interfaces.PictureInterfaces;
using Dealership.Entities.ViewModels.Cars;
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

            var model = carsForSale.Select(c => mapper.Map<CarsIndexViewModel>(c));

            return View(model);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var carForSale = await db.GetAsync(Id);

            var model = mapper.Map<CarsDetailsViewModel>(carForSale);

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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CarsCreateViewModel carVm)
        {
            var car = mapper.Map<Car>(carVm);

            if (Request.Form.Files.Count > 0)
            {
                MemoryStream[] streams = new MemoryStream[Request.Form.Files.Count];

                using (var dataStream = new MemoryStream())
                {
                    for (int index = 0; index < Request.Form.Files.Count; index += 1)
                    {
                        streams[index] = new MemoryStream();
                        await Request.Form.Files[index].CopyToAsync(streams[index]);
                    }
                }

                car.CarThumbnail = carPicturesService.ConvertToThumbnail(streams[0], hostingEnviroment.WebRootPath);
                car.CarPictures = carPicturesService.ConvertPictures(streams);
            }

            car.Engine = mapper.Map<Engine>(carVm);

            var carForSale = new CarForSale()
            {
                ApplicationUser = userManager.GetUserAsync(User).Result,
                Car = car,
                DateAdded = System.DateTime.Now,
                Decription = "asa",
                Price = 100
            };

            await db.AddAsync(carForSale);

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
