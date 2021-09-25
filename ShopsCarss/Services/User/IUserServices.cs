namespace ShopsCarss.Services
{
    using ShopsCarss.Models.UserRegisterForm;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IUserServices
    {

        Task Create(RegisterForm form);


    }
}
