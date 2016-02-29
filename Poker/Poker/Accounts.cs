using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Accounts
    {
        private List<Player> _players;

        public Accounts(List<Player> players)
        {
            this._players = players;
        }
    }
}
