namespace ShopsCarss.Services.User
{
    using ShopsCarss.Data;
    using ShopsCarss.Data.Models;
    using ShopsCarss.Models.UserRegisterForm;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserServices: IUserServices
    {
        private readonly ApplicationDbContext data;

        public UserServices(ApplicationDbContext data)
        {
            this.data = data;
        }


        public async Task<int> Create(string Username, string Email, string Password, bool IsMechanic)
        {
            var user = new User
            {
                Username = Username,
                Email = Email,
                Password = Password,
                IsMechanic = IsMechanic
            };

            await this.data.AddAsync(user);
            await this.data.SaveChangesAsync();

            return user.Id;
        }
    }
}
