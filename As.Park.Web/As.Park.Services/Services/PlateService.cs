using As.Park.Model;
using As.Park.Model.Model;
using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace As.Park.Services.Services;

public class PlateService : IPlateService
{
    private readonly ParkDbContext _context;

    public PlateService(ParkDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new plate from provided information and updates the Plate database. 
    /// </summary>
    /// <param name="plateDto"> Parameters received from front end </param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">Thrown if required information was not provided or email is not valid format</exception>
    public async Task<int> Create(PlateCreateDto plateDto)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == plateDto.CarId);
        if (car != null)
        {
            var plate = new Plate
            {                
                LicensePlate = plateDto.LicensePlate,
                CarId = plateDto.CarId,               
            };
            
            await _context.AddAsync(plate);            
            await _context.SaveChangesAsync();
            car.PlateId = plate.Id;
            _context.Update(car);
            await _context.SaveChangesAsync();
            return plate.Id;
        }
        else throw new InvalidOperationException($"Car not found");
    }

    /// <summary>
    /// Takes a plateDto info, queries the Plate database based on Id provided and modifies LicensePlate/CarId/BirthDate and Password.
    /// </summary>
    /// <param name="plateDto"> Parameters received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException"> Thrown if provided Id is not in the database</exception>
    public async Task<int> Update(PlateUpdateDto plateDto)
    {
        var plate = await _context.Plates.FirstOrDefaultAsync(e => e.Id == plateDto.Id);
        if (plate != null)
        {
            {               
                plate.LicensePlate = plateDto.LicensePlate;                
            }
            _context.Update(plate);
            return await _context.SaveChangesAsync();
        }
        else throw new MissingFieldException($"The queried plate does not exist");
    }

    public async Task<int> ChangeCar(int id, int carId)
    {
        var plate = await _context.Plates.FirstOrDefaultAsync(e => e.Id == id);
        if (plate == null)
        {
            throw new Exception($"Plate not found");
        }
        plate.CarId = carId;
        _context.Update(plate);
        return await _context.SaveChangesAsync();        
    }
    /// <summary>
    /// Queries the Plate database for plate with provided Id and deletes the entry from the table.
    /// </summary>
    /// <param name="id"> Plate Id received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException">Thrown if provided Id is not in the database</exception>
    public async Task<int> Delete(int id)
    {
        var plate = _context.Plates.FirstOrDefault(e => e.Id == id);
        if (plate != null)
        {
            _context.Plates.Remove(plate);
            return await _context.SaveChangesAsync();
        }
        else throw new MissingFieldException($"The queried plate Id does not exist");
    }

    /// <summary>
    /// Queries the Plate database for a single plate from Id provided and returns that plate's information.
    /// </summary>
    /// <param name="id"> Plate Id received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException">Thrown if provided Id is not in the database</exception>
    public async Task<PlateDto> Get(int id)
    {
        var plate = await _context.Plates.FirstOrDefaultAsync(e => e.Id == id);
        if (plate != null)
        {
            var plateDto = new PlateDto()
            {
                LicensePlate = plate.LicensePlate,
                CarId = plate.CarId,                
            };
            return plateDto;
        }
        else throw new MissingFieldException($"The queried plate Id does not exist");
    }

    /// <summary>
    /// Queries the Plate Database and returns a list of all plates
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<PlateDto>> GetList()
    {
        List<PlateDto> plates = new List<PlateDto>();
        await foreach (var plate in _context.Plates)
        {
            var plateDto = new PlateDto()
            {
                Id = plate.Id,
                LicensePlate = plate.LicensePlate,
                CarId = plate.CarId,                
            };
            plates.Add(plateDto);
        }
        return plates;
    }

    //public async Task<bool> Login(PlateDto plateDto)
    //{
    //    throw new NotImplementedException();
    //}
}