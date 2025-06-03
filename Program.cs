
using FootballManagerApi.Data;
using FootballManagerApi.Services;
using FootballManagerApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


namespace FootballManagerApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        var connectionString = builder.Configuration.GetConnectionString("FootballManagarDb");

        builder.Services.AddDbContext<FootballDbContext>(option =>
        {
            option.UseNpgsql(connectionString);
        });
        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddScoped<IPlayerService, PlayerService>(); // <--->
        builder.Services.AddScoped<ITeamService, TeamService>();
        builder.Services.AddScoped<IMatchService, MatchService>();
        builder.Services.AddScoped<IGoalService, GoalService>();


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
