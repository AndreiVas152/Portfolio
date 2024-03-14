using System.ComponentModel.DataAnnotations;

namespace As.Park.Services.Dto;

public class UserDto : UserCreateDto
{
    
}

public class UserCreateDto : UserUpdateDto
{
    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}

public class UserUpdateDto
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Password { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateTime? BirthDate { get; set; }
}