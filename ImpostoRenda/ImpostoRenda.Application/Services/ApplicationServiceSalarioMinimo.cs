using ImpostoRenda.Application.Dto;
using ImpostoRenda.Application.Interfaces;
using ImpostoRenda.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Application.Services
{
    public class ApplicationServiceSalarioMinimo : IApplicationSalarioMinimo
    {
        private readonly IServiceSalarioMinimo _service;

        public ApplicationServiceSalarioMinimo(IServiceSalarioMinimo service)
        {
            _service = service;
        }

        public ServiceResponse<SalarioMinimoDto> Obter()
        {
            var result = new ServiceResponse<SalarioMinimoDto>();

            try
            {
                var entidade = _service.Get(1);
                if (entidade != null)
                {
                    result.Object = new SalarioMinimoDto()
                    {
                        IdSalarioMinimo = entidade.IdSalarioMinino,
                        Valor = entidade.Valor
                    };

                    result.Result = true;
                }
                else
                {
                    result.Result = false;
                    result.Messages.Add("Não foi possível localizar o salário mínimo");
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add("Problemas ao obter o salário mínimo: " + ex.Message);
            }
            
            return result;
        }

        public ServiceResponse<bool> Salvar(SalarioMinimoDto dto)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var entidade = _service.Get(dto.IdSalarioMinimo);
                if(entidade != null)
                {
                    entidade.AlterarSalarioMinimo(dto.Valor);
                    _service.Update(entidade);
                    result.Result = result.Object = true;
                }
                else
                {
                    entidade = new Dominio.Entidades.SalarioMinino(dto.Valor);
                    if(entidade.Valid)
                    {
                        _service.Insert(entidade);
                        result.Result = true;
                    }
                    else
                    {
                        foreach (var item in entidade.Notifications)
                        {
                            result.Messages.Add(item.Message);
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add("Problemas ao obter o salário mínimo: " + ex.Message);
            }

            return result;
        }
    }
}
