using VehicleStorage.Vehicles;

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
            case '6':
                //Search
                handler.GarageStats();
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
        if (handler.FullGarage())
        {
            ui.Print("Sorry, no space available.");
        }
        else
        {
            ui.Print("Park vehicle");
            ui.Print("1. Car");
            ui.Print("2. Boat");
            ui.Print("3. Airplane");
            ui.Print("4. Bus");
            ui.Print("5. Motorcycle");

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
    }
    private void Park(string vehicleType)
    {
        //Collect common parameters (Vehicle)

        ui.Print("Provide the facts about your vehicle.");

        //Regnr
        string regnr;
        
        RegNoAlreadyExist(out regnr, out bool notValidRegNo);

        //Color
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

        //Max Speed
        ui.Print("Maximum speed?");
        double maxSpeed = Validations.MakeDouble(Console.ReadLine());

        if (maxSpeed <= 0)
        {
            ui.Print("Consider repair for your vehicle.");
        }

        //Brand
        ui.Print("The brand?");
        string brand = Console.ReadLine();
        bool invalidString = string.IsNullOrWhiteSpace(brand);
        do
        {
            if (invalidString)
                ui.Print("Not a valid input. Try again.");

        } while (invalidString);
        Validations.Letters(brand);

        //Switch
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
                handler.ParkUserVehicle(new Car (regnr, color, maxSpeed, brand, doors));
                //Print message
                MessageParkedVehicle();
                break;
            case "Boat":
                //Collect boat parameters
                ui.Print("Number of beds?");
                int beds = Validations.MakeInt(Console.ReadLine());
                if (beds < 0)
                {
                    beds = 0;
                }

                handler.ParkUserVehicle(new Boat(regnr, color, maxSpeed, brand, beds));
                //Print message
                MessageParkedVehicle();
                break;
            case "Airplane":
                //Collect airplane parameters
                ui.Print("Number of engines?");
                int engines = Validations.MakeInt(Console.ReadLine());
                if (engines < 0)
                {
                    engines = 0;
                    ui.Print("Consider repair for your airplaine.");
                }

                handler.ParkUserVehicle(new Airplane(regnr, color, maxSpeed, brand, engines));
                //Print message
                MessageParkedVehicle();
                break;
            case "Bus":
                //Collect bus parameters
                ui.Print("Number of seats?");
                int seats = Validations.MakeInt(Console.ReadLine());
                if (seats < 0)
                {
                    seats = 0;
                    ui.Print("No passangers for you. Consider repair for your bus.");
                }

                handler.ParkUserVehicle(new Bus(regnr, color, maxSpeed, brand, seats));
                //Print message
                MessageParkedVehicle();
                break;
            case "Motorcycle":
                //Collect motorcycle parameters
                ui.Print("Number of wheels?");
                int wheels = Validations.MakeInt(Console.ReadLine());  
                if (wheels < 2)
                {
                    ui.Print("Consider repair for your motorcycle.");
                }

                handler.ParkUserVehicle(new Motorcycle(regnr, color, maxSpeed, brand, wheels));
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
        ui.Print("\nSearch by reg number");
        string regNo = Console.ReadLine().ToUpper(); ;            
        
        ui.Print("\nSearch by color");
        string color = Console.ReadLine().ToUpper();

        ui.Print("\nSearch by brand");
        string brand = Console.ReadLine().ToUpper();

        ui.Print("\nSearch by type");
        string vehicleType = Console.ReadLine().ToUpper();

        var result = handler.Find(regNo, color, brand, vehicleType);

        if (result != null)     //Det funkar bara att söka på regnr, men jag vet inte varför.  
        {
            foreach (var vehicle in result)
            {
                ui.Print("Found: " + vehicle.ToString());
            }
        }
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
