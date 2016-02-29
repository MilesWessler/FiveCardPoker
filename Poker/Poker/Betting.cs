using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Poker
{
    public class Betting
    {
        public Player Player = new Player();
        public static List<Player> Players = new List<Player>();
        public static int StartingStackSize = 1000;
        public static int PlayerOneCurrentStack { get; set; }
        public static int PlayerTwoCurrentStack { get; set; }
        public static int PotSize
        {
            get
            {
                return Players.Sum(_player => _player.BetAmount);
            }
        }

        public static int PlayerOneStackSizeWin()
        {
            foreach (Player player in Players)
            {
                PlayerOneCurrentStack = PotSize + StartingStackSize;
            }
            return PlayerOneCurrentStack; 
        }




        public void DisplayBetMessage(List<Player> players)
        {
            Players = players;

            WriteLine(players[0].Name + "Please place your bet");
            Players[0].BetAmount = Convert.ToInt32(ReadLine());
            WriteLine(players[1].Name + "Please place your bet");
            Players[1].BetAmount = Convert.ToInt32(ReadLine());

            WriteLine("The pot size is {0}", PotSize);
        }

        public void DisplayStackSize(List<Player> players)
        {
            Players = players;

            WriteLine(value: players[0].Name + "Current Stack Size: " + PlayerOneCurrentStack);
            WriteLine(value: players[1].Name + "Current Stack Size: " + PlayerTwoCurrentStack);


        }






        public override string ToString()
        {
            string outPut = " ";
            foreach (Player player in Players)
            {
                outPut += player + "/n";
            }
            return outPut;
        }



    }
}
