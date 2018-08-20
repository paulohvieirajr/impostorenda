using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Dominio.Entidades
{
    public class SalarioMinino : Base
    {
        public SalarioMinino(decimal valor)
        {
            Valor = valor;

            AddNotificarions();
        }

        public int IdSalarioMinino { get; protected set; }

        public decimal Valor { get; protected set; }

        public void AlterarSalarioMinimo(decimal valor)
        {
            Valor = valor;

            AddNotificarions();
        }

        private void AddNotificarions()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsFalse(ValidarValor(), "SalarioMinimo.Valor", "Por favor, informe um salário maior que zero"));
        }

        private bool ValidarValor()
        {
            return Valor < 1;
        }
    }
}
