using CMyOld_Api.Domain.Entities;
using FluentAssertions;

namespace CMyOld_Api.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid Parameters!")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category Negative Id Value!")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category Short Name Value!")]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
            .Throw<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category Missing Name Value!")]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category With Null Name Value!")]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<CMyOld_Api.Domain.Validation.DomainExceptionValidation>();
    }
}