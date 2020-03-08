using System.Collections;
using System.Collections.Generic;

namespace App22.Scoreboard
{
    public class Leaderboard
    {
        private List<Player> _board;

        public Leaderboard()
        {
            _board = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            _board.Add(player);
        }

        public List<Player> GetArray()
        {
            return _board;
        }
    }
}