using HousesAPI.Models.Entity;

namespace HousesAPI.Repository.IRepository
{
    public interface IHouseRepository : IRepository<HouseEntity>
    {
        ICollection<HouseEntity> GetAll();
        HouseEntity GetById(int id);
        bool Create(HouseEntity house);
        bool Update(HouseEntity house);
        bool Delete(int id);
        bool DeleteAll();
    }
}

