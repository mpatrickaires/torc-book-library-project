using Microsoft.EntityFrameworkCore;
using WebApi.Infra.Db;
using WebApi.Infra.Repositories;
using WebApi.Infra.Repositories.Interfaces;
using WebApi.Services;
using WebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddDbContext<LibraryDbContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("TorcBookLibraryDb"))
    .UseSnakeCaseNamingConvention());

builder.Services.AddControllers();
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
