using ImpostoRenda.Application.Interfaces;
using ImpostoRenda.Application.Services;
using ImpostoRenda.Dominio.Interfaces;
using ImpostoRenda.Dominio.Repositorios;
using ImpostoRenda.Dominio.Services;
using ImpostoRenda.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using System;

namespace ImpostoRenda.Infrastructure.Ioc
{
    public class SimpleInjectorContainer
    {
        public static Container Register(DbContextOptions<ImpostoRendaContex> options)
        {
            var container = new Container();

            container.Register<ImpostoRendaContex>(() => {
                return new ImpostoRendaContex(options);
            }, ScopedLifestyle.Singleton);

            // Application
            container.Register<IApplicationContribuinte, ApplicationServiceContribuinte>();
            container.Register<IApplicationSalarioMinimo, ApplicationServiceSalarioMinimo>();

            // Domain
            container.Register<IServiceContribuinte, ServiceContribuinte>();
            container.Register<IServiceSalarioMinimo, ServiceSalarioMinimo>();

            // Infrastructure
            container.Register<IRepositorioContribuinte, RepositorioContribuinte>();
            container.Register<IRepositorioSalarioMinimo, RepositorioSalarioMinimo>();



            container.Verify();

            return container;
        }
    }
}
