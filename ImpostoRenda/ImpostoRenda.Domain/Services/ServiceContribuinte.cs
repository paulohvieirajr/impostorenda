using ImpostoRenda.Domain.Entidades;
using ImpostoRenda.Dominio.Interfaces;
using ImpostoRenda.Dominio.Repositorios;
using ImpostoRenda.Dominio.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Dominio.Services
{
    public class ServiceContribuinte : ServiceBase<Contribuinte>, IServiceContribuinte
    {
        private readonly IRepositorioContribuinte _repositorio;
        private readonly IServiceSalarioMinimo _serviceSalarioMinimo;

        public ServiceContribuinte(IRepositorioContribuinte repositorio, IServiceSalarioMinimo serviceSalarioMinimo) : base(repositorio)
        {
            _repositorio = repositorio;
            _serviceSalarioMinimo = serviceSalarioMinimo;
        }

        public override bool Insert(Contribuinte entity)
        {
            var entidade = _repositorio.ObterPorCPF(entity.CPF);
            if(entidade != null)
            {
                return false;
            }

            return base.Insert(entity);
        }

        public Contribuinte ObterPorCPF(string cpf)
        {
            return _repositorio.ObterPorCPF(cpf);
        }

        public List<Contribuinte> ListarComDescontos()
        {
            var result = new List<Contribuinte>();

            var contribuintes = _repositorio.Listar();

            var salarioMinimo = _serviceSalarioMinimo.Get(1);
            if(salarioMinimo != null)
            {
                var descontoDependente = salarioMinimo.Valor * (decimal)0.05;
                foreach (var item in contribuintes)
                {
                    item.CalcularDescontos(descontoDependente, salarioMinimo.Valor);
                }

                result = contribuintes;
            }

            return result;
        }
    }
}
