using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Park.Services.Dto
{
    public class FineDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public int OwnerId { get; set; }
        [Required]
        [MaxLength(50)]
        public int CarId { get; set; }
        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public float FineValue { get; set; }
    }

    public class FineCreateDto
    {
        [Required]
        [MaxLength(50)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public int OwnerId { get; set; }
        [Required]
        [MaxLength(50)]
        public int CarId { get; set; }
        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public float FineValue { get; set; }
    }

    public class FineUpdateDto 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public float FineValue { get; set; }

    }
}
