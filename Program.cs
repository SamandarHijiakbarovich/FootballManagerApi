using FootballManagerApi.Data;
using FootballManagerApi.Services;
using FootballManagerApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using FootballManagerApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;  // Middleware namespace-ni qo'shing


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

        builder.Services.AddScoped<IPlayerService, PlayerService>();
        builder.Services.AddScoped<ITeamService, TeamService>();
        builder.Services.AddScoped<IMatchService, MatchService>();
        builder.Services.AddScoped<IGoalService, GoalService>();
        builder.Services.AddScoped<IAuthService, AuthService>();


        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = builder.Configuration["Jwt:Issuer"],
              ValidAudience = builder.Configuration["Jwt:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
          };
      });

        builder.Services.AddAuthorization();

        // Add services to the container.
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // **Exception middleware ni shu yerda qo'shamiz, authorization va routingdan oldin**
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseAuthorization();
        app.UseAuthentication();

        app.MapControllers();

        app.Run();
    }
}
