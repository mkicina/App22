namespace App22.Game
{
    static class Program
    {
        static void Main(string[] args){
            
        Board board=new Board(5,5);
            Level level = new Level(board);
            ConsoleUi ui = new ConsoleUi(board);
            Game game = new Game(ui, level);
            game.LoadService();
            game.SetupMenu();
        }
    }
}