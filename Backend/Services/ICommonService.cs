using Backend.DTO;

namespace Backend.Services
{
    public interface ICommonService<T, TI, TU>
    {
        Task<IEnumerable<T>> Get();
        Task<BeerDTO> GetById(int id);
        Task<BeerDTO> Add(TI beerInsertDto);
        Task<BeerDTO> Update(int id, TU beerUpdateDto);
        Task<BeerDTO> Delete(int id);
    }
}
