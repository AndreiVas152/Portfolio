using As.Park.Services.Dto;

namespace As.Park.Services.Contracts;

public interface IVignetteService
{
    Task<int> Create(VignetteCreateDto vignetteDto);
    Task<int> Update(VignetteUpdateDto vignetteDto);
    Task<int> Delete(int id);
    Task<VignetteDto> Get(int id);
    Task<IEnumerable<VignetteDto>> GetList();
    Task<VignetteIsValidDto> GetValidity(string licensePlate);
}