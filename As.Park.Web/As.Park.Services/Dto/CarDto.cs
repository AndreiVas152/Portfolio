using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Park.Services.Dto;

public class CarDto
{
    public int Id { get; set; }
    public int OwnerId { get; set; }

    public string OwnerName { get; set; } = string.Empty;

    public int PlateId { get; set; }

    [MaxLength(50)]
    public string Make { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Model { get; set; } = string.Empty;


    public string Vin { get; set; } = string.Empty;
}

public class CarCreateDto
{
    [Required]
    [MaxLength(50)]
    public string Make { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Model { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]

    public string Plate { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Vin { get; set; } = string.Empty;

    [Required]
    public int OwnerId { get; set; }
}

public class CarUpdateDto
{
    [MaxLength(50)]
    public string Make { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Model { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Vin { get; set; } = string.Empty;
}