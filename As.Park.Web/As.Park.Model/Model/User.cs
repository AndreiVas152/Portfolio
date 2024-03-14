using System.ComponentModel.DataAnnotations;

namespace As.Park.Model.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; }

        public List<Fine> Fines { get; set; } = new();
    }
}