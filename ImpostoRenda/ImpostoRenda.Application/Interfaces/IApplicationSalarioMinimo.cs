using ImpostoRenda.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Application.Interfaces
{
    public interface IApplicationSalarioMinimo
    {
        ServiceResponse<SalarioMinimoDto> Obter();
        ServiceResponse<bool> Salvar(SalarioMinimoDto dto);
    }
}
