using As.Park.Model;
using As.Park.Model.Model;
using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace As.Park.Services.Services;

public class CarService : ICarService
{
    private readonly ParkDbContext _context;

    public CarService(ParkDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(CarCreateDto carDto)
    {
        var owner = await _context.Owners.FirstOrDefaultAsync(e => e.Id == carDto.OwnerId);
        
        if (owner != null)
        {
            var car = new Car
            {
                OwnerName = owner.FullName,
                Make = carDto.Make,
                Model = carDto.Model,
                OwnerId = owner.Id,
                Vin = carDto.Vin
            };

            await _context.AddAsync(car);
            await _context.SaveChangesAsync();

            return car.Id;
        }
        else throw new Exception ($"Owner not found");
    }

    public async Task Update(int id, CarUpdateDto carDto)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
        if (car == null)
        {
            throw new Exception("Car not found");
        }

        _context.Entry(car).CurrentValues.SetValues(carDto);
        await _context.SaveChangesAsync();

        // var newOwner = await _context.Owners.FirstOrDefaultAsync(e => e.Id == NewOwnerId);
        // var car = await _context.Cars.FirstOrDefaultAsync(e => e.Id == carDto.Id);
        // var plate = await _context.Plates.FirstOrDefaultAsync(p => p.LicensePlate == carDto.Plate);
        // {
        //     {
        //         //TODO Figure out a clean way to modify only part of the table entry
        //         car.Make = carDto.Make;
        //         car.Model = carDto.Model;
        //     }
        //     if (newOwner != null)
        //     {
        //         car.OwnerId = newOwner.Id;
        //         car.OwnerName = newOwner.FullName;
        //     }
        //     if (plate == null)
        //     {
        //         var newplate = new PlateDto
        //         {
        //             LicensePlate = carDto.Plate,
        //             CarId = car.Id
        //         };
        //         await _context.AddAsync(newplate);
        //         var oldplate = await _context.Plates.FirstOrDefaultAsync(p => p.Id == car.PlateId);
        //     }
        // }
        // _context.Update(car);
        // return await _context.SaveChangesAsync();
    }


    public async Task Delete(int carId)
    {
        var car = _context.Cars.FirstOrDefault(e => e.Id == carId);
        if (car != null)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return;
        }

        throw new MissingFieldException($"The queried Car Id does not exist");
    }

    /// <summary>
    /// Queries the Car database for a single Car from Id provided and returns that Car's information.
    /// </summary>
    /// <param name="id"> Car Id received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException">Thrown if provided Id is not in the database</exception>
    public async Task<CarDto> Get(int id)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(e => e.Id == id);

        if (car != null)
        {
            var carDto = new CarDto()
            {                    
                Make = car.Make,
                Model = car.Model,                    
                PlateId = car.PlateId,
                Vin = car.Vin,
                OwnerId = car.OwnerId,
                OwnerName = car.OwnerName
            };
            return carDto;
        }
        else throw new MissingFieldException($"The queried Car Id does not exist");
    }


    /// <summary>
    /// Queries the Car Database and returns a list of all Cars
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<CarDto>> GetList()
    {
        List<CarDto> cars = new List<CarDto>();
        await foreach (var car in _context.Cars)
        {
            var carDto = new CarDto()
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Vin = car.Vin,
                PlateId = car.PlateId,
                OwnerName = car.OwnerName,
                OwnerId = car.OwnerId
            };
            cars.Add(carDto);
        }

        return cars;
    }

    public async Task<IEnumerable<CarDto>> Search(string search)
    {
        return await _context.Cars
            .Where(c => c.Make.Contains(search) || c.Model.Contains(search) || c.Vin.Contains(search))
            .Select(c => new CarDto
            {
                Id = c.Id,
                Vin = c.Vin,
                Make = c.Make,
                Model = c.Model,
                OwnerId = c.OwnerId,
                OwnerName = c.OwnerName,
                PlateId = c.PlateId,
            })
            .ToListAsync();
        //
        // List<CarDto> carsByMakeModel = new List<CarDto>();
        // var cars = await _context.Cars
        //     .Where(c => c.Make == make)
        //     .ToListAsync();
        //
        // if (model != string.Empty)
        // {
        //     for (int i = 0; i < cars.Count; i++)
        //     {
        //         var car = cars[i];
        //         if (car.Model != model)
        //             cars.Remove(car);
        //     }
        // }
        //
        // foreach (var car in cars)
        // {
        //     var carDto = new CarDto()
        //     {
        //         Id = car.Id,
        //         Model = car.Model,
        //         Vin = car.Vin,
        //         PlateId = car.PlateId,
        //         OwnerName = car.OwnerName,
        //         OwnerId = car.OwnerId,
        //         Make = car.Make
        //     };
        //     carsByMakeModel.Add(carDto);
        // }
        //
        // return carsByMakeModel;
    }

    public async Task ChangeOwner(int id, int ownerId)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
        if (car == null)
        {
            throw new Exception("Car not found");
        }

        car.OwnerId = ownerId;
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<VignetteDto>> ListVignette(int id)
    {
        return await _context.Vignettes
            .Where(c => c.CarId == id)
            .Select(c => new VignetteDto
            {
            Id = c.Id,
            Start = c.Start,
            Expiration = c.Expiration,
            })
            .ToListAsync();            
    }

    public async Task<IEnumerable<FineDto>> ListFines(int id)
    {
        return await _context.Fines
            .Where(c => c.CarId == id)
            .Select(c => new FineDto
            {
                Id = c.Id,
                UserId = c.UserId,
                OwnerId = c.OwnerId,
                CarId = c.CarId,
                LicensePlate = c.LicensePlate,
                FineValue = c.FineValue
            })
            .ToListAsync();
    }
}