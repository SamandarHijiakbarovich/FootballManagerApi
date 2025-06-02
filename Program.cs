
using FootballManagerApi.Data;
using Microsoft.EntityFrameworkCore;


namespace FootballManagerApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Ensure the required package is installed: Microsoft.EntityFrameworkCore.SqlServer  
        /*builder.Services.AddDbContext<FootballDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("FootballManagarDb")));
*/
        var connectionString = builder.Configuration.GetConnectionString("FootballManagarDb");

        builder.Services.AddDbContext<FootballDbContext>(option =>
        {
            option.UseNpgsql(connectionString);
        });

        // Add services to the container.  
        builder.Services.AddControllers();
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
    }
}
