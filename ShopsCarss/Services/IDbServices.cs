namespace ShopsCarss.Services
{
    using ShopsCarss.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDbServices
    {
        ApplicationDbContext DataBase();
    }
}
