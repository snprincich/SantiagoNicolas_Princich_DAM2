using BasicApi.Models.Entity;

namespace BasicApi.Repository.IRepository
{
    public interface ICocheRepository : IRepository<CocheEntity>
    {
        ICollection<CocheEntity> GetAll();
        CocheEntity GetById(int id);
        bool Create(CocheEntity coche);
        bool Update(CocheEntity coche);
        bool Delete(int id);
        bool DeleteAll();
    }
}

