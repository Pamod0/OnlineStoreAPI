using Microsoft.EntityFrameworkCore;
using OnlineStore.Interfaces;
using OnlineStore.Interfaces.ProductInterfaces;
using OnlineStore.Repository;
using OnlineStore.Repository.ProductRepository;
using PokemonReviewApp;
using PokemonReviewApp.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddTransient<Seed>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

/*
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("WebApiConnectionString"));
});
*/

var app = builder.Build();

//if (args.Length == 1 && args[0].ToLower() == "seeddata")
//    SeedData(app);

//void SeedData(IHost app)
//{
//    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

//    using (var scope = scopedFactory.CreateScope())
//    {
//        var service = scope.ServiceProvider.GetService<Seed>();
//        service.SeedDataContext();
//    }
//}


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
