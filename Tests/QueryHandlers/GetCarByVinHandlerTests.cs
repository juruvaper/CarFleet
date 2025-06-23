/*using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.Models;
using CarFleetIO.Infrastructure.EF.Queries.Handlers;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

public class GetCarByVinHandlerTests
{
    private ReadDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ReadDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new ReadDbContext(options);
    }

    [Fact]
    public async Task HandleAsync_Should_Return_CarDTO_When_Vin_Exists()
    {
        // Arrange
        await using var context = CreateContext();

        var car = new CarReadModel
        {
            Id = Guid.NewGuid(),
            VIN = "VIN123456789",
            User = new UserReadModel { Id = Guid.NewGuid(), Username = "testuser" }
        };

        context.Cars.Add(car);
        await context.SaveChangesAsync();

        var handler = new GetCarByVinHandler(context);
        var query = new GetCarByVin(car.VIN);

        // Act
        var result = await handler.HandleAsync(query);

        // Assert
        result.ShouldNotBeNull();
        result.VIN.ShouldBe(car.VIN);
        result.UserUsername.ShouldBe("testuser"); // zakładając, że AsDto() mapuje User.Username do UserUsername
    }

    [Fact]
    public async Task HandleAsync_Should_Return_Null_When_Vin_Not_Found()
    {
        // Arrange
        await using var context = CreateContext();
        var handler = new GetCarByVinHandler(context);
        var query = new GetCarByVin("NON_EXISTENT_VIN");

        // Act
        var result = await handler.HandleAsync(query);

        // Assert
        result.ShouldBeNull();
    }
}
*/