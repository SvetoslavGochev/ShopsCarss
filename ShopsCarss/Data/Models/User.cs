using ShopsCarss.Infrastructure;

namespace ShopsCarss.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using static DataConstant;

    public class User
    {
        [Required]
        public int Id { get; init; }

        [Required]
        public string Username { get; set; }

        [Required]
        // [MinLength(min)] // ne e za bazata
        [MaxLength(max)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsMechanic { get; set; }
    }
}
