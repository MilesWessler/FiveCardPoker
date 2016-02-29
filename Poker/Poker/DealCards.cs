using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poker
{
    public class DealCards : Deck
    {
        Player _player = new Player();
        public List<Player> Players { get; set; }
        private readonly Card[] _playerHand;
        private readonly Card[] _playerTwoHand;
        private readonly Card[] _sortedPlayerHand;
        private readonly Card[] _sortedPlayerTwoHand;
        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }
        public bool PlayerOneWin { get; set; }
        public bool PlayerTwoWin { get; set; }




        public DealCards()
        {
            _playerHand = new Card[5];
            _sortedPlayerHand = new Card[5];
            _playerTwoHand = new Card[5];
            _sortedPlayerTwoHand = new Card[5];
        }

  

        public void GetHand()
        {
            for (int i = 0; i < 5; i++)
                _playerHand[i] = GetDeck[i];

            for (int i = 5; i < 10; i++)
                _playerTwoHand[i - 5] = GetDeck[i];
        }

        public void SortCards()
        {
            var queryPlayer = from hand in _playerHand
                              orderby hand.MyRank
                              select hand;

            var queryPlayerTwo = from hand in _playerTwoHand
                                 orderby hand.MyRank
                                 select hand;

            var index = 0;
            foreach (var element in queryPlayer.ToList())
            {
                _sortedPlayerHand[index] = element;
                index++;
            }
            index = 0;
            foreach (var element in queryPlayerTwo.ToList())
            {
                _sortedPlayerTwoHand[index] = element;
                index++;
            }

        }

        public void DisplayCards(List<Player> players)
        {
            Players = players;

            Console.Clear();
            int x = 0; //position of the cursor. move it left and right
            int y = 1; //y position of the cursor, we move up and down

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(players[0].Name);
            for (int i = 0; i < 5; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitAndValue(_sortedPlayerHand[i], x, y);
                x++; //move to the right
            }
            y = 15;
            x = 0;

            Console.SetCursorPosition(x, 14);
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(players[1].Name);
            for (int i = 5; i < 10; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitAndValue(_sortedPlayerTwoHand[i - 5], x, y);
                x++; //move to the right 
            }

        }

        public void Evaulate()
        {
            EvaluateHand evaluatePlayerHand = new EvaluateHand(_sortedPlayerHand);
            EvaluateHand evaluatePlayerTwoHand = new EvaluateHand(_sortedPlayerTwoHand);

            Hand playerOneHand = evaluatePlayerHand.EvaluateHands();
            Hand playerTwoHand = evaluatePlayerTwoHand.EvaluateHands();

            Console.WriteLine("\n\n\n\n\n" + Players[0].Name + " Hand: " + playerOneHand);
            Console.WriteLine("\n" + Players[1].Name + " Hand: " + playerTwoHand);

            if (playerOneHand > playerTwoHand)
            {
                Betting.PlayerOneStackSizeWin();
                Betting.PlayerTwoStackSizeLose();
                Console.WriteLine(Players[0].Name + " Wins!");

            }
            else if (playerOneHand < playerTwoHand)
            {
                Console.WriteLine(Players[1].Name + " Wins!");

            }
            else
            {
                //first evaluate who has higher value of poker hand
                if (evaluatePlayerHand.HandValues.Total > evaluatePlayerTwoHand.HandValues.Total)
                {
                    Betting.PlayerOneStackSizeWin();
                    Betting.PlayerTwoStackSizeLose();
                    Console.WriteLine(Players[0].Name + " Wins!");
                }
                else if (evaluatePlayerHand.HandValues.Total < evaluatePlayerTwoHand.HandValues.Total)
                {
                    Betting.PlayerTwoStackSizeWin();
                    Betting.PlayerOneStackSizeLose();
                    Console.WriteLine(Players[1].Name + " Wins!");
                }
                //if both have the same poker hand then player with high card wins
                else if (evaluatePlayerHand.HandValues.HighCard > evaluatePlayerTwoHand.HandValues.HighCard)
                {
                    Betting.PlayerOneStackSizeWin();
                    Betting.PlayerTwoStackSizeLose();
                    Console.WriteLine(Players[0].Name + " Wins!");
                }
                else if (evaluatePlayerHand.HandValues.HighCard < evaluatePlayerTwoHand.HandValues.HighCard)
                {
                    Betting.PlayerTwoStackSizeWin();
                    Betting.PlayerOneStackSizeLose();
                    Console.WriteLine(Players[1].Name + " Wins!");
                }
                else
                    Console.WriteLine("Draw");       
            }
        }
    }
}

