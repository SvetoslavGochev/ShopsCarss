namespace ShopsCarss.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ShopsCarss.Data;
    using ShopsCarss.Models;
    using ShopsCarss.Services.Cars;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarsController : Controller
    {
        private readonly ApplicationDbContext Db;
        private readonly ICarServices car;

        public CarsController(ApplicationDbContext Db, ICarServices car)
        {
            this.Db = Db;
            this.car = car;
        }
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> All()
        {
            var AllCarsUser = this.car.All();

            return this.View(AllCarsUser);
        } 

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //var userIsMechanic = this.Db
            //    .Userss
            //    .Any(u => u.Id = this.User.Identity && u.IsMechanic);

            return this.View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(CarAddModel car)
        {

           await this.car.AddCar(car);

            return RedirectToAction(nameof(All));
        }


    }
}
