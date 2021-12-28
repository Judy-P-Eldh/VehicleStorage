using System;
using VehicleStorage.Vehicles;

namespace VehicleStorage;

internal class GarageHandler
{
    private Garage<Vehicle> garage = null!;

    public void CreateGarage(uint garageSize)
    {

        garage = new Garage<Vehicle>(garageSize);

    }
    public void DummyContent()  //Ska kunna läggas till i arrayen i Garage från start.
    {
        var vehicles = new List<Vehicle>()
        {
            new Car("ABC123", "Black", 285, "Volvo", 4),
            new Car("APA111", "blue", 450, "Bugatti", 2),
            new Motorcycle("VAL999", "red", 385, "Ducati", 2),
            new Motorcycle("BAL000", "orange", 155, "Honda", 3 ),                                        
            new Airplane("HEL888", "blue", 500, "HKP", 1),
            new Airplane("LER777", "white", 9000, "AirBus", 4),
            new Boat("ARM555", "white", 150, "Bavaria", 7),
            new Boat("BEN444", "green", 400, "Nimbus", 3),
            new Bus("ERT333", "blue", 120, "Volvo", 18),
            new Bus("RIS222", "yellow", 180, "Scania", 30),
        };

        for (int i = 0; i < garage.Size -2; i++)
        {
            garage.ParkVehicles(vehicles[i]);
        }
    }
    //Examine garage
    internal IEnumerable<Vehicle> GetVehicles()  
    {
        return garage.ToList();
    }

    internal void ParkUserVehicle(string? regnr, string? color, double maxSpeed, string? brand, int doors)
    {
        //Validate
           var userCar = new Car(regnr, color, maxSpeed, brand, doors);
           garage.ParkVehicles(userCar);
    }

    internal string Unpark(string regNo)
    {
        var vehicleToUnpark = FindByRegNo(regNo);
        if (vehicleToUnpark != null)
        {
            if (garage.UnparkVehicles(vehicleToUnpark))
                return $"Vehicle {vehicleToUnpark.Regnr} successfully unparked";
            else
          return $"Failed to unpark {regNo}";

        }
        return $"Failed to unpark {regNo}";
    }

    internal Vehicle? FindByRegNo(string? input)
    {
        return garage.FirstOrDefault(v => v.Regnr == input?.ToUpper());
    }
    internal bool RegNrExist(string input)
    {
        //Ver 2
        return  garage.Any(v => v.Regnr == input);
    }

    //Funkar inte. Hur ska alla parametrarna komma in?
    internal IEnumerable<Vehicle?> Find(string regnr, string color, double maxSpeed, string brand, int doors, int wheels, int beds, int engines, int seats)//(SearchParams searchParams)
    {
        IEnumerable<Vehicle> result = garage.ToList();
        if (regnr != null && regnr != " ")
        {
            Validations.BigLetters(regnr);
            result = result.Where(v => v.Regnr == regnr);
        }
        if (color != null && color != " ")
        {
            Validations.BigLetters(color);
            result = result.Where(v => v.Color == color);
        }
        if ((maxSpeed != 0) && (maxSpeed != double.NaN))
        {
            result = result.Where(v => v.MaxSpeed == maxSpeed);
        }
        if (brand != null && brand != " ")
        {
            Validations.BigLetters(brand);
            result = result.Where(v => v.Brand == brand);
        }
        if (wheels != 0)
        {
           
        }

        return result.ToList();
    }
}
