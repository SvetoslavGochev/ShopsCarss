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
    using System.Security.Claims;
    using System.Threading.Tasks;
    using static Data.Constants.Constants;
    using static Infrastructure.ClaimsPrincipalExtensions;

    public class UsersController : Controller
    {
        private readonly IDbServices Db;
        private readonly IUserServices user;

        public UsersController(IDbServices db, IUserServices user)
        {
            this.Db = db;
            this.user = user;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(UserLoginForm user)
        //{
        //    //if (true)//userId
        //    //{

        //    //}
        //    var a = user.Username;


        //    return RedirectToAction(nameof(CarsController.All), "Cars");
        //}
        [HttpPost]
        public async Task<IActionResult> Login(LoginForm form)
        {

            var userId = this.Db.DataBase()
                .Userss
                .Where(x => x.Username == form.Username && x.Password == form.Password)
                .Select(x => x.Id)
                .FirstOrDefault();


            var ID = this.Db.DataBase()
                .Users
                .Where(x => x.UserName == form.Username)
                .Select(x => x.Id)
                .FirstOrDefault();


            if (userId == null)
            {
                return BadRequest();
            }

         




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
            try
            {
               await this.user.Create(form);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            //var user = new User
            //{
            //    Username = form.Username,
            //    Email = form.Email,
            //    Password = form.Password,
            //    IsMechanic = form.IsMechanic
            //};

            //await this.Db.DataBase().AddAsync(user);
            //await this.Db.DataBase().SaveChangesAsync();

            TempData[GlobalMessage] = "Addet new user";

            return RedirectToAction(nameof(Login));
        }
    }
}
