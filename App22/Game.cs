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
        private Player _player;
        
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
                _consoleUi.Play();
                levelNum++;
            } while (!IsGameWon());
            _player.SetMoves(_consoleUi.GetMoves());
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
                Console.WriteLine("Score: " + _leaderboard.GetArray()[i].GetScore());
            }
        }
        
    }
}