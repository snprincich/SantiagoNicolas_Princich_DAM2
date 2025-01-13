using BasicApi.Data;
using BasicApi.Models.Entity;
using BasicApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BasicApi.Repository
{
    public class CocheRepository : ICocheRepository
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string CocheEntityCacheKey = "CocheEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public CocheRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(CocheEntityCacheKey);
        }

        public async Task<ICollection<CocheEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(CocheEntityCacheKey, out ICollection<CocheEntity> CocheCached))
                return CocheCached;

            var CocheFromDb = await _context.Coche.OrderBy(c => c.Marca).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(CocheEntityCacheKey, CocheFromDb, cacheEntryOptions);
            return CocheFromDb;
        }

        public async Task<CocheEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(CocheEntityCacheKey, out ICollection<CocheEntity> CocheCached))
            {
                var CocheEntity = CocheCached.FirstOrDefault(c => c.Id == id);
                if (CocheEntity != null)
                    return CocheEntity;
            }

            return await _context.Coche.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Coche.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(CocheEntity cocheEntity)
        {
            _context.Coche.Add(cocheEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(CocheEntity cocheEntity)
        {
            _context.Update(cocheEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var CocheEntity = await GetAsync(id);
            if (CocheEntity == null)
                return false;

            _context.Coche.Remove(CocheEntity);
            return await Save();
        }

        public ICollection<CocheEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public CocheEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Create(CocheEntity coche)
        {
            throw new NotImplementedException();
        }

        public bool Update(CocheEntity coche)
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
