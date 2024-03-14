using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Park.Model.Model
{
    public class Vignette
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime Expiration { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public Car? Car { get; set; }
    }
}
