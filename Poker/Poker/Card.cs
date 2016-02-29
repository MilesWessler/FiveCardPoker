using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Card
    {
        public enum Suit
        {
            Spades,
            Hearts,
            Diamonds,
            Clubs
        }

        public enum Rank
        {
            Two = 2,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }
        public Suit MySuit { get; set; }
        public Rank MyRank { get; set; }

        
    }
}
