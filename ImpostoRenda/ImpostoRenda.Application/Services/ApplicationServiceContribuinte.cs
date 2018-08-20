using ImpostoRenda.Application.Dto;
using ImpostoRenda.Application.Interfaces;
using ImpostoRenda.Domain.Entidades;
using ImpostoRenda.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImpostoRenda.Application.Services
{
    public class ApplicationServiceContribuinte : IApplicationContribuinte
    {
        private readonly IServiceContribuinte _service;

        public ApplicationServiceContribuinte(IServiceContribuinte service)
        {
            _service = service;
        }

        public ServiceResponse<ContribuinteDto> Obter(int id)
        {
            var result = new ServiceResponse<ContribuinteDto>();

            try
            {
                var contribuinte = _service.Get(id);
                if (contribuinte != null)
                {
                    result.Object = new ContribuinteDto()
                    {
                        CPF = contribuinte.CPF,
                        Dependentes = contribuinte.Dependentes,
                        IdContribuinte = contribuinte.IdContribuinte,
                        Nome = contribuinte.Nome,
                        Salario = contribuinte.Salario,
                        SalarioLiquido = contribuinte.SalarioLiquido
                    };

                    result.Result = true;
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add("Problemas ao obter a lista de contribuintes: " + ex.Message);
            }

            return result;
        }

        public ServiceResponse<List<ContribuinteDto>> ListarComDescontos()
        {
            var result = new ServiceResponse<List<ContribuinteDto>>();

            try
            {
                var contribuintes = _service.ListarComDescontos();
                if(contribuintes.Any())
                {
                    result.Object = new List<ContribuinteDto>();

                    contribuintes.ForEach(item => result.Object.Add(new ContribuinteDto()
                    {
                        CPF = item.CPF,
                        Dependentes = item.Dependentes,
                        IdContribuinte = item.IdContribuinte,
                        Nome = item.Nome,
                        Salario = item.Salario,
                        SalarioLiquido = item.SalarioLiquido
                    }));

                    result.Result = true;
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add("Problemas ao obter a lista de contribuintes: " + ex.Message);
            }

            return result;
        }

        public ServiceResponse<bool> Inserir(ContribuinteDto dto)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var contribuinte = new Contribuinte(dto.CPF, dto.Nome, dto.Dependentes, dto.Salario);
                if(contribuinte.Valid)
                {
                    var entidade = _service.ObterPorCPF(contribuinte.CPF);
                    if(entidade != null)
                    {
                        result.Messages.Add("O CPF informado já pertence a um contribuinte");
                    }
                    else
                    {
                        result.Object = result.Result = _service.Insert(contribuinte);
                    }                  
                }
                else
                {
                    foreach (var item in contribuinte.Notifications)
                    {
                        result.Messages.Add(item.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add("Problemas ao salvar o contribuintes: " + ex.Message);
            }

            return result;
        }

        public ServiceResponse<bool> Alterar(ContribuinteDto dto)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var contribuinte = _service.Get(dto.IdContribuinte);
                if (contribuinte != null)
                {
                    contribuinte.Alterar(dto.CPF, dto.Nome, dto.Dependentes, dto.Salario);
                    if(contribuinte.Valid)
                    {
                        _service.Update(contribuinte);
                        result.Result = result.Object = true;
                    }
                    else
                    {
                        foreach (var item in contribuinte.Notifications)
                        {
                            result.Messages.Add(item.Message);
                        }
                    }
                }
                else
                {
                    foreach (var item in contribuinte.Notifications)
                    {
                        result.Messages.Add(item.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add("Problemas ao salvar o contribuinte: " + ex.Message);
            }

            return result;
        }
    }
}
