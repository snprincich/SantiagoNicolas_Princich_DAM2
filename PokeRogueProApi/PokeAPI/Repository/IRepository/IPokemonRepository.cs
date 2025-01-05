using PokeAPI.Models.Entity;

namespace PokeAPI.Repository.IRepository
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetAll();
        Pokemon GetById(int id);
        bool Create(Pokemon pokemon);
        bool Update(Pokemon pokemon);
        bool Delete(int id);
        bool DeleteAll();
    }
}
