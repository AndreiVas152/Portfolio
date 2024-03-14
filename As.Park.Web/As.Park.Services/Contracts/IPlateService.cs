using As.Park.Services.Dto;

namespace As.Park.Services.Contracts;

public interface IPlateService
{
    Task<int> Create(PlateCreateDto plateDto);
    Task<int> Update(PlateUpdateDto plateDto);
    Task<int> Delete(int id);
    Task<PlateDto> Get(int id);
    Task<IEnumerable<PlateDto>> GetList();
    Task<int> ChangeCar(int id, int carId);
}