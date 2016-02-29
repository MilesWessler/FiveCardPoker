using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Deck : Card
    {
        const int NumberOfCards = 52;
        private Card[] _deck;


        public Deck()
        {
            _deck = new Card[NumberOfCards];
        }

        public Card[] GetDeck { get { return _deck; } }

        public void CreateDeck()
        {
            int i = 0;
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _deck[i] = new Card { MySuit = suit, MyRank = rank };
                    i++;
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            Random rand = new Random();
            Card temp; 

            for (int shuffle = 0; shuffle < 1000; shuffle++)
            {
                for (int i = 0; i < NumberOfCards; i++)
                {
                    int secondCardIndex = rand.Next(13);
                    temp = _deck[i];
                    _deck[i] = _deck[secondCardIndex];
                    _deck[secondCardIndex] = temp; 
                }
            }
        }
    }
}
