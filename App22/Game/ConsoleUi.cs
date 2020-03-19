using System;

namespace App22.Game
{
    public class ConsoleUi
    {
        private readonly Board _board;
        private int _moves=0;
        
        public ConsoleUi(Board board)
        {
            _board = board;
        }

        private void Print()
        {
            Console.WriteLine();
            for (var row = 0; row < _board.RowCount; row++)
            {
                for (var column = 0; column < _board.ColumnCount; column++)
                {
                    var light = _board[row, column];
                    Console.Write(" ");
                    bool state = light.GetState();
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
        
        public void Run()
        {
            do
            {
                Print();
                ProcessInput();
                _moves++;
            } while (!_board.IsSolved());
            
            Print();
            Console.WriteLine("You won level!");
        }

        public int GetMoves()
        {
            return _moves;
        }

        public void SetMoves(int moves)
        {
            _moves = moves;
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
                _board.ChangeStates(row, column);
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