using System;

namespace App22
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Board board=new Board(5,5);
            Level level = new Level(board);
            ConsoleUI ui = new ConsoleUI(board);
            Game game = new Game(ui, board, level);
            game.Start();

            /*level.setLevelTwo();
            ui.PrintField();
            ui.Play();*/
            /*board.changeStates(1,1);
            ui.PrintField();
            board.changeStates(1,2);
            ui.PrintField();*/
        }
    }
}