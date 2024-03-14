using As.Park.Model;
using As.Park.Model.Model;
using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Net;

namespace As.Park.Services.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly ParkDbContext _context;

        public OwnerService(ParkDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(OwnerCreateDto ownerDto)
        {
            var owner = new Owner
            {
                FullName = ownerDto.FullName,
                Address = ownerDto.Address,
                NationalId = ownerDto.NationalId
            };

            await _context.AddAsync(owner);
            await _context.SaveChangesAsync();
            return owner.Id;

        }

        /// <summary>
        /// Takes a OwnerDto info, queries the Owner database based on Id provided and modifies FullName/National Id/Address.
        /// </summary>
        /// <param name="OwnerDto"> Parameters received from front end </param>
        /// <returns></returns>
        /// <exception cref="MissingFieldException"> Thrown if provided Id is not in the database</exception>
        public async Task<int> Update(OwnerUpdateDto ownerDto)
        {
            var owner = await _context.Owners.FirstOrDefaultAsync(e => e.Id == ownerDto.Id);
            if (owner != null)
            {
                {
                    owner.FullName = ownerDto.FullName;
                    owner.Address = ownerDto.Address;
                    owner.NationalId = ownerDto.NationalId;
                }
                _context.Update(owner);
                return await _context.SaveChangesAsync();
            }
            else throw new MissingFieldException($"The queried Owner does not exist");
        }

        /// <summary>
        /// Queries the Owner database for Owner with provided Id and deletes the entry from the table.
        /// </summary>
        /// <param name="id"> Owner Id received from front end </param>
        /// <returns></returns>
        /// <exception cref="MissingFieldException">Thrown if provided Id is not in the database</exception>
        public async Task<int> Delete(int id)
        {
            var owner = _context.Owners.FirstOrDefault(e => e.Id == id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                return await _context.SaveChangesAsync();
            }
            else throw new MissingFieldException($"The queried Owner Id does not exist");
        }

        /// <summary>
        /// Queries the Owner database for a single Owner from Id provided and returns that Owner's information.
        /// </summary>
        /// <param name="id"> Owner Id received from front end </param>
        /// <returns></returns>
        /// <exception cref="MissingFieldException">Thrown if provided Id is not in the database</exception>
        public async Task<OwnerDto> Get(int id)
        {
            var owner = await _context.Owners.FirstOrDefaultAsync(e => e.Id == id);
            if (owner != null)
            {
                var ownerDto = new OwnerDto()
                {
                    FullName = owner.FullName,
                    Address = owner.Address,
                    NationalId = owner.NationalId
                };
                return ownerDto;
            }
            else throw new MissingFieldException($"The queried Owner Id does not exist");
        }

        /// <summary>
        /// Queries the Owner Database and returns a list of all Owners
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OwnerDto>> GetList()
        {
            return await _context.Owners
                .Select(e => new OwnerDto()
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    Address = e.Address,
                    NationalId = e.NationalId
                }).ToListAsync();
        }


        public async Task<IEnumerable<CarDto>> GetCarsList(int id)
        {

            return await _context.Cars
                .Where(c => c.OwnerId == id)
                .Select(c => new CarDto()
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    PlateId = c.PlateId,
                    OwnerId = id,
                    Vin = c.Vin
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<FineDto>> ListFines(int id)
        {
            return await _context.Fines
                .Where(c => c.OwnerId == id)
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
}
