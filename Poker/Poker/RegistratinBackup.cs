//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Poker
//{
//    public class Registration
//    {
//        public List<Player> Players { get; set; }
//        public Player PlayerOne { get; set; }
//        public Player PlayerTwo { get; set; }
//        public UserInput Input { get; set; }
//        public XmlWriter Writer { get; set; }


//        private int _maxNumberOfPlayers;
//        private int _minNumberOfPlayers;
//        private int _playerCounter;


//        public Registration()
//        {

//        }

//        public Registration(List<Player> players)
//        {
//            Players = players;
//        }

//        public void Display()
//        {
//            Input = new UserInput();
//            PlayerOne = new Player();
//            PlayerTwo = new Player();
//            Players = new List<Player>();
//            Writer = new XmlWriter();



//            Console.WriteLine("Please register by typing your name into the console");
//            PlayerOne.Name = Console.ReadLine();

//            Console.WriteLine("Player two please register by typing your name");
//            PlayerTwo.Name = Console.ReadLine();

//            Console.WriteLine("Thank you for registering. The tournament will start shortly.");
//            Console.WriteLine("$50 Dollars has been deducted from your account");
//            Console.WriteLine("The tournament will start momentarily.");

//            Players.Add(PlayerOne);
//            Players.Add(PlayerTwo);
//            Writer.WriteAccountToFile(Players);
//        }




//    }
//}
