using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Game
    {
        public bool GameIsOver { get; set; }
        public Game()
        {
            XmlWriter xw = new XmlWriter();
            Registration registration = new Registration();
            DealCards deal = new DealCards();
            List<Player> players = new List<Player>();
            Betting betting = new Betting();
            bool nextDeal = false;

            DisplayLeaderBoard();

            registration.Display();
            players.Add(new Player(registration.Players[0].Name));
            players.Add(new Player(registration.Players[1].Name));
            xw.WriteAccountToFile(players);

            Console.Clear();

            while (!nextDeal)
            {

                betting.DisplayBetMessage(players);
                deal.CreateDeck();
                deal.GetHand();
                deal.SortCards();
                deal.DisplayCards(players);
                deal.Evaulate();
                betting.DisplayStackSize(players);
                GameOver(players);
                Console.WriteLine("PRESS ENTER TO PLAY AGAIN");
                Console.ReadKey();
                Console.Clear();
                try
                {
                    char selection = ' ';
                    while (!selection.Equals('Y') && !selection.Equals('N'))
                    {
                        Console.WriteLine("PRESS Y FOR NEXT HAND");

                        selection = Convert.ToChar(Console.ReadLine().ToUpper());

                        if (selection.Equals('Y'))
                            nextDeal = false;
                        else if (selection.Equals('N'))
                            nextDeal = true;
                        else
                            Console.WriteLine("Invalid Selection. Try Again");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Selection. Try Again");
                }
            }
        }
        public void GameOver(List<Player> players)
        {
            if (Player.PlayerOneCurrentStack > 2000)
            {
                int Wins = Player.NumberOfTournamentWins++;
                Console.Clear();
                Console.WriteLine(players[0].Name + " Wins");
                Console.WriteLine(players[0].Name + " Number of tournament wins is: " + Wins);
                Console.WriteLine("Would you like to play again?");
                GameIsOver = true;
            }
            else if (Player.PlayerTwoCurrentStack > 2000)
            {
                int Wins1 = Player.NumberOfTournamentWins;
                Console.Clear();
                Console.WriteLine(players[1].Name + " Wins!");
                Console.WriteLine(players[1].Name + " Number of tournament wins is: " + Wins1);
                Console.WriteLine("Would you like to play again?");
                GameIsOver = true;
            }
            else
            {
                GameIsOver = false;
            }
        }
        public void DisplayLeaderBoard()
        {
            FileReader fr = new FileReader($"../../LeaderBoard.xml");
            string outPut = fr.ReadFromFile();
            Console.WriteLine(outPut);
            Console.WriteLine("PLEASE HIT ENTER TO CONTINUE");
            Console.ReadLine();
            Console.Clear();
        }
    }
}










