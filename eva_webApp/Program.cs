using eva_webApp.Database;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:3000",
                                              "https://localhost:3001");
                      });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var dbContextOptions = new DbContextOptionsBuilder<FitnessAppContext>()
    .UseSqlite("DataSource=fitness.db")
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information)
                .Options;
builder.Services.AddDbContext<FitnessAppContext>(c => {
    c
    .UseSqlite(@$"DataSource=fitness.db")
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        using (var db = scope.ServiceProvider.GetService<FitnessAppContext>())
        {
            if (db is null)
            {
                throw new Exception("No DB!");
            }
            // New DB!!!
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //await db.SeedBogusAsync(db);
        }
    }
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
