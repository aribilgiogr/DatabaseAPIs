using BookStoreAPI.Models;
using BookStoreAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BookStoreDatabaseOptions>(builder.Configuration.GetSection("DatabaseOptions"));
builder.Services.AddSingleton<IBooksService, BooksService>();
builder.Services.AddSingleton<IAuthorService, AuthorService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
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
