namespace VehicleStorage.Vehicles;

public class Bus : Vehicle
{
    public int NumberOfSeats { get; set; }
    public Bus(string regnr, string color, double maxSpeed, string brand, int seats) : base(regnr, color, maxSpeed, brand)
    {
        NumberOfSeats = seats;
    }
    public override string ToString()
    {
        return base.ToString() + $", Number of seats: {NumberOfSeats}";
    }

}
