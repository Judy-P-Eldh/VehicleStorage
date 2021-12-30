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
            if (!RegNrExist(vehicles[i].Regnr))
            {
                garage.ParkVehicles(vehicles[i]);
            }
        }
    }
    //Examine garage
    internal IEnumerable<Vehicle> GetVehicles()  
    {
        return garage.ToList();
    }
    internal bool FullGarage()
    {
        if (garage.IsFull)
        {
            return true;
        }
        return false;
    }

    internal void ParkUserVehicle(Vehicle vehicle/*, string? regnr, string? color, double maxSpeed, string? brand, int doors, int wheels = 0, int engines = 0, int beds = 0, int seats = 0*/)
    {
        //Validate
        if (garage.IsFull)
        {
            Console.WriteLine("Full. Sorry.");  
        }
        else
        {
            garage.ParkVehicles(vehicle);
            Console.WriteLine($"Free spaces left: {garage.Size - garage.Count}");
        }
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
    internal IEnumerable<Vehicle?> Find(string regnr, string color, string brand, string vehicleType)
    {
        IEnumerable<Vehicle> result = garage.ToList();    
                                                         //Något gör att det inte fungerar att söka på annat än regnr
        if (!string.IsNullOrWhiteSpace(regnr))
        {
            Validations.BigLetters(regnr);
            result = result.Where(v => v.Regnr == regnr);
        }
        if (!string.IsNullOrWhiteSpace(color))
        {
            Validations.BigLetters(color);
            result = result.Where(v => v.Color == color);
        }
        if (!string.IsNullOrWhiteSpace(brand))
        {
            Validations.BigLetters(brand);
            result = result.Where(v => v.Brand == brand);
        }
        if (!string.IsNullOrWhiteSpace(vehicleType))
        {
            Validations.BigLetters(vehicleType);
            result = result.Where(v => v.VehicleType == vehicleType);
        }

        return result.ToList(); 
    }
}
