using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Park.Services.Dto
{
    public class PlateDto 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        public int CarId { get; set; }
    }

    public class PlateCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        public int CarId { get; set; }
    }

    public class PlateUpdateDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; } = string.Empty;

    }
}
