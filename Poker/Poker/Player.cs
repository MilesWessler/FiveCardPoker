using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Player
    {
        public string Name { get; set; }
        public double BankRoll { get; set; }
        public static int NumberOfTournamentWins { get; set; }
        public static int BetAmount { get; set; }
        public static int StartingStackSize;
        public int StackSize { get; set; }
        public static int PlayerOneCurrentStack { get; set; }
        public static int PlayerTwoCurrentStack { get; set; }
        public static bool Win { get; set; }
        public static bool Lose { get; set; }


        public Player()
        {

        }
        public Player(string name)
        {
            Name = name;
        }
        public Player(string name, double bankRoll, int numberOfTournamentWins, int numberOfSitAndGoWins, int betAmount, int stackSize)
        {
            Name = name;
            BankRoll = bankRoll;
            NumberOfTournamentWins = numberOfTournamentWins;
        
            BetAmount = betAmount;
            StackSize = stackSize;         
        }

        public Player(string name, double bankRoll, int numberOfTournamentWins, int numberOfSitAndGoWins)
        {
            Name = name;
            BankRoll = bankRoll;
            NumberOfTournamentWins = numberOfTournamentWins;
            
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
