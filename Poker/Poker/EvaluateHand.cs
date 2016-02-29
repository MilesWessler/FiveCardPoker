using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum Hand
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind

    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

    public class EvaluateHand : Card
    {
        private int heartsSum;
        private int diamondSum;
        private int clubsSum;
        private int spadesSum;
        private Card[] cards;
        private HandValue handValue;


        public EvaluateHand(Card[] sortedHand)
        {
            heartsSum = 0;
            diamondSum = 0;
            clubsSum = 0;
            spadesSum = 0;
            cards = new Card[5];
            Cards = sortedHand; 
            handValue = new HandValue();
        }

        public HandValue HandValues
        {
            get { return handValue; }
            set { handValue = value; }
        }
        public Card[] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
        }
        public Hand EvaluateHands()
        {
            //get number of each suit on hand
            GetNumberOfSuit();
            if (FourOfAKind())
                return Hand.FourOfAKind;
            else if (FullHouse())
                return Hand.FullHouse;
            else if (Flush())
                return Hand.Flush;
            else if (Straight())
                return Hand.Straight;
            else if (ThreeOfAKind())
                return Hand.ThreeOfAKind;
            else if (TwoPair())
                return Hand.TwoPair;
            else if (OnePair())
                return Hand.OnePair;
            handValue.HighCard = (int) cards[4].MyRank;
            return Hand.HighCard; 


        }
        private void GetNumberOfSuit()
        {
            foreach (var element in Cards)
            {
                if (element.MySuit == Card.Suit.Hearts)
                    heartsSum++;
                if (element.MySuit == Card.Suit.Diamonds)
                    diamondSum++;
                if (element.MySuit == Card.Suit.Clubs)
                    clubsSum++;
                if (element.MySuit == Card.Suit.Spades)
                    spadesSum++;

            }
        }
        private bool FourOfAKind()
        {
            //if the first 4 cards, add values of the four cards and last card is the highest
            if (cards[0].MyRank == cards[1].MyRank && cards[0].MyRank == cards[2].MyRank &&
                cards[0].MyRank == cards[3].MyRank)
            {
                handValue.Total = (int)cards[1].MyRank * 4;
                handValue.HighCard = (int)cards[4].MyRank;
                return true;
            }
            else if (cards[1].MyRank == cards[2].MyRank && cards[1].MyRank == cards[3].MyRank &&
                     cards[1].MyRank == cards[4].MyRank)
            {
                handValue.Total = (int)cards[1].MyRank * 4;
                handValue.HighCard = (int)cards[0].MyRank;
                return true;
            }
            return false;
        }
        private bool FullHouse()
        {
            //if first three cards are the same value, and last two cards are the same value
            //first two cards and last three cards same value
            if ((cards[0].MyRank == cards[1].MyRank && cards[0].MyRank == cards[2].MyRank &&
                 cards[3].MyRank == cards[4].MyRank) ||
                (cards[0].MyRank == cards[1].MyRank && cards[2].MyRank == cards[3].MyRank &&
                 cards[2].MyRank == cards[4].MyRank))
            {
                handValue.Total = (int)(cards[0].MyRank) + (int)(cards[1].MyRank) + (int)(cards[2].MyRank) +
                                  (int)(cards[3].MyRank) + (int)(cards[4].MyRank);
                return true;
            }
            return false;
        }
        private bool Flush()
        {
            if (heartsSum == 5 || diamondSum == 5 || clubsSum == 5 || spadesSum == 5)
            {
                handValue.Total = (int)cards[4].MyRank;
                return true;
            }
            return false;
        }
        private bool Straight()
        {
            if (cards[0].MyRank + 1 == cards[1].MyRank && cards[1].MyRank + 1 == cards[2].MyRank &&
                cards[2].MyRank + 1 == cards[3].MyRank && cards[3].MyRank + 1 == cards[4].MyRank)
            {
                handValue.Total = (int)cards[4].MyRank;
                return true;
            }

            return false;
        }
        private bool ThreeOfAKind()
        {
            if ((cards[0].MyRank == cards[1].MyRank && cards[0].MyRank == cards[2].MyRank) ||
                (cards[1].MyRank == cards[2].MyRank && cards[1].MyRank == cards[3].MyRank))
            {
                handValue.Total = (int) cards[2].MyRank*3;
                handValue.HighCard = (int) cards[4].MyRank;
                return true;
            }
            else if (cards[2].MyRank == cards[3].MyRank && cards[2].MyRank == cards[4].MyRank)
            {
                handValue.Total = (int)cards[2].MyRank * 3;
                handValue.HighCard = (int)cards[1].MyRank;
                return true;
            }
            return false; 
        }
        private bool TwoPair()
        {
            if (cards[0].MyRank == cards[1].MyRank && cards[2].MyRank == cards[3].MyRank)
            {
                handValue.Total = ((int)cards[1].MyRank * 2) + ((int)cards[3].MyRank * 2);
                handValue.HighCard = (int)cards[4].MyRank;
                return true;
            }

            else if (cards[0].MyRank == cards[1].MyRank && cards[3].MyRank == cards[4].MyRank)
            {
                handValue.Total = ((int)cards[1].MyRank * 2) + ((int)cards[3].MyRank * 2);
                handValue.HighCard = (int)cards[2].MyRank;
                return true;
            }
            else if (cards[1].MyRank == cards[2].MyRank && cards[3].MyRank == cards[4].MyRank)
            {
                handValue.Total = ((int)cards[1].MyRank * 2) + ((int)cards[3].MyRank * 2);
                handValue.HighCard = (int)cards[0].MyRank;
                return true;
            }
            return false;
        }

        private bool OnePair()
        {
            if (cards[0].MyRank == cards[1].MyRank)
            {
                handValue.Total = (int)cards[0].MyRank * 2;
                handValue.HighCard = (int)cards[4].MyRank;
                return true;
            }
            else if (cards[1].MyRank == cards[2].MyRank)
            {
                handValue.Total = (int)cards[1].MyRank * 2;
                handValue.HighCard = (int)cards[4].MyRank;
                return true;
            }
            else if (cards[2].MyRank == cards[3].MyRank)
            {
                handValue.Total = (int)cards[2].MyRank * 2;
                handValue.HighCard = (int)cards[4].MyRank;
                return true;
            }
            else if (cards[3].MyRank == cards[4].MyRank)
            {
                handValue.Total = (int)cards[3].MyRank * 2;
                handValue.HighCard = (int)cards[2].MyRank;
                return true;
            }
            return false;
        }
    }
}





