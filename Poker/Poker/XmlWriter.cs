using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Poker
{
    public class XmlWriter
    {
        private string _path;
        private List<Player> Players { get; set; }



        public void WriteAccountToFile(List<Player> players)

        {
            _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (!Directory.Exists(_path + "//PokerAccountInfo"))
                Directory.CreateDirectory(_path + "//PokerAccountInfo");
            if (!File.Exists(_path + "//PokerAccountInfo.settings.xml"))
            {
                var xw = new XmlTextWriter(_path + "//PokerAccountInfo.settings.xml", Encoding.UTF8);
                xw.WriteStartElement("AccountInformation");
                xw.WriteEndElement();
                xw.Close();
            }

            Players = players;
            var xDoc = new XmlDocument();
            xDoc.Load(_path + "//PokerAccountInfo.settings.xml");         

            XmlNode xnode = xDoc.SelectSingleNode("Player");
            xnode?.RemoveAll();

            foreach (XmlNode xNode in xDoc.SelectNodes("AccountInformation/Players"))
            {
                var p = new Player();
                p.Name = xNode.SelectSingleNode("Name").InnerText;
                //p.BankRoll = Convert.ToDouble(xNode.SelectSingleNode("BankRoll").InnerText);
                Player.NumberOfTournamentWins = Convert.ToInt32(xNode.SelectSingleNode("NumberOfTournamentWins"));
                
                Players.Add(p);
            }
          
            foreach (Player p in Players)
            {
                XmlNode xtop = xDoc.CreateElement("Player");
                XmlNode xName = xDoc.CreateElement("Name");
                XmlNode xBankRoll = xDoc.CreateElement("BankRoll");
                XmlNode xNumberOfTournamentWins = xDoc.CreateElement("NumberOfTournamentWins");
                XmlNode xNumberOfSitAndGoWins = xDoc.CreateElement("NumberOfSitAndGoWins");
                xName.InnerText = p.Name;
                xBankRoll.InnerText = p.BankRoll.ToString();
                
                xNumberOfTournamentWins.InnerText = Player.NumberOfTournamentWins.ToString();
                xtop.AppendChild(xName);
                xtop.AppendChild(xBankRoll);
                xtop.AppendChild(xNumberOfSitAndGoWins);
                xtop.AppendChild(xNumberOfTournamentWins);
                xDoc.DocumentElement.AppendChild(xtop);
            }
            xDoc.Save(_path + "//PokerAccountInfo.settings.xml");
        }
    }
}
