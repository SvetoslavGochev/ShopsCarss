namespace ShopsCarss.Services.Issues
{
    using Microsoft.AspNetCore.Mvc;
    using ShopsCarss.Models.Issues;
    using System.Threading.Tasks;

    public interface IIssuesServices
    {
        Task<CarIssuesViewModel> All(int id);

        Task Create(AddissueFormModel model);

        Task Fix(FixIssueModel model);

        Task Delete(FixIssueModel model);
    }
}
