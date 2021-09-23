namespace ShopsCarss.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ShopsCarss.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Userss { get; init; }
        public DbSet<Car> Cars { get; init; }
        public DbSet<Issue> Issues { get; init; }

    }
}
