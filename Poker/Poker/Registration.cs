using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Registration
    {
        public Player Player;
        public List<Player> Players;

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
            int numberOfPlayers = 0;

            try
            {
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
                        else if (selection.Equals('N') || numberOfPlayers > 2)
                        {
                            Console.Clear();
                            for (var i = 0; i < Players.Count(); i++)

                                Console.WriteLine("Tournament Player: " + (string)Players[i].Name);
                            Console.WriteLine("Press enter to begin the game");
                            Console.ReadLine();
                            noMorePlayers = true;
                        }

                        else
                            Console.WriteLine("Invalid Selection. Try Again");
                    }
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Selection. Try Again");
            }
        }
    }
}






