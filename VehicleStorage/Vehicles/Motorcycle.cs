namespace VehicleStorage.Vehicles;

public class Motorcycle : Vehicle
{
    public int NumberOfWheels { get; set; }
    public Motorcycle(string regnr, string color, double maxSpeed, string brand, int wheels) : base(regnr, color, maxSpeed, brand)
    {
        NumberOfWheels = wheels;
    }
    public override string ToString()
    {
        return base.ToString() + $", Number of wheels: {NumberOfWheels}";
    }
}
