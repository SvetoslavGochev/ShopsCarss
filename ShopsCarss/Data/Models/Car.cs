namespace ShopsCarss.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ShopsCarss.Infrastructure.DataConstant;
    using System.Threading.Tasks;

    public class Car
    {
  

        public int Id { get; init; }
        //public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Model { get; set; }

        //[Required] ne slagame  to e required po defoult ako e int? togava
        [Range(1900,2200)]
        public int Year { get; set; }


        public string PictureUrl { get; set; }

        public string PlateNumber { get; set; }


        [Required]
        public int OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();

    }
}
