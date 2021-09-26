namespace ShopsCarss.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShopsCarss.Models.Issues;
    using ShopsCarss.Services.Issues;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class IssuesController : Controller
    {
        private readonly IIssuesServices issues;

        public IssuesController(IIssuesServices issues)
        {
            this.issues = issues;
        }

        [HttpGet]
        public async Task<IActionResult> CarIssues(int CarId)
        {
            //if usaer is mehanik

            var a = await this.issues.All(CarId);

            return View(await this.issues.All(CarId));
        }

        [HttpGet]
        public async Task<IActionResult> Add(int CarId)
        {
            return this.View(CarId);

            //return this.View(new AddIssueViewModel
            //{
            //    CardId = CarId,
            //});
        }
        [HttpPost]
        //public async Task<IActionResult> Add(int CarId, string description)
        public async Task<IActionResult> Add(AddissueFormModel model)
        {
            await this.issues.Create(model);

            //return Redirect($"/Issues/CarIssues?carId={model.CarId}");
         
         return   Redirect($"{nameof(CarIssues)}?carId={model.CarId}");

        }

        [HttpGet]
        public async Task<IActionResult> Fix(FixIssueModel model)
        {
            await this.issues.Fix(model);

            return Redirect($"{nameof(CarIssues)}?carId={model.CarId}");
        } 

        [HttpGet]
        public async Task<IActionResult> Delete(FixIssueModel model)
        {
            await this.issues.Delete(model);

            return Redirect($"{nameof(CarIssues)}?carId={model.CarId}");
        }
    }
}
