namespace VehicleStorage;

public abstract class Vehicle
{
    private string regnr;
    private double maxSpeed;
    private string color;
    private string brand;

    public string Regnr 
    { 
        get { return regnr; } 
        set 
        {
            Validations.BigLetters(value);
            regnr = value; 
        } 
    }

    public double MaxSpeed
    {
        get { return maxSpeed; }
        set 
        {
            Validations.ValidateDouble(value);
            maxSpeed = value; 
        }
    }

    public string  Color 
    { 
        get { return color; }
        set 
        {
            Validations.CheckString(value);
            color = value;
        }
    }
    public string Brand 
    { 
        get { return brand; }
        set 
        { 
            Validations.CheckString(value);
            brand = value;
        }
    }

    public Vehicle(string regnr, string color, double maxSpeed, string brand)
    {
        Regnr = regnr;
        Color = color;
        MaxSpeed = maxSpeed;
        Brand = brand;
    }


    public override string ToString()
    {
        return $"\n\tVehicle type {this.GetType().Name}";
    }

}
