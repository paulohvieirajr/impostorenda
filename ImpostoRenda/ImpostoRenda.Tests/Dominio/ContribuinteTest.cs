using ImpostoRenda.Dominio.Entidades;
using System;
using Xunit;
using Flunt.Validations;
using ImpostoRenda.Domain.Entidades;

namespace ImpostoRenda.Tests
{
    public class ContribuinteTest
    {
        public ContribuinteTest()
        {

        }

        [Fact]
        public void Quando_Criar_Um_Contribuinte_Com_CPF_Invalido_Reportar_Validacao()
        {
            var contribuinte = new Contribuinte("11111111111", "", 0, 0);

            Assert.False(contribuinte.Valid);
        }

        [Fact]
        public void Quando_Criar_Um_Contribuinte_Com_Nome_Invalido_Reportar_Validacao()
        {
            var contribuinte = new Contribuinte("09269205614", "", 0, 0);

            Assert.False(contribuinte.Valid);
        }

        [Fact]
        public void Quando_Criar_Um_Contribuinte_Com_Dependentes_Invalido_Reportar_Validacao()
        {
            var contribuinte = new Contribuinte("09269205614", "Paulo", -1, 0);

            Assert.False(contribuinte.Valid);
        }

        [Fact]
        public void Quando_Criar_Um_Contribuinte_Com_Dependentes_Salario_Reportar_Validacao()
        {
            var contribuinte = new Contribuinte("09269205614", "Paulo", 0, 0);

            Assert.False(contribuinte.Valid);
        }

        [Fact]
        public void Quando_Criar_Um_Contribuinte_Validar_Nao_Reportar_Validacao()
        {
            var contribuinte = new Contribuinte("09269205614", "Paulo", 0, 1000);

            Assert.True(contribuinte.Valid);
        }
    }
}
