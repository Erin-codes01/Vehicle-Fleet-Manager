using System;

class Program
{
    static void Main()
    {
        Fleet fleet = new Fleet();
        bool running = true;

        while (running)
        {
            // Display Menu
            Console.WriteLine("\n=== Vehicle Fleet Manager App ===");
            Console.WriteLine("1. Add A Vehicle");
            Console.WriteLine("2. Remove A Vehicle");
            Console.WriteLine("3. Display A Fleet");
            Console.WriteLine("4. Show The Average Mileage");
            Console.WriteLine("5. Service Due On A Vehicles");
            Console.WriteLine("6. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddVehicle(fleet);
                    break;

                case "2":
                    RemoveVehicle(fleet);
                    break;

                case "3":
                    fleet.DisplayAllVehicles();
                    break;

                case "4":
                    Console.WriteLine($"Average Mileage: {fleet.GetAverageMileage():F2}");
                    break;

                case "5":
                    int serviced = fleet.ServiceAllDue();
                    Console.WriteLine($"{serviced} vehicle(s) serviced.");
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Exiting The program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void AddVehicle(Fleet fleet)
    {
        Console.Write("Enter A Make: ");
        string make = Console.ReadLine();

        Console.Write("Enter A Model: ");
        string model = Console.ReadLine();

        int year;
        while (true)
        {
            Console.Write("Enter A Year: ");
            if (int.TryParse(Console.ReadLine(), out year))
                break;
            Console.WriteLine("Invalid year. Try again.");
        }

        double mileage;
        while (true)
        {
            Console.Write("Enter Mileage Amount: ");
            if (double.TryParse(Console.ReadLine(), out mileage) && mileage >= 0)
                break;
            Console.WriteLine("Invalid mileage. Try again.");
        }

        Vehicle v = new Vehicle(make, model, year, mileage);
        fleet.AddVehicle(v);

        Console.WriteLine("Vehicle Added!");
    }

    static void RemoveVehicle(Fleet fleet)
    {
        Console.Write("Enter A Model To Remove: ");
        string model = Console.ReadLine();

        if (fleet.RemoveVehicle(model))
            Console.WriteLine("Vehicle Removed.");
        else
            Console.WriteLine("Vehicle Was Not Found.");
    }
}

