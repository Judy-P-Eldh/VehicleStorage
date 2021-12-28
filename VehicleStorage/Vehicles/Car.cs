namespace VehicleStorage;

internal class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    public Car(string regnr, string color, double maxSpeed, string brand, int doors) : base(regnr, color, maxSpeed, brand)
    {
        NumberOfDoors = doors;
    }
    public override string ToString()
    {
        return $"\n\tFacts about this {this.GetType().Name}:\n\t Number of doors: {NumberOfDoors}, Regnr: {Regnr.ToUpper()}, Color: {Color.ToLower()}" +
            $", Max speed: {MaxSpeed}, Brand: {Brand}";
    }

}
