using ImpostoRenda.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Application.Interfaces
{
    public interface IApplicationContribuinte
    {
        ServiceResponse<List<ContribuinteDto>> ListarComDescontos();
        ServiceResponse<ContribuinteDto> Obter(int id);
        ServiceResponse<bool> Inserir(ContribuinteDto dto);
        ServiceResponse<bool> Alterar(ContribuinteDto dto);
    }
}
