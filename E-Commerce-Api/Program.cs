using E_Commerce_Api.Data;
using E_Commerce_Api.Interface;
using E_Commerce_Api.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// SQL Server ba�lant�s�n� yap�land�r
builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Dependecy Injection
builder.Services.AddScoped<IOrderService, OrderService>();

//TODO Furkan
//Migration Yapmad�m, Hangi DB'yi kullanaca��n�z� bilemedimden Nuget olarak SQL Server En az�ndan Impelemente ettim. 

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
