using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CarParkLibrary.DataWork
{
    /// <summary>
    /// CLass for load and save with stream
    /// </summary>
    public class StreamParser
    {
        /// <summary>
        /// Method for load document
        /// </summary>
        /// <param name="path">path</param>
        /// <returns>XmlDocument</returns>
        public XmlDocument LoadDocument(String path)
        {
            XmlDocument document = new XmlDocument();
            using (StreamReader stream = new StreamReader(path))
            {
                document.Load(stream);
            }
            return (document);
        }
        /// <summary>
        /// Method for save document
        /// </summary>
        /// <param name="document">XmlDocument</param>
        /// <param name="path">path</param>
        /// <returns>XmlDocument</returns>
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
