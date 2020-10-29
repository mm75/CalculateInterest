using System;
using CalculateInterest.Application.Services;
using Xunit;
using ApplicationException = CalculateInterest.Core.ApplicationException;

namespace CalculateInterest.Application.Tests.Services
{
    public class ComputeServiceTests
    {
        [Fact(DisplayName = "Deve calcular a taxa de juros.")]
        [Trait("Category", "ComputeService")]
        public void ComputeService_Calculate_DeveCalcular()
        {
            // Arrange
            ComputeService computeService = new ComputeService();
            
            // Act
            double result = computeService.Calculate(100, 0.01, 5);
            
            // Assert
            Assert.Equal(105.10, result);
        }

        [Fact(DisplayName = "Não deve calcular a taxa de juros.")]
        [Trait("Category", "ComputeService")]
        public void ComputeService_Calculate_NaoDeveCalcular()
        {
            // Arrange
            ComputeService computeService = new ComputeService();
            
            // Act
            double result = computeService.Calculate(100, 0.01, 5);
            
            // Assert
            Assert.NotEqual(105.11, result);
        }

        [Fact(DisplayName = "Deve retornar erro quando o valor inicial for menor ou igual a zero.")]
        [Trait("Category", "ComputeService")]
        public void ComputeService_Calculate_DeveRetornarErroSeValorInicialForIgualOuMenorAZero()
        {
            // Arrange
            ComputeService computeService = new ComputeService();
            
            // Act
            ApplicationException exception = Assert.Throws<ApplicationException>(() => computeService.Calculate(0, 0.01, 5));
            
            // Assert
            Assert.Equal("O valor inicial deve ser maior que zero.", exception.Message);
        }

        [Fact(DisplayName = "Deve retornar erro quando a taxa de juros for menor que zero.")]
        [Trait("Category", "ComputeService")]
        public void ComputeService_Calculate_DeveRetornarErroSeTaxaDeJurosForMenorQueZero()
        {
            // Arrange
            ComputeService computeService = new ComputeService();
            
            // Act
            ApplicationException exception = Assert.Throws<ApplicationException>(() => computeService.Calculate(100, -0.01, 5));
            
            // Assert
            Assert.Equal("A taxa de juros deve ser maior ou igual a zero.", exception.Message);
        }

        [Fact(DisplayName = "Deve retornar erro quando o mês for menor ou igual a zero.")]
        [Trait("Category", "ComputeService")]
        public void ComputeService_Calculate_DeveRetornarErroSeMesForIgualOuMenorAZero()
        {
            // Arrange
            ComputeService computeService = new ComputeService();
            
            // Act
            ApplicationException exception = Assert.Throws<ApplicationException>(() => computeService.Calculate(100, 0.01, 0));
            
            // Assert
            Assert.Equal("O total de meses deve ser maior que zero.", exception.Message);
        }
    }
}