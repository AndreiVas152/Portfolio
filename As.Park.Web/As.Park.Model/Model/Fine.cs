using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Park.Model.Model
{
    public class Fine
    {
        public int Id { get; set; }
        
        // Logic to be reviewed ... Plate relation worth having ?
        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public float FineValue { get; set; }

        [Required]
        public DateTime FineDate { get; set; }

        [Required]
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public int CarId { get; set; }
        public Car? Car { get; set; }
    }
}
