using Flunt.Validations;
using ImpostoRenda.Dominio.Entidades;
using ImpostoRenda.Dominio.ValueObjetcs;
using System;

namespace ImpostoRenda.Domain.Entidades
{
    public class Contribuinte : Base
    {
        #region Value Objects

        private CPF _CPF { get; set; }

        private Name _Name { get; set; }

        #endregion

        #region Contructor

        protected Contribuinte()
        {

        }

        public Contribuinte(string cpf, string nome, int dependentes, decimal salario)
        {
            _CPF = new CPF(cpf);
            _Name = new Name(nome);
            Dependentes = dependentes;
            Salario = salario;

            Validation();
        }

        #endregion

        #region Properts

        public int IdContribuinte { get; set; }

        public string CPF
        {
            get { return _CPF.Document; }
            protected set { _CPF = new CPF(value); }
        }

        public string Nome
        {
            get { return _Name.FullName; }
            protected set { _Name = new Name(value); }
        }

        public int Dependentes { get; protected set; }

        public decimal Salario { get; protected set; }

        public decimal SalarioLiquido { get; protected set; }

        #endregion

        #region Methods

        public void CalcularDescontoDependentes(decimal valorDesconto)
        {
            SalarioLiquido = Salario - (valorDesconto * Dependentes);
        }

        public void CalcularDescontoIR(decimal salarioMinimo)
        {
            var nrSalarios = Salario % salarioMinimo;
            if (nrSalarios > 2 && nrSalarios <= 4)
            {
                SalarioLiquido = Salario - ((Salario * (decimal)7.5) / 100);
            }
            else if(nrSalarios <= 5)
            {
                SalarioLiquido = Salario - ((Salario * (decimal)15) / 100);
            }
            else if(nrSalarios <= 7)
            {
                SalarioLiquido = Salario - ((Salario * (decimal)22.5) / 100);
            }
            else
            {
                SalarioLiquido = Salario - ((Salario * (decimal)27.5) / 100);
            }
        }

        public void CalcularDescontos(decimal valorDesconto, decimal salarioMinimo)
        {
            CalcularDescontoDependentes(valorDesconto);
            var salario = Salario;
            Salario = SalarioLiquido;
            CalcularDescontoIR(salarioMinimo);
            Salario = salario;
        }

        public void Alterar(string cpf, string nome, int dependentes, decimal salario)
        {
            _CPF = new CPF(cpf);
            _Name = new Name(nome);
            Dependentes = dependentes;
            Salario = salario;

            Validation();
        }

        #endregion

        #region Validate

        private void Validation()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsFalse(ValidarDependentes(), "Contribuinte.Dependentes", "Por favor, informe um numero de dependentes maior ou igual a zero"));

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(ValidarSalario(), "Contribuinte.Salario", "Por favor, informe um salário maior que zero"));

            AddNotifications(_CPF, _Name);
        }

        private bool ValidarDependentes()
        {
            return Dependentes < 0;
        }

        private bool ValidarSalario()
        {
            return Salario < 1;
        }

        #endregion
    }
}
