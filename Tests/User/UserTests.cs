using CarFleetIO.Domain.Consts;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Exceptions;
using CarFleetIO.Domain.ValueObjects;
using Shouldly;
using System;
using Xunit;

public class UserTests
{
    private Username _username = new Username ("jak123");
    private SecurityNumber _secNum = new SecurityNumber (12345678901);
    private Guid _officeId = Guid.NewGuid();
    private Gender _gender = Gender.Male;
    private DateOnly _birthDate = new DateOnly(1990, 1, 1);
    private DateOnly _hireDate = new DateOnly(2015, 1, 1);

    [Fact]
    public void Create_Should_CreateUser_When_DataIsValid()
    {
        var user = User.Create(_username, _secNum, _officeId, _gender, "John", "Doe", _birthDate, _hireDate);

        user.ShouldNotBeNull();
        user.Id.ShouldBe(_username);
        user.IsActive.ShouldBe(true);
    }

    [Fact]
    public void Create_Should_Throw_When_NameIsEmpty()
    {
        Should.Throw<EmptyFirstNameException>(() =>
            User.Create(_username, _secNum, _officeId, _gender, "", "Doe", _birthDate, _hireDate));
    }

    [Fact]
    public void Create_Should_Throw_When_LastNameIsEmpty()
    {
        Should.Throw<EmptyLastNameException>(() =>
            User.Create(_username, _secNum, _officeId, _gender, "John", "", _birthDate, _hireDate));
    }

    [Fact]
    public void Create_Should_Throw_When_HireDateIsInvalid()
    {
        var invalidHireDate = new DateOnly(1940, 1, 1);
        Should.Throw<IncorrectHireDateException>(() =>
            User.Create(_username, _secNum, _officeId, _gender, "John", "Doe", _birthDate, invalidHireDate));
    }

    [Fact]
    public void Create_Should_Throw_When_BirthDateIsInvalid()
    {
        var invalidBirthDate = new DateOnly(1910, 1, 1);
        Should.Throw<IncorrectBirthDateException>(() =>
            User.Create(_username, _secNum, _officeId, _gender, "John", "Doe", invalidBirthDate, _hireDate));
    }

    [Fact]
    public void Activate_Should_Throw_If_AlreadyActive()
    {
        var user = User.Create(_username, _secNum, _officeId, _gender, "John", "Doe", _birthDate, _hireDate);
        Should.Throw<UserAlreadyActiveException>(() => user.Activate());
    }

    [Fact]
    public void Deactivate_Should_Throw_If_AlreadyInactive()
    {
        var user = User.Create(_username, _secNum, _officeId, _gender, "John", "Doe", _birthDate, _hireDate);
        user.Deactivate();
        Should.Throw<UserAlreadyDeactivatedException>(() => user.Deactivate());
    }

    [Fact]
    public void ChangeOffice_Should_Throw_When_NewOfficeIsSame()
    {
        var user = User.Create(_username, _secNum, _officeId, _gender, "John", "Doe", _birthDate, _hireDate);
        Should.Throw<NewOfficeSameAsOldException>(() => user.ChangeOffice(_officeId));
    }

    [Fact]
    public void ChangeLastName_Should_Throw_When_Empty()
    {
        var user = User.Create(_username, _secNum, _officeId, _gender, "John", "Doe", _birthDate, _hireDate);
        Should.Throw<ArgumentException>(() => user.ChangeLastName(""));
    }

    [Fact]
    public void ChangeLastName_Should_ChangeValue()
    {
        var user = User.Create(_username, _secNum, _officeId, _gender, "John", "Doe", _birthDate, _hireDate);
        user.ChangeLastName("Szczaw");
      
    }
}
