using Backend.DTO;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BeerService : ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO>
    {

        private StoreContext _storeContext;

        public BeerService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<IEnumerable<BeerDTO>> Get() =>
            await _storeContext.Beers.Select(b => new BeerDTO
            {
                Id = b.BeerId,
                Name = b.Name,
                Alcohol = b.Alcohol,
                BrandID = b.BrandId
            }).ToListAsync();

        public async Task<BeerDTO> GetById(int id)
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
