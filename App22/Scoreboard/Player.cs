using System;

namespace App22.Scoreboard
{
    public class Player
    {
        private string _name;
        private Score _score;
        private Comment _comment;
        private Rating _rating;

        public Player(string name)
        {
            _name = name;
        }

        public Score Score { get; set; }
        
        public Comment Comment { get; set; }

        public Rating Rating { get; set; }
        
        public void SetName(string name)
        {
            _name = name;
        }
        public string GetName()
        {
            return _name;
        }
    }
}