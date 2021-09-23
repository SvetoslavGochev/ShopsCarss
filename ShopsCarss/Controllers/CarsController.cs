namespace ShopsCarss.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShopsCarss.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarsController : Controller
    {
        private readonly ApplicationDbContext Db;

        public CarsController(ApplicationDbContext Db)
        {
            this.Db = Db;

        }
        public async Task<IActionResult> All()
        {


            return this.View(this.Db.Cars.ToList());
        }
    }
}
