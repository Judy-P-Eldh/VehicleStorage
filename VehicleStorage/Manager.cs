namespace VehicleStorage;

public class Manager
{
    private UI ui; // = new UI();
    private GarageHandler handler;

    public Manager()
    {
        ui = new UI();
        handler = new GarageHandler();
    }

    internal void Run()
    {
        Initialize();
        do
        {
            MainApp();

        } while (true);
    }

    private void MainApp()
    {
        ui.ShowGarageMeny();
        char input = Validations.NavTryCatch(); //Creates the character input to be used with the switch-case below.

        switch (input)
        {
            case '1':
                handler.DummyContent();
                break;
            case '2':
                //Parking by user
                UserParking();
                break;
            case '3':
                //Examine garage
                PrintVehicles();
                break;
            case '4':
                //Unpark
                Console.WriteLine("RegNo?");
                var regNo = Console.ReadLine();
                var message = handler.Unpark(regNo);
                Console.WriteLine(message);
                break;
            case '5':
                //Search
                Search();
                break;
            case '0':
                Environment.Exit(0);
                break;
            default:
                ui.Print("Please enter some valid input (3, 4, 0)");
                Console.ReadKey();
                break;
        }
    }
    private void UserParking()
    {
        Console.WriteLine("Park vehicle");
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Boat");
        Console.WriteLine("3. Airplane");
        Console.WriteLine("4. Bus");
        Console.WriteLine("5. Motorcycle");

        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                //Park Car
                Park("Car");
                break;
            case "2":
                //Park Boat
                Park("Boat");
                break;
            case "3":
                //Park Airplane
                Park("Airplane");
                break;
            case "4":
                //Park Bus
                Park("Bus");
                break;
            case "5":
                //Park Motorcycle
                Park("Motorcycle");
                break;
            default:
                break;
        }
    }
    private void Park(string vehicleType)
    {
        //Collect common parameters (Vehicle)

        ui.Print("Provide the facts about your vehicle.");
        string regnr;

        bool notValidRegNo;
        RegNoAlreadyExist(out regnr, out notValidRegNo);

        bool notValidString;
        string color;
        do
        {
            ui.Print("Color?");
            color = Console.ReadLine();
            notValidString = string.IsNullOrWhiteSpace(color);
            if (notValidString)
            {
                ui.Print("Not a valid input. Try again.");
            }
        } while (notValidString);
        color.ToLower();

        ui.Print("Maximum speed?");
        double maxSpeed = Validations.MakeDouble(Console.ReadLine());

        if (maxSpeed <= 0)
        {
            ui.Print("Consider repair for your vehicle.");
        }

        ui.Print("The brand?");
        string brand = Console.ReadLine();
        bool invalidString = string.IsNullOrWhiteSpace(brand);
        do
        {
            if (invalidString)
                ui.Print("Not a valid input. Try again.");

        } while (invalidString);
        Validations.Letters(brand);

        switch (vehicleType)
        {
            case "Car":
                //Collect car parameters
                int doors;
                do
                {
                    ui.Print("Number of doors?");
                    doors = Validations.MakeInt(Console.ReadLine());
                    if (doors <= 0)
                    {
                        ui.Print("Enter a number bigger than 0.");
                    }
                } while (doors <= 0);
                //Send car to handler.Park 
                handler.ParkUserVehicle(regnr, color, maxSpeed, brand, doors);
                //Print message
                MessageParkedVehicle();
                break;
            case "Boat":
                //Collect boat parameters
                int beds = Validations.MakeInt(Console.ReadLine());
                ui.Print("Number of beds?");
                if (beds < 0)
                {
                    beds = 0;
                }

                handler.ParkUserVehicle(regnr, color, maxSpeed, brand, beds);
                //Print message
                MessageParkedVehicle();
                break;
            case "Airplane":
                //Collect airplane parameters
                int engines = Validations.MakeInt(Console.ReadLine());
                ui.Print("Number of engines?");
                if (engines < 0)
                {
                    engines = 0;
                    ui.Print("Consider repair for your airplaine.");
                }

                handler.ParkUserVehicle(regnr, color, maxSpeed, brand, engines);
                //Print message
                MessageParkedVehicle();
                break;
            case "Bus":
                //Collect bus parameters
                int seats = Validations.MakeInt(Console.ReadLine());
                ui.Print("Number of seats?");
                if (seats < 0)
                {
                    seats = 0;
                    ui.Print("No passangers for you. Consider repair for your bus.");
                }

                handler.ParkUserVehicle(regnr, color, maxSpeed, brand, seats);
                //Print message
                MessageParkedVehicle();
                break;
            case "Motorcycle":
                //Collect motorcycle parameters
                int wheels = Validations.MakeInt(Console.ReadLine());
                ui.Print("Number of wheels?");
                if (wheels < 2)
                    ui.Print("Consider repair for your motorcycle.");

                handler.ParkUserVehicle(regnr, color, maxSpeed, brand, wheels);
                //Print message
                MessageParkedVehicle();
                break;
            default:
                break;
        }
    }

    private void MessageParkedVehicle()
    {
        ui.Print($"Your vehicle is parked.");
        Console.ReadKey();
    }

    private void RegNoAlreadyExist(out string regnr, out bool notValidRegNo)
    {
        do
        {
            ui.Print("RegNo?");
            regnr = Console.ReadLine();
            notValidRegNo = string.IsNullOrWhiteSpace(regnr);
            if (notValidRegNo)
            {
                ui.Print("Not valid Reg number. Try again.");
            }
            notValidRegNo = handler.RegNrExist(regnr.ToUpper());
            if (notValidRegNo)
            {
                ui.Print("Reg number needs to be unique. Try again.");
            }

        } while (notValidRegNo);
    }

    private void Search()
    {
        ui.Print("\nSearch by regnr, color, brand or max speed:");
        var input = Console.ReadLine();

        var result = handler.FindByRegNo(input);

        if (result != null)
            ui.Print(result.ToString());
        else
        {
            ui.Print("Not found");
        }
        Console.ReadKey();
    }

    private void PrintVehicles()
    {
        var vehicles = handler.GetVehicles();
        foreach (var vehicle in vehicles)
        {
            ui.Print(vehicle.ToString());
        }
        Console.ReadKey();
    }

    internal bool Initialize()
    {
        bool success = false;
        do
        {
            ui.PrepareLook();
            ui.ShowCreateGarageMeny();
            char input = Validations.NavTryCatch();

            switch (input)
            {
                case '1':
                    uint garageSize;
                    do
                    {
                        ui.Print("How many vehicles do you want to store?");
                        garageSize = ui.GarageSize();
                        if (garageSize <= 0)
                        {
                            ui.Print($"Your garage needs more than {garageSize} spaces. Pease, try again.");

                        }
                    } while (garageSize <= 0);

                    handler.CreateGarage(garageSize);
                    ui.Print($"You created a garage with {garageSize} spaces.");
                    success = true;
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    ui.Print("Please enter some valid input (1, 0)");
                    Console.ReadKey();
                    break;
            }

        } while (!success);
        return success;
    }
}
