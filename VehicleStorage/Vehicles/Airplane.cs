namespace VehicleStorage.Vehicles;

public class Airplane : Vehicle
{
    public int NumberOfEngines { get; set; }
    public Airplane(string regnr, string color, double maxSpeed, string brand, int engines) : base(regnr, color, maxSpeed, brand)
    {
        NumberOfEngines = engines;
    }
    public override string ToString()
    {
        return base.ToString() + $", Number of engines: {NumberOfEngines}"; 
    }


}
