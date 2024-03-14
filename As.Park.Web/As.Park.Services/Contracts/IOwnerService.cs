using As.Park.Services.Dto;

namespace As.Park.Services.Contracts
{
    public interface IOwnerService
    {
        Task<int> Create(OwnerCreateDto ownerDto);
        Task<int> Update(OwnerUpdateDto ownerDto);
        Task<int> Delete(int id);
        Task<OwnerDto> Get(int id);
        Task<IEnumerable<OwnerDto>> GetList();
        Task<IEnumerable<CarDto>> GetCarsList(int id);
        Task<IEnumerable<FineDto>> ListFines(int id);
    }
}
