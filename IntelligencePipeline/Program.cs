using System;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            DroneReport d = new DroneReport(new DateTime(2025, 12, 12), 50000, 6542, "just creating test", 45621, 15);
            DroneReport d1 = new DroneReport(new DateTime(2025, 12, 12), 50000, 6542, "just creating test", 45621, 15);
            DroneReport d2 = new DroneReport(new DateTime(2025, 12, 12), 50000, 6542, "just creating test", 45621, 15);
            SoldierReport s1 = new SoldierReport(new DateTime(2025, 12, 12), 50000, 6542, "just creating test", "ron", "1235", "8200", 5);
            System.Console.WriteLine(s1.ToString());
            
        }
    }
}