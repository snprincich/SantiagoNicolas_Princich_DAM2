﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeRogue.Models;

namespace PokeRogue.Interface
{
    public interface IGestorAPIService
    {
        Task<HistoricPokemonDTO> CrearHistoricDTO(Pokemon pokemon, Batalla batalla);
        Task<HistoricPokemonDTO> GetPokemon();
        Task AddPokemonToApi(object pokemon);
        Task<List<HistoricPokemonDTO>> GetAllPokemons();

    }
}
