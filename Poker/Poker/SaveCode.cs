//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Poker
//{
//    class SaveCode
//    {
//        public void Evaulate()
//        {
//            EvaluateHand evaluatePlayerHand = new EvaluateHand(_sortedPlayerHand);
//            EvaluateHand evaluatePlayerTwoHand = new EvaluateHand(_sortedPlayerTwoHand);

//            Hand playerOneHand = evaluatePlayerHand.EvaluateHands();
//            Hand playerTwoHand = evaluatePlayerTwoHand.EvaluateHands();

//            Console.WriteLine("\n\n\n\n\n" + _playerOneName + " Hand: " + playerOneHand);
//            Console.WriteLine("\n" + _playerTwoName + " Hand: " + playerTwoHand);

//            if (playerOneHand > playerTwoHand)
//            {
//                Console.WriteLine(_playerOneName + " Wins!");

//            }
//            else if (playerOneHand < playerTwoHand)
//            {
//                Console.WriteLine(_playerTwoName + " Wins!");

//            }
//            else
//            {
//                //first evaluate who has higher value of poker hand
//                if (evaluatePlayerHand.HandValues.Total > evaluatePlayerTwoHand.HandValues.Total)

//                    Console.WriteLine(_playerOneName + " Wins!");
//                else if (evaluatePlayerHand.HandValues.Total < evaluatePlayerTwoHand.HandValues.Total)
//                    Console.WriteLine(_playerTwoName + " Wins!");
//                //if both have the same poker hand then player with high card wins
//                else if (evaluatePlayerHand.HandValues.HighCard > evaluatePlayerTwoHand.HandValues.HighCard)
//                    Console.WriteLine(_playerOneName + " Wins!");
//                else if (evaluatePlayerHand.HandValues.HighCard < evaluatePlayerTwoHand.HandValues.HighCard)
//                    Console.WriteLine(_playerTwoName + " Wins!");
//                else
//                    Console.WriteLine("Draw");
//            }
//        }
//}
//ing System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Resources;
//using System.Text;
//using System.Threading.Tasks;

//namespace Poker
//{
//    public class DealCards : Deck
//    {
//        private Player _player = new Players();
//        List<Player> Players = new List<Players>();
//        private readonly Card[] _playerHand;
//        private readonly Card[] _playerTwoHand;
//        private readonly Card[] _sortedPlayerHand;
//        private readonly Card[] _sortedPlayerTwoHand;
//        private string _playerOneName;
//        private string _playerTwoName;


//        public DealCards()
//        {
//            _playerHand = new Card[5];
//            _sortedPlayerHand = new Card[5];
//            _playerTwoHand = new Card[5];
//            _sortedPlayerTwoHand = new Card[5];
//        }

//        public void Deal(string playerOneName, string playerTwoName)
//        {
//            _playerOneName = playerOneName;
//            _playerTwoName = playerTwoName;

//            bool quit = false;
//            while (!quit)
//            {
//                CreateDeck();
//                GetHand();
//                SortCards();
//                DisplayCards(playerOneName, playerTwoName);
//                Evaulate();

//                char selection = ' ';
//                while (!selection.Equals('Y') && !selection.Equals('N'))
//                {
//                    Console.WriteLine("Play again? Y - N");
//                    selection = Convert.ToChar(Console.ReadLine().ToUpper());

//                    if (selection.Equals('Y'))
//                        quit = false;
//                    else if (selection.Equals('N'))
//                        quit = true;
//                    else
//                        Console.WriteLine("Invalid Selection. Try Again");
//                }
//            }
//        }
//        public void GetHand()
//        {
//            for (int i = 0; i < 5; i++)
//                _playerHand[i] = GetDeck[i];

//            for (int i = 5; i < 10; i++)
//                _playerTwoHand[i - 5] = GetDeck[i];
//        }

//        public void SortCards()
//        {
//            var queryPlayer = from hand in _playerHand
//                              orderby hand.MyRank
//                              select hand;

//            var queryPlayerTwo = from hand in _playerTwoHand
//                                 orderby hand.MyRank
//                                 select hand;

//            var index = 0;
//            foreach (var element in queryPlayer.ToList())
//            {
//                _sortedPlayerHand[index] = element;
//                index++;
//            }
//            index = 0;
//            foreach (var element in queryPlayerTwo.ToList())
//            {
//                _sortedPlayerTwoHand[index] = element;
//                index++;
//            }

//        }
//        public void DisplayCards(string name, string playerTwoName)
//        {
//            Console.Clear();
//            int x = 0; //position of the cursor. move it left and right
//            int y = 1; //y position of the cursor, we move up and down

//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine(name);
//            for (int i = 0; i < 5; i++)
//            {
//                DrawCards.DrawCardOutline(x, y);
//                DrawCards.DrawCardSuitAndValue(_sortedPlayerHand[i], x, y);
//                x++;//move to the right
//            }
//            y = 15;
//            x = 0;

//            Console.SetCursorPosition(x, 14);
//            Console.ForegroundColor = ConsoleColor.DarkRed;
//            Console.WriteLine(playerTwoName);
//            for (int i = 5; i < 10; i++)
//            {
//                DrawCards.DrawCardOutline(x, y);
//                DrawCards.DrawCardSuitAndValue(_sortedPlayerTwoHand[i - 5], x, y);
//                x++;//move to the right 
//            }

//        }
//        public void Evaulate()
//        {
//            EvaluateHand evaluatePlayerHand = new EvaluateHand(_sortedPlayerHand);
//            EvaluateHand evaluatePlayerTwoHand = new EvaluateHand(_sortedPlayerTwoHand);

//            Hand playerOneHand = evaluatePlayerHand.EvaluateHands();
//            Hand playerTwoHand = evaluatePlayerTwoHand.EvaluateHands();

//            Console.WriteLine("\n\n\n\n\n" + _playerOneName + " Hand: " + playerOneHand);
//            Console.WriteLine("\n" + _playerTwoName + " Hand: " + playerTwoHand);

//            if (playerOneHand > playerTwoHand)
//            {
//                Console.WriteLine(_playerOneName + " Wins!");

//            }
//            else if (playerOneHand < playerTwoHand)
//            {
//                Console.WriteLine(_playerTwoName + " Wins!");

//            }
//            else
//            {
//                //first evaluate who has higher value of poker hand
//                if (evaluatePlayerHand.HandValues.Total > evaluatePlayerTwoHand.HandValues.Total)

//                    Console.WriteLine(_playerOneName + " Wins!");
//                else if (evaluatePlayerHand.HandValues.Total < evaluatePlayerTwoHand.HandValues.Total)
//                    Console.WriteLine(_playerTwoName + " Wins!");
//                //if both have the same poker hand then player with high card wins
//                else if (evaluatePlayerHand.HandValues.HighCard > evaluatePlayerTwoHand.HandValues.HighCard)
//                    Console.WriteLine(_playerOneName + " Wins!");
//                else if (evaluatePlayerHand.HandValues.HighCard < evaluatePlayerTwoHand.HandValues.HighCard)
//                    Console.WriteLine(_playerTwoName + " Wins!");
//                else
//                    Console.WriteLine("Draw");
//            }
//        }
//    }
//}