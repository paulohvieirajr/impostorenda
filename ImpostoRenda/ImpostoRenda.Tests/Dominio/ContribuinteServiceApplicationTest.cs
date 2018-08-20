using ImpostoRenda.Dominio.Entidades;
using System;
using Xunit;
using Flunt.Validations;
using ImpostoRenda.Dominio.Interfaces;
using Moq;
using ImpostoRenda.Dominio.Repositorios;
using ImpostoRenda.Dominio.Services;
using ImpostoRenda.Application.Services;
using ImpostoRenda.Application.Dto;
using ImpostoRenda.Domain.Entidades;
using System.Collections.Generic;

namespace ImpostoRenda.Tests
{
    public class ContribuinteServiceApplicationTest
    {
        private readonly Mock<IServiceContribuinte> _mockDependency;

        public ContribuinteServiceApplicationTest()
        {
            _mockDependency = new Mock<IServiceContribuinte>();
            _mockDependency.Setup(x => x.Insert(It.IsAny<Contribuinte>())).Returns(true);
            _mockDependency.Setup(x => x.Update(It.IsAny<Contribuinte>())).Returns(true);
            _mockDependency.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
        }

        [Fact]
        public void Quando_Chamar_Obter_Com_Id_Menor_Que_1_Retornar_False()
        {
            _mockDependency.Setup(x => x.Get(It.IsAny<int>())).Returns(It.IsAny<Contribuinte>());
            var service = new ApplicationServiceContribuinte(_mockDependency.Object);
            Assert.False(service.Obter(0).Result);
        }

        [Fact]
        public void Quando_Chamar_Obter_Com_Id_Maior_Que_0_Retornar_True()
        {
            var contribuinte = new Contribuinte("09269205614", "Paulo", 0, 100);
            _mockDependency.Setup(x => x.Get(It.IsAny<int>())).Returns(contribuinte);
            var service = new ApplicationServiceContribuinte(_mockDependency.Object);
            Assert.True(service.Obter(1).Result);
        }

        [Fact]
        public void Quando_Chamar_Listar_Sem_Contribuintes_Base_Retornar_False()
        {
            _mockDependency.Setup(x => x.ListarComDescontos()).Returns(It.IsAny<List<Contribuinte>>());
            var service = new ApplicationServiceContribuinte(_mockDependency.Object);
            Assert.False(service.ListarComDescontos().Result);
        }

        [Fact]
        public void Quando_Chamar_Listar_Com_Contribuintes_Base_Retornar_False()
        {
            List<Contribuinte> lista = new List<Contribuinte>();
            lista.Add(new Contribuinte("09269205614", "Paulo", 0, 100));
            _mockDependency.Setup(x => x.ListarComDescontos()).Returns(lista);
            var service = new ApplicationServiceContribuinte(_mockDependency.Object);
            Assert.True(service.ListarComDescontos().Result);
        }

        [Fact]
        public void Quando_Chamar_Inserir_Com_Dto_Invalido_Retornar_False()
        {
            ContribuinteDto dto = new ContribuinteDto();
            var service = new ApplicationServiceContribuinte(_mockDependency.Object);
            Assert.False(service.Inserir(dto).Result);
        }

        [Fact]
        public void Quando_Chamar_Inserir_Com_Dto_Valido_Retornar_True()
        {
            ContribuinteDto dto = new ContribuinteDto()
            {
                CPF = "09269205614",
                Dependentes = 0,
                Nome = "Paulo",
                Salario = 1000
            };
            var service = new ApplicationServiceContribuinte(_mockDependency.Object);
            Assert.True(service.Inserir(dto).Result);
        }
    }
}
