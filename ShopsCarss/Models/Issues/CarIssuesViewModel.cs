namespace ShopsCarss.Models.Issues
{
    using System.Collections.Generic;

    public class CarIssuesViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public IEnumerable<IssueListenigViewModel> Issues { get; set; }
    }
}
