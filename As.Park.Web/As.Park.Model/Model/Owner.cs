using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Park.Model.Model
{
    // TODO Add phone number ? Email address for owners ?
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;


        [Required]
        [MaxLength(50)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string NationalId { get; set; } = string.Empty;
        
        
        public List<Car> Cars { get; set; } = new();

        public List<Fine> Fines { get; set; } = new();

    }
}
