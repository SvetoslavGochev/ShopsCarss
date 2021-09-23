namespace ShopsCarss.Services
{
    using ShopsCarss.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DbServices : IDbServices
    {
        private readonly ApplicationDbContext data;

        public DbServices(ApplicationDbContext data)
        {
            this.data = data;
        }

        public ApplicationDbContext DataBase()
        {
          return  this.data;
        }
    }
}
