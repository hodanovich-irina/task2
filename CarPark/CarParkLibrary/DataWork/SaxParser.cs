using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CarParkLibrary;
using System.IO;

namespace CarParkLibrary.DataWork
{
    /// <summary>
    /// Class for SaxParser
    /// </summary>
    public class SaxParser
    {
        /// <summary>
        /// Convert string to enum
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="value">The value that is searched for in the enumeration</param>
        /// <returns>Enumeration element</returns>
        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        /// <summary>
        /// Data parsing
        /// </summary>
        /// <returns>Collection of object</returns>
        public static List<Transport> SaxParsing(string pass)
        {
            
            List<Transport> transports = new List<Transport>();
            XmlReader xmlReader = XmlReader.Create(pass);
            Transport Transport = new Semitrailer().Create();
            
            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "TankTruck" || xmlReader.Name == "Refrigerator" || xmlReader.Name == "TruckTractor" || xmlReader.Name == "Semitrailer") )
                {
                    if (xmlReader.Name == "TankTruck")
                        Transport = new TankTruck().Create();
                    if (xmlReader.Name == "Refrigerator")
                        Transport = new Refrigerator().Create();
                    if (xmlReader.Name == "TruckTractor")
                        Transport = new TruckTractor().Create();
                    if (xmlReader.Name == "Semitrailer")
                        Transport = new Semitrailer().Create();
                    if (xmlReader.HasAttributes)
                        Transport.Name = xmlReader.GetAttribute("name");
                    if (xmlReader.ReadToFollowing("maxMass"))
                        Transport.MaxMass = (double)xmlReader.ReadElementContentAs(typeof(System.Double), null);
                    if (Transport is TruckTractor)
                    {
                        TruckTractor truckTractor = (TruckTractor)Transport;
                        if (xmlReader.ReadToFollowing("fuelConsumption"))
                            truckTractor.FuelConsumption = (double)xmlReader.ReadElementContentAs(typeof(System.Double), null);
                        if (xmlReader.ReadToFollowing("semitrailer"))
                            truckTractor.Semitrailer = (string)xmlReader.ReadElementContentAs(typeof(System.String), null);
                    }
                    if (Transport is Semitrailer)
                    {
                        Semitrailer semitrailer = (Semitrailer)Transport;
                        if (xmlReader.ReadToFollowing("typeOfGoods"))
                            semitrailer.TypeOfGoods = (string)xmlReader.ReadElementContentAs(typeof(System.String), null);
                        if (xmlReader.ReadToFollowing("storageConditions"))
                            semitrailer.StorageConditions = (string)xmlReader.ReadElementContentAs(typeof(System.String), null);
                        if (xmlReader.ReadToFollowing("mass"))
                            semitrailer.Mass = (double)xmlReader.ReadElementContentAs(typeof(System.Double), null);
                        if (xmlReader.ReadToFollowing("massOfGoods"))
                            semitrailer.MassOfGoods = (double)xmlReader.ReadElementContentAs(typeof(System.Double), null);
                    }
                    if (Transport is TankTruck)
                    {
                        TankTruck tankTruck = (TankTruck)Transport;
                        if (xmlReader.ReadToFollowing("viewFuel"))
                        {
                            string s = (string)xmlReader.ReadElementContentAs(typeof(System.String), null);
                            ViewFuel viewFuel = ParseEnum<ViewFuel>(s);
                            tankTruck.ViewFuel = viewFuel;
                        }
                    }

                    transports.Add(Transport);
                }
            }
            return transports;
        }
        /// <summary>
        /// Adding an entry to a XML-file
        /// </summary>
        /// <param name="wL">Collection of objects</param>
        public static void AddInXml(List<Transport> wL, string pass)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.CloseOutput = false;
            XmlWriter xmlWriter = XmlWriter.Create(pass, settings);
            xmlWriter.WriteStartElement("transport");
            foreach (var w in wL)
            {
                if (w is TankTruck)
                    xmlWriter.WriteStartElement("TankTruck");
                else if (w is Refrigerator)
                    xmlWriter.WriteStartElement("Refrigerator");
                else if(w is Semitrailer)
                    xmlWriter.WriteStartElement("Semitrailer");
                
                else 
                    xmlWriter.WriteStartElement("TruckTractor");
                xmlWriter.WriteAttributeString("name", w.Name);

                xmlWriter.WriteStartElement("maxMass");
                xmlWriter.WriteString(w.MaxMass.ToString());
                xmlWriter.WriteEndElement();
                if (w is TruckTractor)
                {
                    TruckTractor truckTractor = (TruckTractor)w;
                    xmlWriter.WriteStartElement("fuelConsumption");
                    xmlWriter.WriteString(truckTractor.FuelConsumption.ToString());
                    xmlWriter.WriteEndElement();
                    
                    xmlWriter.WriteStartElement("semitrailer");
                    xmlWriter.WriteString(truckTractor.Semitrailer.ToString());
                    xmlWriter.WriteEndElement();
                    
                }
                if (w is Semitrailer)
                {
                    Semitrailer semitrailer = (Semitrailer)w;
                    xmlWriter.WriteStartElement("typeOfGoods");
                    xmlWriter.WriteString(semitrailer.TypeOfGoods.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("storageConditions");
                    xmlWriter.WriteString(semitrailer.StorageConditions.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("mass");
                    xmlWriter.WriteString(semitrailer.Mass.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("massOfGoods");
                    xmlWriter.WriteString(semitrailer.MassOfGoods.ToString());
                    xmlWriter.WriteEndElement();
                }
                if (w is TankTruck)
                {
                    TankTruck tankTruck = (TankTruck)w;
                    xmlWriter.WriteStartElement("viewFuel");
                    xmlWriter.WriteString(tankTruck.ViewFuel.ToString());
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();

            }
            xmlWriter.WriteEndElement();
            xmlWriter.Close();

        }
    }
}
