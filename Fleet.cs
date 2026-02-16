using System;
using System.Collections.Generic;

public class Fleet
{
    private List<Vehicle> _vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle v)
    {
        _vehicles.Add(v);
    }

    public bool RemoveVehicle(string model)
    {
        foreach (var v in _vehicles)
        {
            if (v.Model.ToLower() == model.ToLower())
            {
                _vehicles.Remove(v);
                return true;
            }
        }
        return false;
    }

    public double GetAverageMileage()
    {
        if (_vehicles.Count == 0)
            return 0;

        double total = 0;

        foreach (var v in _vehicles)
        {
            total += v.Mileage;
        }

        return total / _vehicles.Count;
    }

    public void DisplayAllVehicles()
    {
        if (_vehicles.Count == 0)
        {
            Console.WriteLine("Fleet is empty.");
            return;
        }

        foreach (var v in _vehicles)
        {
            Console.WriteLine(v.GetSummary());
        }
    }

    public int ServiceAllDue()
    {
        int count = 0;

        foreach (var v in _vehicles)
        {
            if (v.NeedsService())
            {
                v.PerformService();
                count++;
            }
        }

        return count;
    }
}
