using System;
using App22.Scoreboard;
using Microsoft.VisualBasic.CompilerServices;

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
        
        
        public Game(ConsoleUi consoleUi, Level level)
        {
            _consoleUi = consoleUi;
            _level = level;
            _leaderboard=new Leaderboard();
        }

        public bool IsGameWon()
        {
            if (levelNum > 1)
            {
                Console.WriteLine("You won game!");
                
                Console.WriteLine("How many stars would you give this game? (Max 5 stars)");
                int rate;
                
                while(true)
                    {
                        if (int.TryParse(Console.ReadLine(), out rate) && rate >= 0 && rate < 6)
                        {
                            Console.WriteLine("All right");
                            break;
                        }
                        Console.WriteLine("That was invalid. Enter a number from 0 to 5.");
                    }
                
                Rating rating = new Rating(); 
                rating.Stars = rate;
                _player.Rating = rating;

                Console.WriteLine("Please leave a comment for our game!");
                _comment = Console.ReadLine();
                Comment comment = new Comment();
                comment.Notion = _comment;
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
            _consoleUi.SetMoves(0);

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
            _leaderboard.SaveLeaderboard();
            for (int i = 0; i < _leaderboard.GetArray().Count; i++)
            {
                Console.WriteLine("Name: " + _leaderboard.GetArray()[i].GetName());
                Console.WriteLine("Score: " + _leaderboard.GetArray()[i].Score.Points);
                Console.WriteLine("Rating: " + _leaderboard.GetArray()[i].Rating.Stars);
                Console.WriteLine("Comment: " + _leaderboard.GetArray()[i].Comment.Notion);
                Console.WriteLine();
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
            }
        }

        public void LoadService()
        {
            _leaderboard.LoadLeaderboard();
            ShowScore();
        }
    }
}