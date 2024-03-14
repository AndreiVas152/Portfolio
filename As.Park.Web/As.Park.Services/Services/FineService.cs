using As.Park.Model;
using As.Park.Model.Model;
using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace As.Park.Services.Services;

public class FineService : IFineService
{
    private readonly ParkDbContext _context;

    public FineService(ParkDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new fine from provided information and updates the Fine database.
    /// </summary>
    /// <param name="fineDto"> Parameters received from front end </param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">Thrown if required information was not provided or email is not valid format</exception>
    public async Task<int> Create(FineCreateDto fineDto)
    {
        //TODO Ask Alex how to do these checks. Add Ids to DTO ?

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == fineDto.UserId);
        var car = await _context.Cars.FirstOrDefaultAsync(u => u.Id == fineDto.CarId);
        var owner = await _context.Owners.FirstOrDefaultAsync(u => u.Id == fineDto.OwnerId);
           
        if (user != null && car != null && owner != null)
        {
            var fine = new Fine
            {
                UserId = user.Id,
                FineValue = fineDto.FineValue,
                CarId = car.Id,
                OwnerId = owner.Id,
                LicensePlate = fineDto.LicensePlate,
                FineDate = System.DateTime.Now,
            };
            await _context.AddAsync(fine);
            await _context.SaveChangesAsync();
            return fine.Id;
        }
        else throw new MissingFieldException($"The specified user/car/owner do not exist");
    }

    /// <summary>
    /// Takes a fineDto info, queries the Fine database based on Id provided and modifies FineValue/LastName/BirthDate and Password.
    /// </summary>
    /// <param name="fineDto"> Parameters received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException"> Thrown if provided Id is not in the database</exception>
    public async Task<int> Update(FineUpdateDto fineDto)
    {
        var fine = await _context.Fines.FirstOrDefaultAsync(e => e.Id == fineDto.Id);
        if (fine != null)
        {
            {
                fine.FineValue = fineDto.FineValue;
            }
            _context.Update(fine);
            return await _context.SaveChangesAsync();
        }
        else throw new MissingFieldException($"The queried fine does not exist");
    }

    /// <summary>
    /// Queries the Fine database for fine with provided Id and deletes the entry from the table.
    /// </summary>
    /// <param name="id"> Fine Id received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException">Thrown if provided Id is not in the database</exception>
    public async Task<int> Delete(int id)
    {
        var fine = _context.Fines.FirstOrDefault(e => e.Id == id);
        if (fine != null)
        {
            _context.Fines.Remove(fine);
            return await _context.SaveChangesAsync();
        }
        else throw new MissingFieldException($"The queried fine Id does not exist");
    }

    /// <summary>
    /// Queries the Fine database for a single fine from Id provided and returns that fine's information.
    /// </summary>
    /// <param name="id"> Fine Id received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException">Thrown if provided Id is not in the database</exception>
    public async Task<FineDto> Get(int id)
    {
        var fine = await _context.Fines.FirstOrDefaultAsync(e => e.Id == id);
        if (fine != null)
        {
            var fineDto = new FineDto()
            {
                UserId = fine.UserId,
                FineValue = fine.FineValue,
                OwnerId = fine.OwnerId,
                CarId = fine.CarId,
                LicensePlate = fine.LicensePlate
            };
            return fineDto;
        }
        else throw new MissingFieldException($"The queried fine Id does not exist");
    }

    /// <summary>
    /// Queries the Fine Database and returns a list of all fines
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<FineDto>> GetList()
    {
        List<FineDto> fines = new List<FineDto>();
        await foreach (var fine in _context.Fines)
        {
            var fineDto = new FineDto()
            {
                UserId = fine.UserId,
                FineValue = fine.FineValue,
                OwnerId = fine.OwnerId,
                CarId = fine.CarId,
                LicensePlate = fine.LicensePlate
            };
            fines.Add(fineDto);
        }
        return fines;
    }

    //public async Task<bool> Login(FineDto fineDto)
    //{
    //    throw new NotImplementedException();
    //}
}