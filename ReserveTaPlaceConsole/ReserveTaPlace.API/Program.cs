using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy,
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    //options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpClient("Imdb", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://movie-database-imdb-alternative.p.rapidapi.com/");
    httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
    httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", builder.Configuration.GetConnectionString("IMDB").ToString());
});
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericFunctions<>));
builder.Services.AddScoped<DbContext, ReserveTaPlaceContext>();
builder.Services.AddDbContext<ReserveTaPlaceContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("RTPLocalDb")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ReserveTaPlaceContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(devCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
