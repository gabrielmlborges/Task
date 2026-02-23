using Microsoft.EntityFrameworkCore;
using Task.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=todoapp.db"));
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
