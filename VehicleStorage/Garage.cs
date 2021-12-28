using System.Collections;

namespace VehicleStorage;

public class Garage<T> : IEnumerable<T> where T : Vehicle
{
    private T[] vehicles;
    private int count;

    public int Count => count;
    public uint Size { get; }

    public bool IsFull => Count >= Size;  //vehicles.Where(v => v != null).Count() >= Size;
    public Garage(uint size)
    {
        do
        {
            //Validate size

            if (!Validations.ValidateUInt(size))
            {
                Console.WriteLine("Please, enter a number bigger than 0.");
                continue;
            }
            Size = size;
            vehicles = new T[size];
        } while (!true);
    }
    //Create a collection of vehicles
    public bool ParkVehicles(T vehicle)     //Det går att parkera fler än arrayens storlek.
    {
        //Check if spaces left
        //Console.WriteLine(vehicles.Count());
        if (IsFull)
        {
            Console.WriteLine("Full.");
            return false;
        }
        //Add vehicle
        for (uint i = 0; i < Size; i++)
        {
           if(vehicles[i] == default(T))
            {
                vehicles[i] = vehicle;
                count++;
                return true;
            }
        }
        return false;
    }
    public bool UnparkVehicles(T vehicle) //Hur ska regnr komma dit från GarageHandler?
    {
        
        //Check if garage is empty
        Console.WriteLine(vehicles.Count());

        //Remove vehicle
        if (vehicles.Length <= 0)
        {
            Console.WriteLine("No vehicles available.");
        }
        else
        {
            for (uint i = 0; i < Size; i++)
            {
                if (vehicles[i] == vehicle)
                {
                    vehicles[i] = null;
                    count--;    
                    return true;
                }
            }
        }
        return false;
    }
    //public void FindV()
    //{
    //    var v = vehicles.OrderBy(v => v.Brand);
    //    v = v.OrderBy(v => v.Color);
    //    v = v.OrderBy(v => v.Regnr);
    //    v = v.OrderBy(v => v.MaxSpeed);

    //    foreach (var item in vehicles)
    //    {
             
    //    }

    //}

    // Denna definierar vad som händer när vi gör en foreach på ett garage                  
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < vehicles.Length; i++)
        {
                 if(vehicles[i] != null)
                yield return vehicles[i];   
        }
    }

    // Den här bara är 
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
