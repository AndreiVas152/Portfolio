using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Park.Services.Dto
{
    public class OwnerDto
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
    }


    public class OwnerCreateDto : OwnerDto
    {

    }
    public class OwnerUpdateDto : OwnerDto
    {

    }

    
}
