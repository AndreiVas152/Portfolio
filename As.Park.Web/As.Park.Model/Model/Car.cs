using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Park.Model.Model
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Make { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Model { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Vin { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string OwnerName { get; set; } = string.Empty;

        [Required]
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
        [Required]        
        public int PlateId { get; set; }
        public Plate? Plate { get; set; }

        public List<Vignette> Vignettes { get; set; } = new();

        public List<Fine> Fines { get; set; } = new();
    }
}
