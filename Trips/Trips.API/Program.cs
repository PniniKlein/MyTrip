using Trips.API.Controllers;
using Trips.Core.Entities;
using Trips.Core.IRepository;
using Trips.Core.IService;
using Trips.Data;
using Trips.Data.Repository;
using Trips.Service.Servise;
using Trips.Service.Servises;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DataContext>();
builder.Services.AddScoped<Iservice<Attraction>,AttractionService>();
builder.Services.AddScoped<Iservice<AttractionToTrip>, AttractionToTripService>();
builder.Services.AddScoped<Iservice<Guide>, GuideService>();
builder.Services.AddScoped<Iservice<Order>, OrderService>();
builder.Services.AddScoped<Iservice<Trip>, TripService>();
builder.Services.AddScoped<Iservice<User>, UserService>();
builder.Services.AddScoped<IRepository<Attraction>, AttractionRepository>();
builder.Services.AddScoped<IRepository<AttractionToTrip>, AttractionToTripRepository>();
builder.Services.AddScoped<IRepository<Guide>, GuideRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<Trip>, TripRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
