namespace VehicleStorage.Vehicles;

internal class Airplane : Vehicle
{
    public int NumberOfEngines { get; set; }
    public Airplane(string regnr, string color, double maxSpeed, string brand, int engines) : base(regnr, color, maxSpeed, brand)
    {
        NumberOfEngines = engines;
    }
    public override string ToString()
    {
        return $"\n\tFacts about this {this.GetType().Name}:\n\t Number of engines: {NumberOfEngines}, Regnr: {Regnr.ToUpper()}, Color: {Color.ToLower()}" +
            $", Max speed: {MaxSpeed}, Brand: {Brand}";
    }


}
