using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Poker
{

    public class XmlReader
    {
        private string _path;
        public void ReadFromFile()
        {
            _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            
            XmlTextReader reader = new XmlTextReader(_path + "//PokerAccountInfo.settings.xml");
           
            while (reader.Read())
            {

                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.Write("<" + reader.Name);

                        while (reader.MoveToNextAttribute())
                        Console.WriteLine(" " + reader.Name + "='" + reader.Value + "'");
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
            
        }  
    }
}
