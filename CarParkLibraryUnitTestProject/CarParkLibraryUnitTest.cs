using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParkLibrary;
using CarParkLibrary.DataWork;
using System.Collections.Generic;


namespace CarParkLibraryUnitTestProject
{
    /// <summary>
    /// Class for testing CarParkLibrary
    /// </summary>
    [TestClass]
    public class CarParkLibraryUnitTest
    {
        /// <summary>
        /// Test for Equals() Refrigerator
        /// </summary>
        [TestMethod]
        public void TestEqualsRefrigerator()
        {
            Refrigerator transport = new Refrigerator("Wielton NJ 3", 62, "Milk", "+3 - +5", 6, 2);
            Refrigerator transport1 = new Refrigerator("Wielton NJ 3", 63, "Milk", "+3 - +5", 6, 2);

            var actual = transport.Equals(transport1);
            Assert.IsFalse(actual);

        }

        /// <summary>
        /// Test for Equals() transport
        /// </summary>
        [TestMethod]
        public void TestEqualsTransport()
        {
            Transport transport = new TruckTractor("MAZ", 67, 2, "");
            Transport transport1 = new TruckTractor("MAZ", 67, 2, "");
            var actual = transport.Equals(transport1);
            Assert.IsTrue(actual);
        }
        /// <summary>
        /// Test for GetHashCode() TruckTractor
        /// </summary>
        [TestMethod]
        public void TestToGetHashCodeTruckTractor()
        {
            Transport transport = new TruckTractor("MAZ", 678, 2, "");
            var actual = transport.GetHashCode();
            Assert.AreEqual(-581893210, actual);
        }
        /// <summary>
        /// Testing TruckTractor method ToString()
        /// </summary>
        [TestMethod]
        public void TestMethodTruckTractorToString()
        {
            Transport transport = new TruckTractor("MAZ", 67, 2, "");
            var actual = transport.ToString();
            var except = "MAZ(67)";
            Assert.AreEqual(except, actual);

        }
        /// <summary>
        /// Testing Method AddInXml and SaxParsing
        /// </summary>
        [TestMethod]
        public void TestMethodAddInXmlAndSaxParsing()
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            TruckTractor transport = new TruckTractor("MAZ", 40, 10, transport1.ToString());
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, "");
            Refrigerator transport2 = new Refrigerator("Wielton NJ 3", 66, "Молоко", "+3 - +5", 6, 2);            
            TruckTractor transport4 = new TruckTractor("Ford", 33, 8, transport2.ToString());
            TruckTractor transport5 = new TruckTractor("Scania", 55, 10, transport3.ToString());
            Refrigerator transport6 = new Refrigerator("Montracon", 32, "Рыба", "-15 - -25", 10, 12);
            w.Add(transport);
            w.Add(transport1);
            w.Add(transport2);
            w.Add(transport3);
            w.Add(transport4);
            w.Add(transport5);
            w.Add(transport6);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            var x = SaxParser.SaxParsing(@"../../CarPark.xml");
            CollectionAssert.AreEqual(x, w);
        }

        /// <summary>
        /// Testing Method LoadDocument and SaveDocument
        /// </summary>
        [TestMethod]
        public void TestMethodLoadDocumentAndSaveDocument()
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            TruckTractor transport = new TruckTractor("MAZ", 40, 10, transport1.ToString());
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, transport1.ToString());
            Refrigerator transport2 = new Refrigerator("Wielton NJ 3", 66, "Молоко", "+3 - +5", 6, 2);            
            TruckTractor transport4 = new TruckTractor("Ford", 33, 8, transport2.ToString());
            TruckTractor transport5 = new TruckTractor("Scania", 55, 10, transport3.ToString());
            Refrigerator transport6 = new Refrigerator("Montracon", 32, "Рыба", "-15 - -25", 10, 12);
            w.Add(transport);
            w.Add(transport1);
            w.Add(transport2);
            w.Add(transport3);
            w.Add(transport4);
            w.Add(transport5);
            w.Add(transport6);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            var x = SaxParser.SaxParsing(@"../../CarPark.xml");
            StreamParser parser = new StreamParser();
            parser.SaveDocument(parser.LoadDocument(@"../../CarPark.xml"), @"../../CarPark1.xml");
            var z = SaxParser.SaxParsing(@"../../CarPark1.xml");
            CollectionAssert.AreEqual(x, z);
        }
        /// <summary>
        /// Testing Method Fuel Consumption
        /// </summary>
        [TestMethod]
        public void TestMethodFuelConsumption()
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, transport1.ToString());
            w.Add(transport1);
            w.Add(transport3);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            ListWork work = new ListWork();
            TruckTractor truckTractor = new TruckTractor();
            foreach (var v in work.FuelConsumption())
                truckTractor.FuelConsumption = v.FuelConsumption;
            Assert.AreEqual(17.4, truckTractor.FuelConsumption);


        }
        /// <summary>
        /// Testing Method Find Semitrailer By Type
        /// </summary>
        [TestMethod]
        public void TestMethodFindSemitrailerByType()
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, transport1.ToString());
            w.Add(transport1);
            w.Add(transport3);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            ListWork work = new ListWork();
            Semitrailer semitrailer = new Semitrailer();
            foreach (var v in work.FindSemitrailerByType("tank truck")) 
                semitrailer = v;
            Assert.AreEqual(transport1, semitrailer);
        }
        /// <summary>
        /// Testing Method FindSemitrailerByCharacteristics
        /// </summary>
        [TestMethod]
        public void TestMethodFindSemitrailerByCharacteristics()
        {
            List<Transport> w = new List<Transport>();
            Refrigerator transport1 = new Refrigerator("Wielton NJ 3", 62, "Молоко", "+3 - +5", 6, 2);
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, transport1.ToString());
            w.Add(transport1);
            w.Add(transport3);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            ListWork work = new ListWork();
            Semitrailer semitrailer = new Semitrailer();
            foreach (var v in work.FindSemitrailerByCharacteristics("Wielton NJ 3", 62, "Молоко", "+3 - +5", 6, 2))
                semitrailer = v;
            Assert.AreEqual(transport1, semitrailer);
        }
        /// <summary>
        /// Testing Method FindСouplingByTypeOfGoods
        /// </summary>
        [TestMethod]
        public void TestMethodFindСouplingByTypeOfGoods()
        {
            List<Transport> w = new List<Transport>();
            Refrigerator transport1 = new Refrigerator("Wielton NJ 3", 62, "Молоко", "+3 - +5", 6, 2);
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, transport1.ToString());
            w.Add(transport1);
            w.Add(transport3);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            ListWork work = new ListWork();
            string coupling = "";
            foreach (var v in work.FindСouplingByTypeOfGoods("Молоко"))
                coupling = v.Key + " + " + v.Value;
            Assert.AreEqual("Volvo(77) + Wielton NJ 3(62)", coupling);
        }
        /// <summary>
        /// Testing Method FindСouplingForAddGoods
        /// </summary>
        [TestMethod]
        public void TestMethodFindСouplingForAddGoods()
        {
            List<Transport> w = new List<Transport>();
            Refrigerator transport1 = new Refrigerator("Wielton NJ 3", 62, "Молоко", "+3 - +5", 6, 2);
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, transport1.ToString());
            w.Add(transport1);
            w.Add(transport3);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            ListWork work = new ListWork();
            string coupling = "";
            foreach (var v in work.FindСouplingForAddGoods())
                coupling = v.Key + " + " + v.Value;
            Assert.AreEqual("Volvo(77) + Wielton NJ 3(62)", coupling);
        }
        /// <summary>
        /// Testing Method OpportunitiesOfLogisticiansAddGood
        /// </summary>
        [TestMethod]
        public void TestMethodOpportunitiesOfLogisticiansAddGood()
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            TruckTractor transport = new TruckTractor("MAZ", 40, 10, transport1.ToString());
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, "");
            Refrigerator transport2 = new Refrigerator("Wielton NJ 3", 66, "Молоко", "+3 - +5", 6, 2);
            TruckTractor transport4 = new TruckTractor("Ford", 33, 8, transport2.ToString());
            TruckTractor transport5 = new TruckTractor("Scania", 55, 10, transport3.ToString());
            Refrigerator transport6 = new Refrigerator("Montracon", 32, "Рыба", "-15 - -25", 10, 12);
            w.Add(transport);
            w.Add(transport1);
            w.Add(transport2);
            w.Add(transport3);
            w.Add(transport4);
            w.Add(transport5);
            w.Add(transport6);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            ListWork.OpportunitiesOfLogisticians work1 = new ListWork.OpportunitiesOfLogisticians();
            double add = work1.OpportunitiesOfLogisticiansAddGood((TruckTractor)transport, "Бензин", 1, @"../../SaveChange.xml");
            Assert.AreEqual(18, add);
        }
        /// <summary>
        /// Testing Method OpportunitiesOfLogisticiansMinusGood
        /// </summary>
        [TestMethod]
        public void TestMethodOpportunitiesOfLogisticiansMinusGood()
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            TruckTractor transport = new TruckTractor("MAZ", 40, 10, transport1.ToString());
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, "");
            Refrigerator transport2 = new Refrigerator("Wielton NJ 3", 66, "Молоко", "+3 - +5", 6, 2);
            TruckTractor transport4 = new TruckTractor("Ford", 33, 8, transport2.ToString());
            TruckTractor transport5 = new TruckTractor("Scania", 55, 10, transport3.ToString());
            Refrigerator transport6 = new Refrigerator("Montracon", 32, "Рыба", "-15 - -25", 10, 12);
            w.Add(transport);
            w.Add(transport1);
            w.Add(transport2);
            w.Add(transport3);
            w.Add(transport4);
            w.Add(transport5);
            w.Add(transport6);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            ListWork.OpportunitiesOfLogisticians work1 = new ListWork.OpportunitiesOfLogisticians();
            double minus = work1.OpportunitiesOfLogisticiansMinusGood((TruckTractor)transport, "Бензин", 1, @"../../SaveChange.xml");
            Assert.AreEqual(16, minus);
        }
        /// <summary>
        /// Testing Method OpportunitiesOfLogisticiansMinusAllGood
        /// </summary>
        [TestMethod]
        public void TestMethodOpportunitiesOfLogisticiansMinusAllGood()
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            TruckTractor transport = new TruckTractor("MAZ", 40, 10, transport1.ToString());
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, "");
            Refrigerator transport2 = new Refrigerator("Wielton NJ 3", 66, "Молоко", "+3 - +5", 6, 2);
            TruckTractor transport4 = new TruckTractor("Ford", 33, 8, transport2.ToString());
            TruckTractor transport5 = new TruckTractor("Scania", 55, 10, transport3.ToString());
            Refrigerator transport6 = new Refrigerator("Montracon", 32, "Рыба", "-15 - -25", 10, 12);
            w.Add(transport);
            w.Add(transport1);
            w.Add(transport2);
            w.Add(transport3);
            w.Add(transport4);
            w.Add(transport5);
            w.Add(transport6);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            ListWork.OpportunitiesOfLogisticians work1 = new ListWork.OpportunitiesOfLogisticians();
            double minus = work1.OpportunitiesOfLogisticiansMinusAllGood((TruckTractor)transport, "Бензин", @"../../SaveChange.xml");
            Assert.AreEqual(0, minus);
        }
        /// <summary>
        /// Testing Method OpportunitiesOfLogisticiansFullAddGood
        /// </summary>
        [TestMethod]
        public void TestMethodOpportunitiesOfLogisticiansFullAddGood()
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            TruckTractor transport = new TruckTractor("MAZ", 40, 10, transport1.ToString());
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, "");
            Refrigerator transport2 = new Refrigerator("Wielton NJ 3", 66, "Молоко", "+3 - +5", 6, 2);
            TruckTractor transport4 = new TruckTractor("Ford", 33, 8, transport2.ToString());
            TruckTractor transport5 = new TruckTractor("Scania", 55, 10, transport3.ToString());
            Refrigerator transport6 = new Refrigerator("Montracon", 32, "Рыба", "-15 - -25", 10, 12);
            w.Add(transport);
            w.Add(transport1);
            w.Add(transport2);
            w.Add(transport3);
            w.Add(transport4);
            w.Add(transport5);
            w.Add(transport6);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            ListWork.OpportunitiesOfLogisticians work1 = new ListWork.OpportunitiesOfLogisticians();
            double minus = work1.OpportunitiesOfLogisticiansFullAddGood((TruckTractor)transport, "Бензин", @"../../SaveChange.xml");
            Assert.AreEqual(26, minus);
        }
        /// <summary>
        /// Testing Method ReplaceSemitrailer
        /// </summary>
        [TestMethod]
        public void TestMethodReplaceSemitrailer()
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            TruckTractor transport = new TruckTractor("MAZ", 40, 10, transport1.ToString());
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, "");
            Refrigerator transport2 = new Refrigerator("Wielton NJ 3", 66, "Молоко", "+3 - +5", 6, 2);
            TruckTractor transport4 = new TruckTractor("Ford", 33, 8, transport2.ToString());
            TruckTractor transport5 = new TruckTractor("Scania", 55, 10, transport3.ToString());
            Refrigerator transport6 = new Refrigerator("Montracon", 32, "Рыба", "-15 - -25", 10, 12);
            w.Add(transport);
            w.Add(transport1);
            w.Add(transport2);
            w.Add(transport3);
            w.Add(transport4);
            w.Add(transport5);
            w.Add(transport6);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            ListWork.OpportunitiesOfLogisticians work1 = new ListWork.OpportunitiesOfLogisticians();
            TruckTractor truckTractor = new TruckTractor();
            truckTractor = work1.ReplaceSemitrailer((TruckTractor)transport3, (Semitrailer)transport1, @"../../SaveChange.xml"); 
            Assert.AreEqual(transport1.ToString(), truckTractor.Semitrailer);
        }
        /// <summary>
        /// Testing Method DeleteSemitrailer
        /// </summary>
        [TestMethod]
        public void TestMethodDeleteSemitrailer()
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            TruckTractor transport = new TruckTractor("MAZ", 40, 10, transport1.ToString());
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, "");
            Refrigerator transport2 = new Refrigerator("Wielton NJ 3", 66, "Молоко", "+3 - +5", 6, 2);
            TruckTractor transport4 = new TruckTractor("Ford", 33, 8, transport2.ToString());
            TruckTractor transport5 = new TruckTractor("Scania", 55, 10, transport3.ToString());
            Refrigerator transport6 = new Refrigerator("Montracon", 32, "Рыба", "-15 - -25", 10, 12);
            w.Add(transport);
            w.Add(transport1);
            w.Add(transport2);
            w.Add(transport3);
            w.Add(transport4);
            w.Add(transport5);
            w.Add(transport6);
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            ListWork.OpportunitiesOfLogisticians work1 = new ListWork.OpportunitiesOfLogisticians();
            TruckTractor truckTractor = new TruckTractor();
            truckTractor = work1.DeleteSemitrailer((TruckTractor)transport4 ,@"../../SaveChange.xml"); 
            Assert.AreEqual("", truckTractor.Semitrailer);
        }
        /// <summary>
        /// Add in xml object from new class
        /// </summary>
        [TestMethod]
        public void TestMethodAddInXmlObjNewClass()
        {
            List<Transport> w = new List<Transport>();
            TankTruck transport1 = new TankTruck("Renault", 36, "Бензин", "+5", 17, 10, ViewFuel.AI92);
            TruckTractor transport = new TruckTractor("MAZ", 40, 10, transport1.ToString());
            TruckTractor transport3 = new TruckTractor("Volvo", 77, 12, "");
            Refrigerator transport2 = new Refrigerator("Wielton NJ 3", 66, "Молоко", "+3 - +5", 6, 2);
            TruckTractor transport4 = new TruckTractor("Ford", 33, 8, transport2.ToString());
            TruckTractor transport5 = new TruckTractor("Scania", 55, 10, transport3.ToString());
            Refrigerator transport6 = new Refrigerator("Montracon", 32, "Рыба", "-15 - -25", 10, 12);
            ContainerShip transport7 = new ContainerShip("Grunwald", 32, "Контейнерные цистерны", "+2 - +22", 7, 15);
            w.Add(transport);
            w.Add(transport1);
            w.Add(transport2);
            w.Add(transport3);
            w.Add(transport4);
            w.Add(transport5);
            w.Add(transport6);
            w.Add(transport7); 
            SaxParser.AddInXml(w, @"../../CarPark.xml");
            var x = SaxParser.SaxParsing(@"../../CarPark.xml");
            CollectionAssert.AreEqual(x, w);
        }
    }
}
