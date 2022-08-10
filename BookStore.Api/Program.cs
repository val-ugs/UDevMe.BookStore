using BookStore.BusinessLogic.Services;
using BookStore.Domain.Abstractions;
using BookStore.MSSQL;
using BookStore.MSSQL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(DataAccessMappingProfile));

builder.Services.AddTransient<IBookRepository, BookRepository>();

builder.Services.AddTransient<IBookService, BookService>();

builder.Services.AddDbContext<BookStoreContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreContext")));

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

app.UseCors(options => options
    .WithOrigins(new[] { "https://localhost:7122" })
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
