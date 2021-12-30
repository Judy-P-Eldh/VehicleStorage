using System.Collections.Generic;
using System.Linq;
using VehicleStorage;
using Xunit;

namespace GarageTest;

public class GaragePossibilities
{
    [Fact]
    public void CreateGarageTestMethod()
    {
        //Arrange
        uint testSize = 2;

        //Act
        var testGarage = new Garage<Vehicle>(0);

        //Assert
        Assert.NotEqual(testSize, testGarage.Size);
    }
    [Fact]
    public void ParkVehiclesTestMethod()
    {
        //Arrange
        int expected = 1;
        var testGarage = new Garage<Vehicle>(2);
        var vehicle = new Car("CAR111", "Black", 100.0, "Lexus", 4);

        //Act
        testGarage.ParkVehicles(vehicle);
        var actual = testGarage.Count;

        //Assert
        Assert.Equal(expected,actual);
    }
    [Fact]
    public void UnparkTestMethod()
    {
        //Arrange
        int expected = 0;
        var testGarage = new Garage<Vehicle>(2);
        var vehicle = new Car("CAR111", "Black", 100.0, "Lexus", 4);

        //Act
        testGarage.UnparkVehicles(vehicle);
        var actual = testGarage.Count;

        //Assert
        Assert.Equal(expected, actual);
    }
}
