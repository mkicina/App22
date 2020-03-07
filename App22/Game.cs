using System;

namespace App22
{
    public class Game
    {
        private ConsoleUI _consoleUi;
        private Board _board;
        private Level _level;
        private int levelNum = 1;
        public Game(ConsoleUI consoleUi, Board board,Level level)
        {
            _consoleUi = consoleUi;
            _board = board;
            _level = level;
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

        public void Start()
        {
            do
            {
                _level.NextLevel(levelNum);
                _consoleUi.PrintField();
                _consoleUi.Play();
                levelNum++;
            } while (!IsGameWon());
            
            
            
        }
        
    }
}