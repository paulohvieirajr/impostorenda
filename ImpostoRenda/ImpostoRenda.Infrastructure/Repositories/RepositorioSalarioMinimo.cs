using ImpostoRenda.Domain.Entidades;
using ImpostoRenda.Dominio.Entidades;
using ImpostoRenda.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Infrastructure.Repositories
{
    public class RepositorioSalarioMinimo : RepositorioBase<SalarioMinino>, IRepositorioSalarioMinimo
    {
        private readonly ImpostoRendaContex _context;

        public RepositorioSalarioMinimo(ImpostoRendaContex dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
