namespace ShopsCarss.Services.Issues
{
    using ShopsCarss.Models.Issues;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IIssuesServices
    {
        Task<CarIssuesViewModel> All(int id);

        Task Create(AddissueFormModel model);

        Task Fix(FixIssueModel model);
    }
}
