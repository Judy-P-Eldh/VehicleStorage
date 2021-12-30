namespace VehicleStorage.Vehicles;

public class Boat : Vehicle
{
    public int NumberOfBeds { get; set; }
    public Boat(string regnr, string color, double maxSpeed, string brand, int beds) : base(regnr, color, maxSpeed, brand)
    {
        NumberOfBeds = beds;
    }
    public override string ToString()
    {
        return base.ToString() + $", Number of beds: {NumberOfBeds}";
    }

}
