using Dealership.Data.Interfaces;
using Dealership.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dealership.Web.Models
{
    public class CarsController : Controller
    {
        ICarsData db = null;

        public CarsController(ICarsData db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var model = await db.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var model = await db.GetAsync(Id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var model = await db.GetAsync(Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Car car)
        {
            await db.UpdateAsync(car);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            await db.AddAsync(car);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var model = await db.GetAsync(Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Car car)
        {
            await db.DeleteAsync(car.Id);
            return RedirectToAction("Index");
        }
    }
}
