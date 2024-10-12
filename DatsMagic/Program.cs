using DatsMagic.Config;
using DatsMagic.Services;
using DatsMagic.Services.DatsTeamServers;

namespace DatsMagic;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<DatsTeamServerOptions>(
            builder.Configuration.GetSection(nameof(DatsTeamServerOptions)));
        builder.Services.Configure<DataLogsOptions>(
            builder.Configuration.GetSection(nameof(DataLogsOptions)));

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHostedService<GameTick>();

        builder.Services.AddSingleton<GameService>();
        builder.Services.AddSingleton<DataWriter>();
        builder.Services.AddSingleton<DataReader>();
        builder.Services.AddHttpClient<DatsTeamMainServer>();
        builder.Services.AddHttpClient<DatsTeamTestServer>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowAll");
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
