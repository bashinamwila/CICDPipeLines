using Csla;
using Csla.Server;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CICDPipeLines.BusinessLibrary.Tests;


public class PersonTests(CslaTestFixture fixture) :IClassFixture<CslaTestFixture>
{
    private readonly IServiceProvider _serviceProvider=fixture.Services;

    [Fact]
    public void Person_IsInvalid_WhenRequiredFieldsAreMissing()
    {
        // Arrange
        var portal = _serviceProvider.GetRequiredService<IDataPortal<Person>>();
        var person = portal.Create();

        // Act
        var isValid = person.IsValid;

        // Assert
        Assert.False(isValid);
        Assert.Contains(person.BrokenRulesCollection, r => r.Property == "FirstName");
        Assert.Contains(person.BrokenRulesCollection, r => r.Property == "LastName");
        Assert.Contains(person.BrokenRulesCollection, r => r.Property == "EmployeeId");
    }

    [Fact]
    public void Person_IsValid_WhenAllRequiredFieldsAreSet()
    {
        // Arrange
        var portal = _serviceProvider.GetRequiredService<IDataPortal<Person>>();
        var person = portal.Create();
        person.FirstName = "Dennis";
        person.LastName = "Mwape";
        person.EmployeeId = "EMP001";

        // Act
        var isValid = person.IsValid;

        // Assert
        Assert.True(isValid);
        Assert.Empty(person.BrokenRulesCollection);
    }

    [Fact]
    public void Person_FullName_IsUpdated_WhenFirstOrLastNameChanges()
    {
        // Arrange
        var portal = _serviceProvider.GetRequiredService<IDataPortal<Person>>();
        var person = portal.Create();
        person.FirstName = "Dennis";
        person.LastName = "Mwape";
        person.EmployeeId = "EMP001";

        // Act
        var fullName = person.FullName;

        // Assert
        Assert.Equal("Dennis Mwape", fullName);
    }
}


