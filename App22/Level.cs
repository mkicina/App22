namespace App22
{
    public class Level
    {
        private Board _board;

        public Level(Board board)
        {
            this._board = board;
        }

        public void NextLevel(int levelNum)
        {
            _board.Initiliaze();
            switch (levelNum)
            {
                case 1:
                    setLevelOne();
                    break;
                case 2:
                    setLevelTwo();
                    break;

                case 3:
                    setLevelThree();
                    break;

                case 4:
                    setLevelFour();
                    break;
            }
        }

        public void setLevelOne()
        {
            _board[0, 0].setState(true);
            _board[1, 0].setState(true);
            _board[0, 1].setState(true);
        }
        
        public void setLevelTwo()
        {
            _board[0, 0].setState(true);
            _board[1, 0].setState(true);
            _board[0, 1].setState(true);
            _board[4, 4].setState(true);
            _board[3, 4].setState(true);
            _board[4, 3].setState(true);
        }
        
        public void setLevelThree()
        {
            _board[0, 0].setState(true);
            _board[1, 0].setState(true);
            _board[0, 1].setState(true);
        }
        
        public void setLevelFour()
        {
            _board[0, 0].setState(true);
            _board[1, 0].setState(true);
            _board[0, 1].setState(true);
        }
        
    }
}