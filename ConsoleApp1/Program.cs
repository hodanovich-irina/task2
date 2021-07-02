using System;
using System.Collections.Generic;
using CarParkLibrary;
using CarParkLibrary.DataWork;


namespace ConsoleApp1
{
    class Program
    {           
        static void Main(string[] args)
        {
            List<Transport> w = new List<Transport>();
            Transport transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 7, 10, ViewFuel.AI92);
            Transport transport = new TruckTractor("MAZ", 678, 2/*, new[] { transport1 }*/);
            Transport transport2 = new Refrigerator("Wielton NJ 3", 62, "Молоко", "+3 - +5", 6, 2);
            w.Add(transport);
            w.Add(transport1);
            w.Add(transport2);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            //SaxParser.SaxParsing(@"../../CarPark.xml");
            var x = SaxParser.SaxParsing(@"../../CarPark.xml");
            foreach (var x1 in x)
                Console.WriteLine(x1.ToString());
            //Transport transport = new TruckTractor() { Name = "Минск", MaxMass = };  
            ListWork work = new ListWork();
            foreach (var v in work.FindSemitrailerByType("tank truck")) 
                Console.WriteLine(v.ToString());
            foreach (var v in work.FindSemitrailerByCharacteristics("Wielton NJ 3", 62, "Молоко", "+3 - +5", 6, 2))
                Console.WriteLine(v.ToString());
            Console.ReadKey();
        }
    }
}
