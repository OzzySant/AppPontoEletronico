using Application.Interfaces;
using Application.Services;
using Core.Interface;
using Infra.Data.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IOC;

public static class ConfigurarDepedencias
{
    public static void InjetarDependencias(this IServiceCollection services)
    {
        //Faz o Bild da interface e quem a Implementa.

        services.AddScoped<IRepositoryDepartamento, RepositoryDepartamento>();

        services.AddScoped<IServiceDepartamento, ServiceDepartamento>();
        services.AddScoped<IServiceUsuarioQualificado, ServiceUsuarioQualificado>();
    }
}
