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
        public async Task<CarIssuesViewModel> All(int id)
        {
            //ako e mahenik
            //this.user.Id == 1
            var userOwnercar = this.data
                .Cars
                .Any(c => c.Id == id && c.OwnerId == 1);
            //if (!userOwnercar)
            //{
            //    return null;//gre6ka
            //}

            var carIssue =  this.data
                  .Cars
                  .Where(c => c.Id == id)
                  .Select(c => new CarIssuesViewModel
                  {
                      Id = c.Id,
                      Model = c.Model,
                      Year = c.Year,
                      Issues = c.Issues.Select(i => new IssueListenigViewModel
                      {
                          Description = i.Description,
                          IsFixed = i.IsFixed,
                          Id = i.Id
                      })
                  })
                  .FirstOrDefault();

            return carIssue;
        }

        public async Task Create(AddissueFormModel model)
        {

            await this.data.
                Issues.
                AddAsync(new Issue
                {
                    CarId = model.CarId,
                    Description = model.Description,
                    
                });

            await this.data
                .SaveChangesAsync();
        }

        public async Task Fix(FixIssueModel model)
        {
            var car = this.data
                .Cars
                .Where(c => c.Id == model.CarId && c.Issues.Any(i => i.Id == model.IssueId))
                .FirstOrDefault();


            var issue = this.data
                .Issues
                .Where(i => i.Id == model.IssueId && i.CarId == model.CarId)
                .FirstOrDefault();

            //if issue == null

            if (issue.IsFixed)
            {
                issue.IsFixed = false;
            }
            else
            {
                issue.IsFixed = true;
            }

            await this.data.SaveChangesAsync();
        }
    }
}
