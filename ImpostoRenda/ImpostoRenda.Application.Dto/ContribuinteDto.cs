using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Application.Dto
{
    public class ContribuinteDto
    {
        public int IdContribuinte { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public int Dependentes { get; set; }

        public decimal Salario { get; set; }

        public decimal SalarioLiquido { get; set; }
    }
}
