using ImpostoRenda.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Dominio.Repositorios
{
    public interface IRepositorioContribuinte : IRepositorioBase<Contribuinte>
    {
        List<Contribuinte> Listar();
        Contribuinte ObterPorCPF(string cpf);
    }
}
