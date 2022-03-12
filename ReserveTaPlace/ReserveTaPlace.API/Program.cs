using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using ReserveTaPlace.API.Authorizations;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    //Todo Less permissive policy
    options.AddPolicy(devCorsPolicy,
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});
//todo
//builder.Services.AddCors(a=>a.AddPolicy("mypolicy",b=>b.WithOrigins("https://localhost:7091/").AllowAnyMethod().AllowAnyHeader()));
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;

    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;

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


//ToDO AUTH0 Policy
//builder.Services.AddAuthorization(o => o.AddPolicy("myPolicy", b =>
//{
//    b.AddRequirements(new ReadWriteRequirement());
//   b.RequireAssertion(c => c.User.Identity.Name == "toto");
//}));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetService<ReserveTaPlaceContext>();
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
//Todo Implement security auth0
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
