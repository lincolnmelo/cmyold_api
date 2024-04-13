using CMyOld_Api.Domain.Entities;
using FluentAssertions;

namespace CMyOld_Api.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 10, "String Image");
            action.Should()
                .NotThrow<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 10.3m, 10, "String Image");
            action.Should()
                .Throw<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 10.3m, 10, "String Image");
            action.Should()
                .Throw<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.3m, 10, "String Image dddddddddddddddddddddddjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
            action.Should()
                .Throw<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImage_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.3m, 10, null);
            action.Should()
                .NotThrow<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
        }
        
        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.3m, 10, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.3m, 10, "");
            action.Should()
                .NotThrow<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.3m, value, "");
            action.Should()
                .Throw<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
        }
    }
}