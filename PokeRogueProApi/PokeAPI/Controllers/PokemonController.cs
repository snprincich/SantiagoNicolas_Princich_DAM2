using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeAPI.Data;
using PokeAPI.Models.DTOs;
using PokeAPI.Models.DTOs.PokemonDTO;
using PokeAPI.Models.Entity;
using PokeAPI.Repository.IRepository;

namespace PokeAPI.Controllers
{
    //[Route("api/users")]
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;
        protected ResponseApi _responseApi;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _pokemonRepository = pokemonRepository;
            _responseApi = new ResponseApi();
            _mapper = mapper;
        }

        [Authorize(Roles = "admin")]
        [HttpGet(Name = "GetAllElement")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var pokemons = await _context.Pokemons.ToListAsync();
            var pokemonDtos = _mapper.Map<List<PokemonDTO>>(pokemons);
            return Ok(pokemonDtos);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOne(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null) return NotFound();

            var pokemonDto = _mapper.Map<PokemonDTO>(pokemon);
            return Ok(pokemonDto);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] PokemonDTO pokemonDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var pokemon = _mapper.Map<Pokemon>(pokemonDto);

            // Do not set pokemon.Id manually (it should be auto-generated)
            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOne), new { id = pokemon.Id }, pokemonDto);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] PokemonDTO pokemonDto, int id)
        {
            if (id != pokemonDto.Id) return BadRequest();

            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null) return NotFound();

            _mapper.Map(pokemonDto, pokemon);
            _context.Pokemons.Update(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Remove(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null) return NotFound();

            _context.Pokemons.Remove(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("deleteAll")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAll()
        {
            var pokemons = _context.Pokemons.ToList();
            if (!pokemons.Any()) return NoContent();

            _context.Pokemons.RemoveRange(pokemons);
            await _context.SaveChangesAsync();

            return Ok("Todos los pokemons han sido borrados");
        }

    }
}
