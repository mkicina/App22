using System;

namespace App22
{
    public class ConsoleUI
    {
        private Board _board;
        //private Game _game;
        
        public ConsoleUI(Board board)
        {
            _board = board;
        }
        
        public void PrintField()
        {
            Console.WriteLine();
            for (var row = 0; row < _board.RowCount; row++)
            {
                for (var column = 0; column < _board.ColumnCount; column++)
                {
                    var light = _board[row, column];
                    Console.Write(" ");
                    bool state = light.getState();
                    if (state)
                    {
                        Console.Write("{0, 2}", "0");
                    }

                    if (!state)
                    {
                        Console.Write("{0, 2}", "X");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        public void Play()
        {
            do
            {
                PrintField();
                ProcessInput();
            } while (!_board.IsSolved());
            

            PrintField();
            Console.WriteLine("You won level!");
        }
        
        private void ProcessInput()
        {
            Console.WriteLine("Enter row and column of your light: ");
            
            try
            {
                Console.Write("Enter row: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Enter column: ");
                int column = int.Parse(Console.ReadLine());
                _board.changeStates(row, column);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Row or column out of range!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter only numbers!");
            }
        }

    }
}