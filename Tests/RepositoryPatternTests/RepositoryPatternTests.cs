using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.Repositories;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using CarFleetIO.Domain.Consts;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

public class PostgresUserRepositoryTests
{
    private WriteDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<WriteDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // unikalna baza dla każdego testu
            .Options;

        return new WriteDbContext(options);
    }

    private User CreateTestUser()
    {
          
            var user = User.Create(
            new Username("moj123"),
            new SecurityNumber(12345678901),
            Guid.NewGuid(),
            CarFleetIO.Domain.Consts.Gender.Male,
            "Jan",
            "Kowalski",
            new DateOnly(1980, 5, 1),
            new DateOnly(2010, 1, 1),
            true);

            user.IdentityId = Guid.NewGuid().ToString();

        return user;
    }

    [Fact]
    public async Task AddAsync_Should_Add_User_To_Database()
    {
        // Arrange
        await using var context = CreateContext();
        var repo = new PostgresUserRepository(context);
        var user = CreateTestUser();

        // Act
        await repo.AddAsync(user);

        // Assert
        var savedUser = await context.Users.FindAsync(user.Id);
        savedUser.ShouldNotBeNull();
        savedUser.Id.ShouldBe(user.Id);
        savedUser.ShouldBeOfType<User>();
    }

    [Fact]
    public async Task GetAsync_Should_Return_User_When_Found()
    {
        // Arrange
        await using var context = CreateContext();
        var repo = new PostgresUserRepository(context);
        var user = CreateTestUser();

        context.Users.Add(user);
        await context.SaveChangesAsync();

        // Act
        var foundUser = await repo.GetAsync(user.Id);

        // Assert
        foundUser.ShouldNotBeNull();
        foundUser.Id.ShouldBe(user.Id);
    }

    [Fact]
    public async Task GetAsync_Should_Return_Null_When_Not_Found()
    {
        // Arrange
        await using var context = CreateContext();
        var repo = new PostgresUserRepository(context);

        // Act
        var foundUser = await repo.GetAsync(new Username("tes123"));

        // Assert
        foundUser.ShouldBeNull();
    }

    [Fact]
    public async Task DeleteAsync_Should_Remove_User_From_Database()
    {
        // Arrange
        await using var context = CreateContext();
        var repo = new PostgresUserRepository(context);
        var user = CreateTestUser();

        context.Users.Add(user);
        await context.SaveChangesAsync();

        // Act
        await repo.DeleteAsync(user);

        // Assert
        var deletedUser = await context.Users.FindAsync(user.Id);
        deletedUser.ShouldBeNull();
    }

    [Fact]
    public async Task UpdateAsync_Should_Update_User_In_Database()
    {
        // Arrange
        await using var context = CreateContext();
        var repo = new PostgresUserRepository(context);
        var user = CreateTestUser();

        context.Users.Add(user);
        await context.SaveChangesAsync();

        // Change user's last name
        user.ChangeLastName("Nowak");

        // Act
        await repo.UpdateAsync(user);

        // Assert
        var updatedUser = await context.Users.FindAsync(user.Id);
        updatedUser._lastName.ShouldBe("Nowak");
    }
}
