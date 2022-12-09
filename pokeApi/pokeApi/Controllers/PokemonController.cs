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
    
    public class PokemonController : ControllerBase // your named controller, extends/inherits from ControllerBase
    {
        private readonly DataContext _context; // private variable, which means can only be access by the class that owns it readonly means assignment can only happen in the constructor vs final in java, which can only be assigned once BUT can be used anywhere

        public PokemonController(DataContext context) // constructor that initializes a context of DataContext
        {   
            _context = context; // _ means private but is it convention?
        }

        [HttpGet] // this is the get method/handler
        
        public async Task<ActionResult<List<Pokemon>>> GetPokemon() // list is an array for objects, actionresult is the what the controller returns, task means async but not return but task<TResult> means async but return
        {
            return Ok(await _context.Pokemon.ToListAsync()); // http status code 200
        }

        [HttpGet("{weight}")] // this is the get method/handler

        public async Task<ActionResult<List<Pokemon>>> SortPokemonByWeight()
        {
            var order = _context.Pokemon
                .OrderBy(x => x.Weight);
            return Ok(await order.ToListAsync()); // http status code 200
        }
        [HttpGet("{weight}/{num}")] // this is the get method/handler

        public async Task<ActionResult<List<Pokemon>>> SortPokemonByWeight(int num)
        {

            var order = _context.Pokemon
                .OrderBy(x => x.Weight)
                .Where(x => x.Weight >= num);

            //if (Pokemons.Equals(order))
            //{
            //    order = order.OrderByDescending(x => x.Weight);
            //    return Ok(await order.ToListAsync()); // http status code 200
            //}

            return Ok(await order.ToListAsync());

        }

        [HttpGet("{heights}/heights")] // this is the get method/handler

        public async Task<ActionResult<List<Pokemon>>> SortPokemonByHeight(int num)
        {
            var order = from x in _context.Pokemon
                        orderby x.Height descending
                        select x;

            return Ok(await order.ToListAsync()); // http status code 200
        }

        [HttpPost] // this is post route
        public async Task<ActionResult<List<Pokemon>>> AddPokemon(Pokemon pokemon)
        {
            _context.Pokemon.Add(pokemon);
            await _context.SaveChangesAsync(); // async version of save changes
            return Ok(await _context.Pokemon.ToListAsync()); // async version of ToList

        }

        [HttpPut] // put route
        public async Task<ActionResult<List<Pokemon>>> UpdatePokemon(Pokemon pokemon)
        {
            var dbPokemon = await _context.Pokemon.FindAsync(pokemon.Id);
            if (dbPokemon == null)
                return BadRequest("Pokemon not found"); // Http code 500 
            dbPokemon.Name = pokemon.Name;
            await _context.SaveChangesAsync();
            return Ok(await _context.Pokemon.ToListAsync());
        }

        [HttpDelete("{id}")] // deleteroute/id, needs the id to delete
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

