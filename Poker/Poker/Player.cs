using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Player
    {
        public string Name { get; set; }
        public double BankRoll { get; set; }
        public int NumberOfTournamentWins { get; set; }
        public int NumberOfSitAndGoWins { get; set; }
        public static int BetAmount { get; set; }
        public int StackSize { get; set; }
        public static int PlayerOneCurrentStack { get; set; }
        public static int PlayerTwoCurrentStack { get; set; }
        


        public Player(string name, double bankRoll, int numberOfTournamentWins, int numberOfSitAndGoWins, int betAmount, int stackSize)
        {
            Name = name;
            BankRoll = bankRoll;
            NumberOfTournamentWins = numberOfTournamentWins;
            NumberOfSitAndGoWins = numberOfSitAndGoWins;
            BetAmount = betAmount;
            StackSize = stackSize;
        }

        public Player()
        {
            
        }

        public Player(string name)
        {
            Name = name; 
        }

        public Player(string name, double bankRoll, int numberOfTournamentWins, int numberOfSitAndGoWins)
        {
            Name = name;
            BankRoll = bankRoll;
            NumberOfTournamentWins = numberOfTournamentWins;
            NumberOfSitAndGoWins = numberOfSitAndGoWins;
        }

        public override string ToString()
        {
            return $"Name: {Name} Overall Rating: {BankRoll} Age: {NumberOfTournamentWins} Weight: {NumberOfSitAndGoWins}";
        }
    }
}
