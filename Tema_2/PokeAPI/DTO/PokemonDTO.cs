﻿namespace PokeAPI.DTO
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public string? PokeName { get; set; }
        public int DamageDoneTrainer { get; set; }
        public int DamageReceivedTrainer { get; set; }
        public int? DamageDonePokemon { get; set; }
        public string? PokeImagen { get; set; }
        public bool Capturado { get; set; }
        public bool Shiny { get; set; }
    }
}
