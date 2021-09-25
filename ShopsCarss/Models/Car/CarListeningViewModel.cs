namespace ShopsCarss.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarListeningViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }

        public string Image { get; set; }

        public string PlateNumber { get; set; }

        public int FixedIssues { get; set; }
        public int RemainingIssues { get; set; }


    }
}
