using Microsoft.EntityFrameworkCore;
using UTS_72200364.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GuruContext>(options =>
{
    options.UseMySQL(connectionString);
});

builder.Services.AddDbContext<MapelContext>(options =>
{
    options.UseMySQL(connectionString);
});

builder.Services.AddDbContext<JadwalGuruContext>(options =>
{
    options.UseMySQL(connectionString);
});


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
