using Backend.DTO;

namespace Backend.Services
{
    public interface ICommonService<T, TI, TU>
    {
        public List<string> Errors { get; }
        Task<IEnumerable<T>> Get();
        Task<BeerDTO> GetById(int id);
        Task<BeerDTO> Add(TI beerInsertDto);
        Task<BeerDTO> Update(int id, TU beerUpdateDto);
        Task<BeerDTO> Delete(int id);
        bool Validate(TI dto);
        bool Validate(TU dto);
    }
}
