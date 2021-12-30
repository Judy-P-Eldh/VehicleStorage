namespace VehicleStorage;

public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    public Car(string regnr, string color, double maxSpeed, string brand, int doors) : base(regnr, color, maxSpeed, brand)
    {
        NumberOfDoors = doors;
    }
    public override string ToString()
    {
        return base.ToString() + $", Number of doors: {NumberOfDoors}";
    }

}
