using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class UserInput
    {
        private string _userInput; 


        public string GetUserInput(string userInput)
        {
            _userInput = userInput;
            userInput = Console.ReadLine(); 
            return userInput;

        }
    }
}
