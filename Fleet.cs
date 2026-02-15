using System;
using System.Collections.Generic;
using System.Linq;

public class Fleet
{
    // Private field
    private List<Vehicle> _vehicles;

    // Constructor
    public Fleet()
    {
        _vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle v)
    {
        _vehicles.Add(v);
    }

    public bool RemoveVehicle(string model)
    {
        var vehicle = _vehicles.FirstOrDefault(v =>
            v.Model.Equals(model, StringComparison.OrdinalIgnoreCase));

        if (vehicle != null)
        {
            _vehicles.Remove(vehicle);
            return true;
        }

        return false;
    }

    public double GetAverageMileage()
    {
        if (_vehicles.Count == 0)
            return 0;

        return _vehicles.Average(v => v.Mileage);
    }

    public void DisplayAllVehicles()
    {
        if (_vehicles.Count == 0)
        {
            Console.WriteLine("Fleet is empty.");
            return;
        }

        foreach (var vehicle in _vehicles)
        {
            Console.WriteLine(vehicle.GetSummary());
        }
    }

    public int ServiceAllDue()
    {
        int servicedCount = 0;

        foreach (var vehicle in _vehicles)
        {
            if (vehicle.NeedsService())
            {
                vehicle.PerformService();
                servicedCount++;
            }
        }

        return servicedCount;
    }
}
