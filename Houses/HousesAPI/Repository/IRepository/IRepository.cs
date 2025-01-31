﻿using HousesAPI.Models.Entity;

namespace HousesAPI.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> CreateAsync(TEntity category);
        Task<bool> UpdateAsync(TEntity category);
        Task<bool> DeleteAsync(int id);
        Task<bool> Save();
        void ClearCache();
    }
}


