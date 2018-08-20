using ImpostoRenda.Domain.Entidades;
using ImpostoRenda.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ImpostoRenda.Infrastructure.Repositories
{
    public class RepositorioContribuinte : RepositorioBase<Contribuinte>, IRepositorioContribuinte
    {
        private readonly ImpostoRendaContex _context;

        public RepositorioContribuinte(ImpostoRendaContex dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public Contribuinte ObterPorCPF(string cpf)
        {
            return _context.Contribuintes.FirstOrDefault(x => x.CPF == cpf);
        }

        public List<Contribuinte> Listar()
        {
            return _context.Contribuintes.ToList();
        }
    }
}
