namespace VehicleStorage.Vehicles;

internal class Boat : Vehicle
{
    public int NumberOfBeds { get; set; }
    public Boat(string regnr, string color, double maxSpeed, string brand, int beds) : base(regnr, color, maxSpeed, brand)
    {
        NumberOfBeds = beds;
    }
    public override string ToString()
    {
        return $"\n\tFacts about this {this.GetType().Name}:\n\t Number of beds: {NumberOfBeds}, Regnr: {Regnr.ToUpper()}, Color: {Color.ToLower()}" +
            $", Max speed: {MaxSpeed}, Brand: {Brand}";
    }

}
