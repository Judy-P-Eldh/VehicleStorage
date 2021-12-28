namespace VehicleStorage.Vehicles;

internal class Motorcycle : Vehicle
{
    public int NumberOfWheels { get; set; }
    public Motorcycle(string regnr, string color, double maxSpeed, string brand, int wheels) : base(regnr, color, maxSpeed, brand)
    {
        NumberOfWheels = wheels;
    }
    public override string ToString()
    {
        return $"\n\tFacts about this {this.GetType().Name}:\n\t Number of wheels: {NumberOfWheels}, Regnr: {Regnr.ToUpper()}, Color: {Color.ToLower()}" +
            $", Max speed: {MaxSpeed}, Brand: {Brand}";
    }

}
