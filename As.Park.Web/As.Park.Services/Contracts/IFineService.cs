using As.Park.Services.Dto;

namespace As.Park.Services.Contracts;

public interface IFineService
{
    Task<int> Create(FineCreateDto fineDto);
    Task<int> Update(FineUpdateDto fineDto);
    Task<int> Delete(int id);
    Task<FineDto> Get(int id);
    Task<IEnumerable<FineDto>> GetList();
}