using Backend.DTO;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BeerService : ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO>
    {

        private StoreContext _storeContext;
        private IRepository<Beer> _beerRepository;

        public BeerService(StoreContext storeContext,
                           IRepository<Beer> beerRepository)
        {
            _storeContext = storeContext;
            _beerRepository = beerRepository;
        }

        public async Task<IEnumerable<BeerDTO>> Get()
        {
            var beers = await _beerRepository.Get();

            return beers.Select(b => new BeerDTO()
            {
                Id = b.BeerId,
                Name = b.Name,
                BrandID = b.BrandId,
                Alcohol = b.Alcohol
            });
        }

        public async Task<BeerDTO> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                var beerDto = new BeerDTO
                {
                    Id = beer.BeerId,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandId
                };

                return beerDto;

            }

            return null;
        }

        public async Task<BeerDTO> Add(BeerInsertDTO beerInsertDto)
        {
            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                BrandId = beerInsertDto.BrandID,
                Alcohol = beerInsertDto.Alcohol
            };

            await _storeContext.Beers.AddAsync(beer);
            await _storeContext.SaveChangesAsync();

            var beerDto = new BeerDTO
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandId
            };

            return beerDto;
        }

        public async Task<BeerDTO> Update(int id, BeerUpdateDTO beerUpdateDto)
        {
            var beer = await _storeContext.Beers.FindAsync(id);

            if (beer != null)
            {
                beer.Name = beerUpdateDto.Name;
                beer.Alcohol = beerUpdateDto.Alcohol;
                beer.BrandId = beerUpdateDto.BrandID;

                await _storeContext.SaveChangesAsync();

                var beerDto = new BeerDTO
                {
                    Id = beer.BeerId,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandId
                };

                return beerDto;

            }

            return null;
        }

        public async Task<BeerDTO> Delete(int id)
        {
            var beer = await _storeContext.Beers.FindAsync(id);

            if (beer != null)
            {
                var beerDto = new BeerDTO
                {
                    Id = beer.BeerId,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandId
                };

                _storeContext.Remove(beer);
                await _storeContext.SaveChangesAsync();

                return beerDto;

            }

            return null;

        }


    }
}
