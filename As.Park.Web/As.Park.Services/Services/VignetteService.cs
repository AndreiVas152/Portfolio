using As.Park.Model;
using As.Park.Model.Model;
using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace As.Park.Services.Services;

public class VignetteService : IVignetteService
{
    private readonly ParkDbContext _context;

    public VignetteService(ParkDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new vig from provided information and updates the Vig database.
    /// </summary>
    /// <param name="vigDto"> Parameters received from front end </param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">Thrown if required information was not provided or email is not valid format</exception>
    public async Task<int> Create(VignetteCreateDto vignetteDto)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == vignetteDto.CarId);
        if (car != null)
        {
            var vignette = new Vignette
            {
                Start = vignetteDto.Start,
                Expiration = vignetteDto.Expiration,
                CarId = car.Id
            };

            await _context.AddAsync(vignette);
            await _context.SaveChangesAsync();
            return vignette.Id;
        }
        else throw new Exception($"Car not found");
    }

    /// <summary>
    /// Takes a vigDto info, queries the Vig database based on Id provided and modifies Start/Expiration/BirthDate and Plate.
    /// </summary>
    /// <param name="vigDto"> Parameters received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException"> Thrown if provided Id is not in the database</exception>
    public async Task<int> Update(VignetteUpdateDto vignetteDto)
    {
        var vignette = await _context.Vignettes.FirstOrDefaultAsync(e => e.Id == vignetteDto.Id);
        if (vignette != null)
        {
            {
                vignette.Start = vignetteDto.Start;
                vignette.Expiration = vignetteDto.Expiration;
            }
            _context.Update(vignette);
            return await _context.SaveChangesAsync();
        }
        else throw new MissingFieldException($"The queried vig does not exist");
    }

    /// <summary>
    /// Queries the Vig database for vig with provided Id and deletes the entry from the table.
    /// </summary>
    /// <param name="id"> Vig Id received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException">Thrown if provided Id is not in the database</exception>
    public async Task<int> Delete(int id)
    {
        var vignette = _context.Vignettes.FirstOrDefault(e => e.Id == id);
        if (vignette != null)
        {
            _context.Vignettes.Remove(vignette);
            return await _context.SaveChangesAsync();
        }
        else throw new MissingFieldException($"The queried vig Id does not exist");
    }

    /// <summary>
    /// Queries the Vig database for a single vig from Id provided and returns that vig's information.
    /// </summary>
    /// <param name="id"> Vig Id received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException">Thrown if provided Id is not in the database</exception>
    public async Task<VignetteDto> Get(int id)
    {
        var vignette = await _context.Vignettes.FirstOrDefaultAsync(e => e.Id == id);
        if (vignette != null)
        {
            var vignetteDto = new VignetteDto()
            {
                Start = vignette.Start,
                Expiration = vignette.Expiration,
            };
            return vignetteDto;
        }
        else throw new MissingFieldException($"The queried vig Id does not exist");
    }

    /// <summary>
    /// Queries the Vig Database and returns a list of all vigs
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<VignetteDto>> GetList()
    {
        List<VignetteDto> vignettes = new List<VignetteDto>();
        await foreach (var vignette in _context.Vignettes)
        {
            var vignetteDto = new VignetteDto()
            {
                Id = vignette.Id,
                Start = vignette.Start,
                Expiration = vignette.Expiration,
            };
            vignettes.Add(vignetteDto);
        }
        return vignettes;
    }

    public async Task<VignetteIsValidDto> GetValidity(string licensePlate)
    {
        var plate = await _context.Plates.FirstOrDefaultAsync(c => c.LicensePlate == licensePlate);
        if (plate != null)
        {
            var car = await _context.Cars.Include(c => c.Vignettes).FirstOrDefaultAsync(c => c.Id == plate.CarId);
            if (car != null) 
            {
                var owner = await _context.Owners.FirstOrDefaultAsync(c => c.Id == car.OwnerId);

                var vignette = car.Vignettes[car.Vignettes.Count - 1];
                var vignetteDto = new VignetteIsValidDto()
                {
                    Id = vignette.Id,
                    IsValid = true,
                    Expiration = vignette.Expiration.ToUniversalTime(),
                    OwnerId = owner.Id,
                    CarId = car.Id
                };

                if (System.DateTime.Now.ToUniversalTime() < vignetteDto.Expiration)
                {
                    return vignetteDto;
                }
                else
                {
                    vignetteDto.IsValid = false;
                    return vignetteDto;
                }
            }
            else throw new Exception($"Car not found");
        }
        else throw new Exception($"Plate not found");
        
    }

    //public async Task<DateTime> GetDateTime()
    //{
    //    using (var client = new HttpClient()) 
    //    {
    //        var response = await client.GetAsync("http://worldtimeapi.org/api/ip");
    //        if (response.IsSuccessStatusCode)
    //        {
    //            var result = await response.Content.ReadAsStringAsync();
    //            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
    //            DateTime onlineDateTime = data.datetime;
    //            return onlineDateTime;
    //        }
    //        else throw new Exception($"Failed to retrieve current time");
    //    }
        
        
    //}
        //public async Task<bool> Login(VigDto vigDto)
    //{
    //    throw new NotImplementedException();
    //}
}