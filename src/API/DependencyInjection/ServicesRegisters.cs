using System.Reflection;
using Microsoft.EntityFrameworkCore;
using API.Data.Context;
using API.Data.Repositories;
using API.Models.Mappers;
using API.Services;
using AutoMapper;
using FluentValidation;


namespace API.DependencyInjection;

public static class ServicesRegisters
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISolicitacaoService, SolicitacaoService>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();
        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        MapperConfiguration mapperConfiguration = new(c => {
            // c.AddProfiles(Assembly.GetEntryAssembly());
            c.AddProfile<MappingProfile>();
        });
        //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddSingleton(mapperConfiguration.CreateMapper());
        return services;
    }

    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("ApplicationDbConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                                .EnableSensitiveDataLogging()
                                .EnableDetailedErrors()
                                .LogTo(Console.WriteLine, LogLevel.Information), ServiceLifetime.Scoped);
        return services;
    }
}