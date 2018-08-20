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

namespace ImpostoRenda.Tests
{
    public class SalarioMininoServiceApllicationTest
    {
        private readonly Mock<IServiceSalarioMinimo> _mockDependency;

        public SalarioMininoServiceApllicationTest()
        {
            _mockDependency = new Mock<IServiceSalarioMinimo>();
            _mockDependency.Setup(x => x.Insert(It.IsAny<SalarioMinino>())).Returns(true);
            _mockDependency.Setup(x => x.Update(It.IsAny<SalarioMinino>())).Returns(true);
            _mockDependency.Setup(x => x.Get(It.IsAny<int>())).Returns(new SalarioMinino(1));
            _mockDependency.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
        }

        [Fact]
        public void Quando_Chamar_Salvar_Sem_Id_Retornar_True()
        {
            var service = new ApplicationServiceSalarioMinimo(_mockDependency.Object);
            var entidade = new SalarioMinimoDto();
            Assert.True(service.Salvar(entidade).Result);
        }

        [Fact]
        public void Quando_Chamar_Salvar_Com_Id_Retornar_True()
        {
            var service = new ApplicationServiceSalarioMinimo(_mockDependency.Object);
            var entidade = new SalarioMinimoDto() { IdSalarioMinimo = 1};
            Assert.True(service.Salvar(entidade).Result);
        }

        [Fact]
        public void Quando_Chamar_Obter_Sem_Id_Retornar_False()
        {
            _mockDependency.Setup(x => x.Get(It.IsAny<int>())).Returns(It.IsAny<SalarioMinino>());
            var service = new ApplicationServiceSalarioMinimo(_mockDependency.Object);
            Assert.False(service.Obter().Result);
        }

        [Fact]
        public void Quando_Chamar_Obter_Com_Id_Retornar_True()
        {
            _mockDependency.Setup(x => x.Get(It.IsAny<int>())).Returns(new SalarioMinino(1));
            var service = new ApplicationServiceSalarioMinimo(_mockDependency.Object);
            Assert.True(service.Obter().Result);
        }
    }
}
