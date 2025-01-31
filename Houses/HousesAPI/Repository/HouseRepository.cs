using HousesAPI.Data;
using HousesAPI.Models.Entity;
using HousesAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace HousesAPI.Repository
{
    public class HouseRepository : IHouseRepository
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string HouseEntityCacheKey = "HouseEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public HouseRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            if (result)
            {
                ClearCache();
            }
            return result;
        }

        public void ClearCache()
        {
            _cache.Remove(HouseEntityCacheKey);
        }

        public async Task<ICollection<HouseEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(HouseEntityCacheKey, out ICollection<HouseEntity> HouseCached))
                return HouseCached;

            var HouseFromDb = await _context.House.OrderBy(c => c.Id).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(HouseEntityCacheKey, HouseFromDb, cacheEntryOptions);
            return HouseFromDb;
        }

        public async Task<HouseEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(HouseEntityCacheKey, out ICollection<HouseEntity> HouseCached))
            {
                var HouseEntity = HouseCached.FirstOrDefault(c => c.Id == id);
                if (HouseEntity != null)
                    return HouseEntity;
            }

            return await _context.House.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.House.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(HouseEntity houseEntity)
        {
            _context.House.Add(houseEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(HouseEntity houseEntity)
        {
            _context.Update(houseEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var HouseEntity = await GetAsync(id);
            if (HouseEntity == null)
                return false;

            _context.House.Remove(HouseEntity);
            return await Save();
        }

        public ICollection<HouseEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public HouseEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Create(HouseEntity house)
        {
            throw new NotImplementedException();
        }

        public bool Update(HouseEntity house)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}
