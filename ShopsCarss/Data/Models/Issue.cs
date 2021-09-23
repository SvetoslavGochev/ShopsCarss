using ShopsCarss.Infrastructure;

namespace ShopsCarss.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using static DataConstant;
    public class Issue
    {
        [Required]
        public int Id { get; set; }
        //public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
       // [MinLength(min)] // ne e za bazata
        [MaxLength(max)]
        public string Description { get; set; }


        public bool IsFixed { get; set; }

        [Required]
        public int CarId { get; set; }

        public Car Car { get; set; }

    }
}
