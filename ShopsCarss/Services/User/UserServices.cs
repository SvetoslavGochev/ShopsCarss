namespace ShopsCarss.Services.User
{
    using ShopsCarss.Data;
    using ShopsCarss.Data.Models;
    using ShopsCarss.Models.UserRegisterForm;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static Data.Constants.Constants;
    public class UserServices: IUserServices
    {
        private readonly ApplicationDbContext data;

        public UserServices(ApplicationDbContext data)
        {
            this.data = data;
        }


        public async Task Create(RegisterForm form)
        {
            if (this.data.Userss.Any(u => u.Username == form.Username))
            {
                return ;
            }

            var user = new User
            {
                Username = form.Username,
                Email = form.Email,
                Password = form.Password,
                IsMechanic = form.IsMechanic == Mechanic
            };

            await this.data.Userss.AddAsync(user);
            await this.data.SaveChangesAsync();

           
        }
    }
}
