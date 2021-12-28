namespace VehicleStorage.Vehicles;

internal class Bus : Vehicle
{
    public int NumberOfSeats { get; set; }
    public Bus(string regnr, string color, double maxSpeed, string brand, int seats) : base(regnr, color, maxSpeed, brand)
    {
        NumberOfSeats = seats;
    }
    public override string ToString()
    {
        return $"\n\tFacts about this {this.GetType().Name}:\n\t Number of seats: {NumberOfSeats}, Regnr: {Regnr.ToUpper()}, Color: {Color.ToLower()}" +
            $", Max speed: {MaxSpeed}, Brand: {Brand}";
    }

}
