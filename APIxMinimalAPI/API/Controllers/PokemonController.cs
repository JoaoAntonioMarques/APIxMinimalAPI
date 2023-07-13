using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Pikachu", "Charizard", "Bulbasaur", "Squirtle", "Jigglypuff"
        };

        private static readonly string[] Types = new[]
        {
            "Electric", "Fire/Flying", "Grass/Poison", "Water", "Normal/Fairy"
        };

        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPokemons")]
        public IEnumerable<Pokemon> Get()
        {
            var pokemons = Enumerable.Range(0, Names.Length).Select(index => new Pokemon(Names[index], Types[index]));

            return pokemons.ToArray();
        }
    }
}
