var builder = WebApplication.CreateBuilder(args);

// Configura��o dos servi�os
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura��o do pipeline de requisi��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var pokemons = new[]
{
    new Pokemon("Pikachu", "Electric"),
    new Pokemon("Charizard", "Fire/Flying"),
    new Pokemon("Bulbasaur", "Grass/Poison"),
    new Pokemon("Squirtle", "Water"),
    new Pokemon("Jigglypuff", "Normal/Fairy")
};

app.MapGet("/pokemons", () =>
{
    return pokemons;
})
.WithName("GetPokemons")
.WithOpenApi();

app.Run();

internal record Pokemon(string Name, string Type);
