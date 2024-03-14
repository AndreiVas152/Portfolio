using As.Park.Services.Dto;

namespace As.Park.Services.Contracts;

public interface ICarService
{
    Task<int> Create(CarCreateDto carDto);
    Task Update(int id, CarUpdateDto carDto);
    Task Delete(int id);
    Task<CarDto> Get(int id);
    Task<IEnumerable<CarDto>> GetList();
    Task<IEnumerable<CarDto>> Search(string search);
    Task ChangeOwner(int id, int ownerId);
    Task<IEnumerable<VignetteDto>> ListVignette(int id);
    Task<IEnumerable<FineDto>> ListFines(int id);
}