namespace VehicleStorage;

public class UI
{
    Validations validations = new();

    public void ShowCreateGarageMeny()
    {
        Clear();

        Console.WriteLine("\t********* MENU *********\n");
        Console.WriteLine(
            "\t1: Create a garage\n" +
            "\t0: Exit");
    }
    public uint GarageSize()  
    {
        uint garageSize = Validations.MakeUInt(Console.ReadLine()!);
        return garageSize;
    }
    public void PrepareLook()
    {
        //Arrange the Console Window
        Console.SetCursorPosition(10, 5);

        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear(); //Paint the background with above color
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Title = "Garage";
        Console.CursorVisible = false;
    }

    internal void ShowGarageMeny()
    {
        //Clear();

        Console.WriteLine("\n\t********* MENU *********\n");
        Console.WriteLine(
            "\t1: Park some dummy Vehicles\n" +
            "\t2: Park new vehicle\n" +
            "\t3: Examine garage\n" +
            "\t4: Unpark vehicles\n" +
            "\t5: Find vehicles\n" +  //Funkar inte ännu
            "\t0: Exit");
    }

    internal void Clear()
    {
        Console.Clear();
    }

    internal void Print(string message)
    {
        Console.WriteLine(message);
    }
}

