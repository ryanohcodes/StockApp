using Microsoft.EntityFrameworkCore;
using pokeApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add DbContext to actually making the connection between entityF and the database

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); //same namr from appsettings.json
});

// these lines of code resolve CORS issues from angular local host
builder.Services.AddCors(options => options.AddPolicy(name: "PokemonOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        policy.WithOrigins("https://localhost:7251").AllowAnyMethod().AllowAnyHeader();
    }
    ));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// actually uses the CORS 
app.UseCors("PokemonOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();





