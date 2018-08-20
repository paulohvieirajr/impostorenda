using ImpostoRenda.Dominio.Entidades;
using System;
using Xunit;
using Flunt.Validations;
using ImpostoRenda.Dominio.Interfaces;
using Moq;
using ImpostoRenda.Dominio.Repositorios;
using ImpostoRenda.Dominio.Services;

namespace ImpostoRenda.Tests
{
    public class ServiceBaseTest
    {
        private readonly Mock<IRepositorioSalarioMinimo> _mockDependency;

        public ServiceBaseTest()
        {
            _mockDependency = new Mock<IRepositorioSalarioMinimo>();

            _mockDependency.Setup(x => x.Insert(It.IsAny<SalarioMinino>())).Returns(true);
            _mockDependency.Setup(x => x.Update(It.IsAny<SalarioMinino>())).Returns(true);
            _mockDependency.Setup(x => x.Get(It.IsAny<int>())).Returns(new SalarioMinino(1));
            _mockDependency.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
        }

        [Fact]
        public void Quando_Chamar_Insert_Retornar_True()
        {
            var service = new ServiceSalarioMinimo(_mockDependency.Object);
            var entidade = new SalarioMinino(0);
            Assert.True(service.Insert(entidade));
        }

        [Fact]
        public void Quando_Chamar_Update_Retornar_True()
        {
            var service = new ServiceSalarioMinimo(_mockDependency.Object);
            var entidade = new SalarioMinino(0);
            Assert.True(service.Update(entidade));
        }

        [Fact]
        public void Quando_Chamar_Get_Retornar_True()
        {
            var service = new ServiceSalarioMinimo(_mockDependency.Object);
            Assert.True(service.Get(1) != null);
        }

        [Fact]
        public void Quando_Chamar_Delete_Retornar_True()
        {
            var service = new ServiceSalarioMinimo(_mockDependency.Object);
            Assert.True(service.Delete(1));
        }
    }
}
