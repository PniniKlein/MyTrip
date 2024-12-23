using Microsoft.EntityFrameworkCore;
using Trips.API.Controllers;
using Trips.Core.Entities;
using Trips.Core.IRepositories;
using Trips.Core.IRepository;
using Trips.Core.IService;
using Trips.Data;
using Trips.Data.Repository;
using Trips.Service.Servise;
using Trips.Service.Servises;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(option =>
            {
    option.UseSqlServer("Data Source = DESKTOP-BBPQVA2\\SQLEXPRESS; Initial Catalog = DBTrips; Integrated Security = true; ");
});
builder.Services.AddScoped<IAttractionService,AttractionService>();
builder.Services.AddScoped<IGuideService, GuideService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAttractionRepository,AttractionRepository>();
builder.Services.AddScoped<IGuideRepository,GuideRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
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
