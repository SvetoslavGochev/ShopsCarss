namespace ShopsCarss.Services.Cars
{
    using ShopsCarss.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICarServices
    {
        Task AddCar(CarAddModel car);

        IEnumerable<CarListeningViewModel> All();
    }
}
