using ImpostoRenda.Dominio.Entidades;
using System;
using Xunit;
using Flunt.Validations;

namespace ImpostoRenda.Tests
{
    public class SalarioMinimoTest
    {
        public SalarioMinimoTest()
        {

        }

        [Fact]
        public void Quando_Criar_Um_Salario_Minimo_Zerado_Reportar_Validacao()
        {
            var salario = new SalarioMinino(0);

            Assert.False(salario.Valid);
        }

        [Fact]
        public void Quando_Criar_Um_Salario_Minimo_Maior_Que_Zero_Sem_Erros()
        {
            var salario = new SalarioMinino(10);

            Assert.True(salario.Valid);
        }
    }
}
