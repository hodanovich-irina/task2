using System;
using System.Collections.Generic;
using CarParkLibrary;
using CarParkLibrary.DataWork;
using System.Xml;


namespace ConsoleApp1
{
    class Program
    {           
        static void Main(string[] args)
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            Transport transport = new TruckTractor("MAZ", 678, 2, transport1.ToString());
            Transport transport3 = new TruckTractor("MAZ1", 678, 2, "");
            Refrigerator transport2 = new Refrigerator("Wielton NJ 3", 62, "Milk", "+3 - +5", 6, 2);
            w.Add(transport);
            w.Add(transport1);
            w.Add(transport2);
            w.Add(transport3);
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
            foreach (var v in work.FindСouplingByTypeOfGoods("Бензин"))
                Console.WriteLine(v.Key + " + " + v.Value);
            foreach (var v in work.FindСouplingForAddGoods())
                Console.WriteLine(v);
            Console.WriteLine(work.OpportunitiesOfLogisticiansAddGood((TruckTractor)transport, "Бензин", 1));
            Console.WriteLine(work.OpportunitiesOfLogisticiansMinusGood((TruckTractor)transport, "Бензин", 1));
            Console.WriteLine(work.OpportunitiesOfLogisticiansMinusAllGood((TruckTractor)transport, "Бензин"));
            Console.WriteLine(work.OpportunitiesOfLogisticiansFullAddGood((TruckTractor)transport, "Бензин"));
            StreamParser parser = new StreamParser();
            parser.SaveDocument(parser.LoadDocument( @"../../CarPark.xml"), @"../../CarPark1.xml");
            foreach (var v in work.FuelConsumption())
                Console.WriteLine(v.FuelConsumption);
            Console.WriteLine(work.DeleteSemitrailer((TruckTractor)transport).Semitrailer);
            Console.ReadKey();
        }
    }
}
