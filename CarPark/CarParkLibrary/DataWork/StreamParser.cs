using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CarParkLibrary.DataWork
{
    public class StreamParser
    {
        public XmlDocument LoadDocument(String path)
        {
            XmlDocument document = new XmlDocument();
            using (StreamReader stream = new StreamReader(path))
            {
                document.Load(stream);
            }
            return (document);
        }

        public XmlDocument SaveDocument(XmlDocument document, String path)
        {
            using (StreamWriter stream = new StreamWriter(path, false))
            {
                document.Save(stream);
            }
            return (document);
        }

    }
}
