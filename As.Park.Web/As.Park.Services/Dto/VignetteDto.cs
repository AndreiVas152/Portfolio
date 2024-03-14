using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Park.Services.Dto
{
    public class VignetteDto
    {
        [Key]
        public int Id { get; set; }
        [Required]        
        public DateTime Start { get; set; }
        [Required]
        public DateTime Expiration { get; set; }
        
    }

    public class VignetteUpdateDto  
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime Expiration { get; set; }
        
    }

    public class VignetteCreateDto
    {        
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime Expiration { get; set; }
        [Required]
        public int CarId { get; set; }
    }

    public class VignetteIsValidDto 
    {
        [Key]
        public int Id { get; set; }

        public bool IsValid { get; set; }

        public DateTime Expiration { get; set; }

        public int OwnerId { get; set; }

        public int CarId { get; set; }
    }
}
