
using DesignAPI.Data;
using DesignAPI.Models.Entity;
using DesignAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;


namespace DesignAPI.Repository
{
    public class PujaRepository : IPujaRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string PujaEntityCacheKey = "PujaEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public PujaRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(PujaEntityCacheKey);
        }

        public async Task<ICollection<PujaEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(PujaEntityCacheKey, out ICollection<PujaEntity> PujaCached))
                return PujaCached;

            var PujaFromDb = await _context.Puja.OrderBy(c => c.Id).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(PujaEntityCacheKey, PujaFromDb, cacheEntryOptions);
            return PujaFromDb;
        }

        public async Task<PujaEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(PujaEntityCacheKey, out ICollection<PujaEntity> PujaCached))
            {
                var PujaEntity = PujaCached.FirstOrDefault(c => c.Id == id);
                if (PujaEntity != null)
                    return PujaEntity;
            }

            return await _context.Puja.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Puja.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(PujaEntity pujaEntity)
        {
            _context.Puja.Add(pujaEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(PujaEntity pujaEntity)
        {
            _context.Update(pujaEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var PujaEntity = await GetAsync(id);
            if (PujaEntity == null)
                return false;

            _context.Puja.Remove(PujaEntity);
            return await Save();
        }

        public ICollection<PujaEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public PujaEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Create(PujaEntity puja)
        {
            throw new NotImplementedException();
        }

        public bool Update(PujaEntity puja)
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