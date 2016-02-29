using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Registration
    {
        private Player Player;
        public List<Player> Players;
        public UserInput Input { get; set; }
        public XmlWriter Writer { get; set; }


        private int _maxNumberOfPlayers;
        private int _minNumberOfPlayers;
        private int _playerCounter;


        public Registration()
        {
            Player = new Player();
            Players = new List<Player>();
        }

        public Registration(List<Player> players)
        {
            Players = players;
        }

        public void Display()
        {

            bool noMorePlayers = false;
            while (!noMorePlayers)
            {
                Console.WriteLine("Enter Players:");
                Player.Name = Console.ReadLine();

                Players.Add(new Player(Player.Name));

                char selection = ' ';
                while (!selection.Equals('Y') && !selection.Equals('N'))
                {
                    Console.WriteLine("Would you like to add another player? Y - N");
                    selection = Convert.ToChar(Console.ReadLine().ToUpper());

                    if (selection.Equals('Y'))
                        noMorePlayers = false;
                    else if (selection.Equals('N'))
                    {
                        Console.Clear();
                        for (var i = 0; i < Players.Count(); i++)                      
                            Console.WriteLine((string)Players[i].Name);
                        noMorePlayers = true;
                    }
                    else
                        Console.WriteLine("Invalid Selection. Try Again");
                   
                }
            }
        }
    }
}






