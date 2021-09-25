namespace ShopsCarss.Services.Issues
{
    using ShopsCarss.Data;
    using ShopsCarss.Data.Models;
    using ShopsCarss.Models.Issues;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class IssuesServices : IIssuesServices
    {
        private readonly ApplicationDbContext data;

        public IssuesServices(ApplicationDbContext data)
        {
            this.data = data;
        }
        public CarIssuesViewModel All(int Id)
        {
            //ako e mahenik
            //this.user.Id == 1
            var userOwnercar = this.data
                .Cars
                .Any(c => c.Id == Id && c.OwnerId == 1);
            //if (!userOwnercar)
            //{
            //    return null;//gre6ka
            //}

            var carIssue = this.data
                  .Cars
                  .Where(c => c.Id == Id)
                  .Select(c => new CarIssuesViewModel
                  {
                      Id = c.Id,
                      Model = c.Model,
                      Year = c.Year,
                      Issues = c.Issues.Select(i => new IssueListenigViewModel
                      {
                          Description = i.Description,
                          IsFixed = i.IsFixed,
                          IssueId = i.Id
                      })
                  })
                  .FirstOrDefault();

            return carIssue;
        }

        public async Task Create(AddissueFormModel model)
        {
            var issue = new Issue
            {
                CarId = model.CarId,
                Description = model.Description,
                IsFixed = true
            };

            await this.data.
                Issues.AddAsync(issue);
            await this.data
                .SaveChangesAsync();
        }
    }
}
