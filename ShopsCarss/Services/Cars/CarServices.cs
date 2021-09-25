namespace ShopsCarss.Services.Cars
{
    using ShopsCarss.Data;
    using ShopsCarss.Data.Models;
    using ShopsCarss.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarServices : ICarServices
    {
        private readonly ApplicationDbContext data;

        public CarServices(ApplicationDbContext data)
        {
            this.data = data;
        }


        public async Task AddCar(CarAddModel car)
        {
            var newCar = new Car
            {
                Model = car.Model,
                PictureUrl = car.Image,
                PlateNumber = car.PlateNumber,
                Year = car.Year,
                OwnerId = 1
            };

            await SaveCar(newCar);

        }

        public  IEnumerable<CarListeningViewModel> All()
        {
              var calModel =   this.data
                .Cars
                .Where(c => c.OwnerId == 1)
                //this. User.Id
                .Select(c => new CarListeningViewModel
                {
                    Id = c.Id,
                    PlateNumber = c.PlateNumber,
                    Image = c.PictureUrl,
                    Model = c.Model,
                    Year = c.Year,
                    FixedIssues = c.Issues.Count(i => i.IsFixed),
                    RemainingIssues = c.Issues.Where(c => !c.IsFixed).Count()
                })
                .ToList();
            return calModel;
        }

        private async Task SaveCar(Car car)
        {
            await this.data.Cars.AddAsync(car);
            await this.data.SaveChangesAsync();

        }
    }
}
