using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pokeApi.Data;

namespace pokeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly DataContext _context;

        public PokemonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> GetPokemon()
        {
            return Ok(await _context.Pokemon.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Pokemon>>> AddPokemon(Pokemon pokemon)
        {
            _context.Pokemon.Add(pokemon);
            await _context.SaveChangesAsync();
            return Ok(await _context.Pokemon.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<Pokemon>>> UpdatePokemon(Pokemon pokemon)
        {
            var dbPokemon = await _context.Pokemon.FindAsync(pokemon.Id);
            if (dbPokemon == null)
                return BadRequest("Pokemon not found");
            dbPokemon.Name = pokemon.Name;
            await _context.SaveChangesAsync();
            return Ok(await _context.Pokemon.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Pokemon>>> DeletePokemon(int id)
        {
            var dbPokemon = await _context.Pokemon.FindAsync(id);
            if (dbPokemon == null)
                return BadRequest("Hero not found");

            _context.Pokemon.Remove(dbPokemon);
            await _context.SaveChangesAsync();
            return Ok(await _context.Pokemon.ToListAsync());
        }
    }
}

