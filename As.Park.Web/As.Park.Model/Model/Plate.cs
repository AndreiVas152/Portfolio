using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Park.Model.Model
{
    public class Plate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        public Car? Car { get; set; }

        [Required]
        [MaxLength(50)]

        public string LicensePlate { get; set; } = string.Empty;
    }
}
