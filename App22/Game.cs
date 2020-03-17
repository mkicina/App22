using System;
using App22.Scoreboard;

namespace App22
{
    public class Game
    {
        private ConsoleUi _consoleUi;
        private Level _level;
        private int levelNum = 1;
        private Leaderboard _leaderboard;
        private string _name;
        private int _rating;
        private string _comment;
        private Player _player;
        
        private readonly IScoreService scoreService = new ScoreServiceFile();
        
        public Game(ConsoleUi consoleUi, Level level)
        {
            _consoleUi = consoleUi;
            _level = level;
            _leaderboard=new Leaderboard();
        }

        public bool IsGameWon()
        {
            if (levelNum > 2)
            {
                Console.WriteLine("You won game!");
                
                Console.WriteLine("How many stars would you give this game? (Max 5 stars)");
                Rating rating = new Rating();
                rating.Stars = Console.Read();
                _player.Rating = rating;

                Console.WriteLine("Please leave a comment for our game!");
                Comment comment = new Comment();
                comment.Notion = Console.ReadLine();
                _player.Comment = comment;

                return true;
            }
            return false;
        }

        public void SetupMenu()
        {
            Console.WriteLine("Welcome!");
            Console.Write("Enter your name:");
            
            _name = Console.ReadLine();
            
            _player=new Player(_name);
            Start();
        }

        public void Start()
        {
            do
            {
                _level.NextLevel(levelNum);
                _consoleUi.Run();
                levelNum++;
            } while (!IsGameWon());

            Score score = new Score();
            score.Points = _consoleUi.GetMoves();
            _player.Score = score;

            _leaderboard.AddPlayer(_player);
            
            AfterGameSetup();
            
        }

        public void AfterGameSetup()
        {
            Console.WriteLine("Do you want to play again?  Y/N");
            string answer = Console.ReadLine();
            
            if (answer == "y")
            {
                levelNum = 1;
                SetupMenu();
            }
            else if (answer == "n")
            {
                ShowScore();
            }
            else
            {
                Console.WriteLine("You have to answer only Y or N");
                AfterGameSetup();
            }
        }

        public void ShowScore()
        {
            for (int i = 0; i < _leaderboard.GetArray().Count; i++)
            {
                Console.WriteLine("Name: " + _leaderboard.GetArray()[i].GetName());
                Console.WriteLine("Score: " + _leaderboard.GetArray()[i].Score.Points);
                Console.WriteLine("Rating: " + _leaderboard.GetArray()[i].Rating.Stars);
                Console.WriteLine("Comment: " + _leaderboard.GetArray()[i].Comment.Notion);
            }
        }
        
    }
}