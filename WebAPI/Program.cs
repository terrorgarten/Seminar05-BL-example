using BusinessLayer.Services;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqliteDbName = "seminar05.db";

var folder = Environment.SpecialFolder.LocalApplicationData;
var dbPath = Path.Join(Environment.GetFolderPath(folder), sqliteDbName);

var sqliteConnectionString = $"Data Source={dbPath}";

builder.Services.AddDbContextFactory<SeminarDBContext>(options =>
{
    options
       .UseSqlite(sqliteConnectionString)
       .LogTo(a => Console.WriteLine(a), LogLevel.Debug)
       .EnableSensitiveDataLogging(true)
       .UseLazyLoadingProxies();
       ;
});

/* Register Services */
builder.Services.AddScoped<IUserService, UserService>();

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
