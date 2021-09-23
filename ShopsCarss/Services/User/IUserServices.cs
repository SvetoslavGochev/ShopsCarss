namespace ShopsCarss.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IUserServices
    {

        Task<int> Create(string Username, string Email, string Password, bool IsMechanic);


    }
}
