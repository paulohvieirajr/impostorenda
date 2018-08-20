using ImpostoRenda.Dominio.Entidades;
using ImpostoRenda.Dominio.Interfaces;
using ImpostoRenda.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Dominio.Services
{
    public class ServiceSalarioMinimo : ServiceBase<SalarioMinino>, IServiceSalarioMinimo
    {
        private readonly IRepositorioSalarioMinimo _repositorio;

        public ServiceSalarioMinimo(IRepositorioSalarioMinimo repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
