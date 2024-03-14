using As.Park.Services.Dto;

namespace As.Park.Services.Contracts;

public interface IUserService
{
    Task<int> Create(UserCreateDto userDto);
    Task<int> Update(UserUpdateDto userDto);
    Task<int> Delete(int id);
    Task<UserDto> Get(int id);
    Task<IEnumerable<UserDto>> GetList();
    Task<IEnumerable<FineDto>> ListFines(int id);
}