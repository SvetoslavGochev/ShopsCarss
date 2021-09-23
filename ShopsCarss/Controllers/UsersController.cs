namespace ShopsCarss.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShopsCarss.Data.Constants;
    using ShopsCarss.Data.Models;
    using ShopsCarss.Models.UserRegisterForm;
    using ShopsCarss.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static Data.Constants.Constants;

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
        
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginForm user)
        {
            //if (true)//userId
            //{

            //}


            return RedirectToAction(nameof(CarsController.All), "Cars");
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterForm form)
        {


            var user = new User
            {
                Username = form.Username,
                Email = form.Email,
                Password = form.Password,
                IsMechanic = form.IsMechanic
            };

            await this.Db.DataBase().AddAsync(user);
            await this.Db.DataBase().SaveChangesAsync();

            TempData[GlobalMessage] = "Addet User";

            return RedirectToAction(nameof(Login));
        }
    }
}
