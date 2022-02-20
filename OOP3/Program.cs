using System;
using System.Collections.Generic;
using System.Linq;

public class BasicVehicle
{
    protected string Name;
    private double CostOfRentPerHour;

    public BasicVehicle(string InName, double InCostOfRentPerHour)
    {
        Name = InName;
        CostOfRentPerHour = InCostOfRentPerHour;
    }

    public double GetCostOfRent(double DeltaTime)
    { 
        return CostOfRentPerHour * DeltaTime;
    }
    
    public void PrintCostOfRent(double DeltaTime)
    {
        Console.WriteLine(Name + "\t" + GetCostOfRent(DeltaTime) + "\n");
    }
}

public class Bus : BasicVehicle
{
    int Passengers;
    int Places;

    double AddedCost;

    public Bus(string InName, double InCostOfRentPerHour, int InPassengers, int InPlaces) : base(InName, InCostOfRentPerHour)
    {
        Passengers = InPassengers;
        Places = InPlaces;
        double Ratio = (double) Passengers / Places;

        if (Ratio <= 0.3)
        {
            AddedCost = 2000;
        }
        else if (Ratio <= 0.5)
        {
            AddedCost = 3500;
        }
        else
        {
            AddedCost = 4500;
        }
    }

    public void PrintCostOfRent(double DeltaTime)
    {
        Console.WriteLine(Name + "\t" + (base.GetCostOfRent(DeltaTime) + AddedCost) + "\n");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BasicVehicle bv = new BasicVehicle("Камаз", 1000);
        bv.PrintCostOfRent(10);

        Bus b = new Bus("ПАЗ", 1000, 3, 5);
        b.PrintCostOfRent(10);
    }
}