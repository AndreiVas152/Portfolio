using As.Park.Model;
using As.Park.Model.Model;
using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace As.Park.Services.Services;

public class UserService : IUserService
{
    private readonly ParkDbContext _context;

    public UserService(ParkDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new user from provided information and updates the User database.
    /// </summary>
    /// <param name="userDto"> Parameters received from front end </param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">Thrown if required information was not provided or email is not valid format</exception>
    public async Task<int> Create(UserCreateDto userDto)
    {
            var user = new User
            {
                Email = userDto.Email, //TODO add validation
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                BirthDate = userDto.BirthDate,
                Password = userDto.Password
            };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
    }

    /// <summary>
    /// Takes a userDto info, queries the User database based on Id provided and modifies FirstName/LastName/BirthDate and Password.
    /// </summary>
    /// <param name="userDto"> Parameters received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException"> Thrown if provided Id is not in the database</exception>
    public async Task<int> Update(UserUpdateDto userDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == userDto.Id);
        if (user != null)
        {
            {
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.BirthDate = userDto.BirthDate;
                user.Password = userDto.Password;
            }
            _context.Update(user);
            return await _context.SaveChangesAsync();
        }
        else throw new MissingFieldException($"The queried user does not exist");
    }

    /// <summary>
    /// Queries the User database for user with provided Id and deletes the entry from the table.
    /// </summary>
    /// <param name="id"> User Id received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException">Thrown if provided Id is not in the database</exception>
    public async Task<int> Delete(int id)
    {
        var user = _context.Users.FirstOrDefault(e => e.Id == id);
        if (user != null)
        {
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }
        else throw new MissingFieldException($"The queried user Id does not exist");
    }

    /// <summary>
    /// Queries the User database for a single user from Id provided and returns that user's information.
    /// </summary>
    /// <param name="id"> User Id received from front end </param>
    /// <returns></returns>
    /// <exception cref="MissingFieldException">Thrown if provided Id is not in the database</exception>
    public async Task<UserDto> Get(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
        if (user != null)
        {
            var userDto = new UserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Password = user.Password,
                Email = user.Email
            };
            return userDto;
        }
        else throw new MissingFieldException($"The queried user Id does not exist");
    }

    /// <summary>
    /// Queries the User Database and returns a list of all users
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<UserDto>> GetList()
    {
        List<UserDto> users = new List<UserDto>();
        await foreach (var user in _context.Users) 
        {
            var userDto = new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Password = user.Password,
                Email = user.Email
            };
            users.Add(userDto);
        }
        return users;
    }

    public async Task<IEnumerable<FineDto>> ListFines(int id)
    {
        return await _context.Fines
            .Where(c => c.UserId == id)
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
        //public async Task<bool> Login(UserDto userDto)
        //{
        //    throw new NotImplementedException();
        //}
    }