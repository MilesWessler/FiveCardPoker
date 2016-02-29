using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Game
    {


        public Game()
        {

            Registration registration = new Registration();
            DealCards deal = new DealCards();
            Player player = new Player();
            List<Player> players = new List<Player>();
            Betting betting = new Betting();


            registration.Display();
            players.Add(new Player(registration.Players[0].Name));
            players.Add(new Player(registration.Players[1].Name));
            
            Console.ReadLine();
            deal.Deal(players);
             
            





        }

    }
}
