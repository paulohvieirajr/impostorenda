using ImpostoRenda.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Dominio.Interfaces
{
    public interface IServiceContribuinte : IServiceBase<Contribuinte>
    {
        Contribuinte ObterPorCPF(string cpf);
        List<Contribuinte> ListarComDescontos();
    }
}
