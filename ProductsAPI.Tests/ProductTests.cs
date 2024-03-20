using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Enums;
using ProductsAPI.Domain.Exceptions;
using System;
using Xunit;

namespace ProductsAPI.Tests
{
    public class ProductTests
    {
        [Fact(DisplayName = "Testa construtor com parâmetros válidos")]
        public void Constructor_ValidParameters_Success()
        {
            // Arrange
            int code = 1;
            string description = "Test Product";
            var status = ProductStatus.Active;
            DateTime manufacturingDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now.AddDays(30);
            int supplierCode = 1;

            // Act
            var product = new Product(code, description, status, manufacturingDate, expirationDate, supplierCode);

            // Assert
            Assert.Equal(code, product.Code);
            Assert.Equal(description, product.Description);
            Assert.Equal(status, product.Status);
            Assert.Equal(manufacturingDate, product.ManufacturingDate);
            Assert.Equal(expirationDate, product.ExpirationDate);
            Assert.Equal(supplierCode, product.SupplierCode);
        }

        [Theory(DisplayName = "Testa construtor com código inválido")]
        [InlineData(0)]        
        public void Constructor_InvalidCode_ThrowsException(int code)
        {
            // Arrange
            string description = "Test Product";
            var status = ProductStatus.Active;
            DateTime manufacturingDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now.AddDays(30);
            int supplierCode = 1;

            // Act and Assert
            Assert.Throws<InvalidEntityException>(() => new Product(code, description, status, manufacturingDate, expirationDate, supplierCode));
        }
    }
}
