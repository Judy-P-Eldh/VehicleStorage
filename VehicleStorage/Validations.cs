using System.Diagnostics.CodeAnalysis;

namespace VehicleStorage;

public class Validations
{
    //Make uint
    public static uint MakeUInt(string input)
    {
        if (uint.TryParse(input, out uint result))
        {

        }

        return result;
    }
    //Make int
    public static int MakeInt(string input)
    {
        if (int.TryParse(input, out int result))
        {

        }

        return result;
    }
    //Make double
    public static double MakeDouble(string input)
    {
        if (double.TryParse(input, out double result))
        {

        }

        return result;
    }
    //Check if null
    public static bool CheckString(string value)
    {
        bool hasValue = !string.IsNullOrWhiteSpace(value);
        if (hasValue == false)
        {
            throw new ArgumentNullException(paramName: nameof(value), message: "Cannot be null.");
            Console.ReadKey();
        }
        return hasValue;
    }
    public static double ValidateDouble(double value)
    {
        if (double.IsNaN(value) || value <= 0)
        {
            throw new ArgumentException("Must be a number bigger than 0.");
        }
        else
        {
            return value;
        }
    }
    public static bool ValidateUInt(uint value)
    {
        var isValid = true;

        if (value <= 0)
        {
            return false;
        }
        else
        {
            return isValid;
        }
    }
    public static bool ValidateInt(int value)
    {
        var isValid = true;

        if (value <= 0)
        {
            return false;
        }
        else
        {
            return isValid;
        }
    }
    //Check navigation input
    public static char NavTryCatch()
    {
        char input = ' '; //Creates the character input to be used with the switch-case below.
        try
        {
            input = Console.ReadKey(intercept: true).KeyChar;
        }
        catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
        {
            Console.Clear();
            Console.WriteLine("Please enter some input!");
        }
        return input;
    }
    //Big and small letters
    public static string Letters(string value)
    {
        var first = value.First().ToString().ToUpper();
        var last = value.Substring(1).ToLower();
        var newValue = first + last;
        //Console.WriteLine(newValue); //Här funkar det.
        return newValue;
    }
    public static string BigLetters(string value)
    {
        value = value.ToUpper();
        return value;
    }
       
    //Chek Vehicle search parameters
    public static void ValidateObject<T>(string regnr, string color, double maxSpeed, string brand, int doors, int wheels, int beds, int engines, int seats)
    {

        
    }
}
