using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericFunctions<>));
builder.Services.AddScoped<DbContext, ReserveTaPlaceContext>();
builder.Services.AddDbContext<ReserveTaPlaceContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("RTPSQLServer")));//RTPLocalDb

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
   //TODO Or Not
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
