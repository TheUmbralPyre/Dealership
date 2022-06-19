using Dealership.Data.Interfaces;
using Dealership.Data.DataModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Dealership.Entities.ViewModels.CarsForSale;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Dealership.Data.DataModels.IdentityModels;
using MapsterMapper;
using Mapster;
using Dealership.Data.DataModels.CarModels;

namespace Dealership.Web.Models
{
    public class CarsController : Controller
    {
        private readonly ISQLData<CarForSale> db = null;
        private readonly IMapper mapper = null;
        private readonly UserManager<ApplicationUser> userManager;

        public CarsController(ISQLData<CarForSale> db, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var carForSales = await db.GetAllAsync();

            var model = carForSales.Select(c => mapper.Map<CarsForSaleIndexViewModel>(c));

            return View(model);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var carForSale = await db.GetAsync(Id);

            var model = mapper.Map<CarsForSaleDetailsViewModel>(carForSale);

            return View(model);
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
        public async Task<IActionResult> Edit(CarsForSaleEditViewModel carVm)
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
        public async Task<IActionResult> Create(CarsForSaleCreateViewModel carVm)
        {
            var car = mapper.Map<Car>(carVm);
            car.Engine = mapper.Map<Engine>(carVm);

            var carForSale = new CarForSale()
            {
                ApplicationUser = userManager.GetUserAsync(User).Result,
                Car = car,
                DateAdded = System.DateTime.Now,
                Description = " "
            };

            await db.AddAsync(carForSale);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            var carForSale = await db.GetAsync(Id);

            var model = mapper.Map<CarsForSakeDeleteViewModel>(carForSale);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CarsForSakeDeleteViewModel carVm)
        {
            await db.DeleteAsync(carVm.Id);
            return RedirectToAction("Index");
        }
    }
}
