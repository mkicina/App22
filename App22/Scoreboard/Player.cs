namespace App22.Scoreboard
{
    public class Player
    {
        private string _name;
        private int _score;
        public Player(string name)
        {
            _name = name;
        }

        public void SetMoves(int moves)
        {
            _score = moves;
        }

        public int GetScore()
        {
            return _score;
        }

        public string GetName()
        {
            return _name;
        }
    }
}