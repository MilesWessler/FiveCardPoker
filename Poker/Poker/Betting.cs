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
        public static int PotSize
        {
            get
            {
                return Players.Sum(_player => Poker.Player.BetAmount);
            }
        }

        public static int PlayerOneStackSizeWin()
        {
            foreach (Player player in Players)
            {
                Poker.Player.PlayerOneCurrentStack = PotSize + StartingStackSize;
            }
            return Poker.Player.PlayerOneCurrentStack; 
        }
        public static int PlayerTwoStackSizeWin()
        {
            foreach (Player player in Players)
            {
                Poker.Player.PlayerTwoCurrentStack = PotSize + StartingStackSize;
            }
            return Poker.Player.PlayerTwoCurrentStack;
        }
        public static int PlayerOneStackSizeLose()
        {
            foreach (Player player in Players)
            {
                Poker.Player.PlayerOneCurrentStack = StartingStackSize - Poker.Player.BetAmount;
            }
            return Poker.Player.PlayerOneCurrentStack;
        }
        public static int PlayerTwoStackSizeLose()
        {
            foreach (Player player in Players)
            {
                Poker.Player.PlayerTwoCurrentStack = StartingStackSize - Poker.Player.BetAmount;
            }
            return Poker.Player.PlayerTwoCurrentStack;
        }





        public void DisplayBetMessage(List<Player> players)
        {
            Players = players;

            WriteLine(players[0].Name + "Please place your bet");
            Poker.Player.BetAmount = Convert.ToInt32(ReadLine());
            WriteLine(players[1].Name + "Please place your bet");
            Poker.Player.BetAmount = Convert.ToInt32(ReadLine());

            WriteLine("The pot size is {0}", PotSize);
        }

        public void DisplayStackSize(List<Player> players)
        {
            Players = players;

            WriteLine(players[0].Name + "Current Stack Size: " + Poker.Player.PlayerOneCurrentStack);
            WriteLine(players[1].Name + "Current Stack Size: " + Poker.Player.PlayerTwoCurrentStack);
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
