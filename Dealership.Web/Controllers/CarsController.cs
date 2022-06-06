using Dealership.Data.Interfaces;
using Dealership.Data.DataModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Dealership.Entities.ViewModels.Cars;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Dealership.Web.Models
{
    public class CarsController : Controller
    {
        ICarsData db = null;
        IMapper mapper = null;

        public CarsController(ICarsData db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await db.GetAllAsync();

            var model = cars.Select(c => mapper.Map<Car, CarsIndexViewModel>(c));

            return View(model);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var car = await db.GetAsync(Id);

            var model = mapper.Map<Car, CarsDetailsViewModel>(car);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int Id)
        {
            var car = await db.GetAsync(Id);

            var model = mapper.Map<Car, CarsEditViewModel>(car);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarsEditViewModel carVm)
        {
            var car = mapper.Map<CarsEditViewModel, Car>(carVm);
            car.Engine = mapper.Map<CarsEditViewModel, Engine>(carVm);

            await db.UpdateAsync(car);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarsCreateViewModel carVm)
        {
            var car = mapper.Map<CarsCreateViewModel, Car>(carVm);
            car.Engine = mapper.Map<CarsCreateViewModel, Engine>(carVm);

            await db.AddAsync(car);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            var car = await db.GetAsync(Id);

            var model = mapper.Map<Car, CarsDeleteViewModel>(car);
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
