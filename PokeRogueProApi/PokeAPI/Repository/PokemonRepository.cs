using PokeAPI.Data;
using PokeAPI.Models.Entity;
using PokeAPI.Repository.IRepository;

namespace PokeAPI.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ApplicationDbContext _context;

        public PokemonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Pokemon> GetAll() => _context.Pokemons.ToList();

        public Pokemon GetById(int id) => _context.Pokemons.FirstOrDefault(p => p.Id == id);

        public bool Create(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            return Save();
        }

        public bool Update(Pokemon pokemon)
        {
            _context.Pokemons.Update(pokemon);
            return Save();
        }

        public bool Delete(int id)
        {
            var pokemon = GetById(id);
            if (pokemon == null) return false;
            _context.Pokemons.Remove(pokemon);
            return Save();
        }

        public bool DeleteAll()
        {
            _context.Pokemons.RemoveRange(_context.Pokemons);
            return Save();
        }

        private bool Save() => _context.SaveChanges() > 0;
    }
}
