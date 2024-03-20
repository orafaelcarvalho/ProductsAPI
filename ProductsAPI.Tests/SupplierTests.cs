using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Exceptions;
using ProductsAPI.Domain.Exceptions;
using System;
using Xunit;

namespace ProductsAPI.Tests
{
    public class SupplierTests
    {
        [Fact(DisplayName = "Testa construtor com parâmetros válidos")]
        public void Constructor_ValidParameters_Success()
        {
            // Arrange
            int code = 1;
            string description = "Test Supplier";
            string cnpj = "23380427000168";

            // Act
            var supplier = new Supplier(code, description, cnpj);

            // Assert
            Assert.Equal(code, supplier.Code);
            Assert.Equal(description, supplier.Description);
            Assert.Equal(cnpj, supplier.CNPJ);
        }

        [Theory(DisplayName = "Testa construtor com código inválido")]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidCode_ThrowsException(int code)
        {
            // Arrange
            string description = "Test Supplier";
            string cnpj = "12345678901234";

            // Act & Assert
            Assert.Throws<InvalidEntityException>(() => new Supplier(code, description, cnpj));
        }

        [Theory(DisplayName = "Testa construtor com descrição inválida")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Constructor_InvalidDescription_ThrowsException(string description)
        {
            // Arrange
            int code = 1;
            string cnpj = "12345678901234";

            // Act and Assert
            Assert.Throws<InvalidEntityException>(() => new Supplier(code, description, cnpj));
        }

        [Theory(DisplayName = "Testa construtor com CNPJ inválido")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData("12345")]
        [InlineData("123456789012345678")]
        public void Constructor_InvalidCNPJ_ThrowsException(string cnpj)
        {
            // Arrange
            int code = 1;
            string description = "Test Supplier";

            // Act and Assert
            Assert.Throws<InvalidEntityException>(() => new Supplier(code, description, cnpj));
        }
    }
}
