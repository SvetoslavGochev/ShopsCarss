namespace ShopsCarss.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShopsCarss.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersController : Controller
    {
        private readonly IDbServices Db;

        public UsersController(IDbServices db)
        {
            this.Db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
    }
}
