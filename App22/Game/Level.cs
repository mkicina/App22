namespace App22.Game
{
    public class Level
    {
        private readonly Board _board;

        public Level(Board board)
        {
            _board = board;
        }

        public void NextLevel(int levelNum)
        {
            _board.Initiliaze();
            switch (levelNum)
            {
                case 1:
                    SetLevelOne();
                    break;
                case 2:
                    SetLevelTwo();
                    break;

                case 3:
                    SetLevelThree();
                    break;
            }

            void SetLevelOne()
            {
                _board[0, 0].SetState(true);
                _board[1, 0].SetState(true);
                _board[1, 1].SetState(true);
                _board[2, 0].SetState(true);
            }

            void SetLevelTwo()
            {
                _board[3, 0].SetState(true);
                _board[4, 0].SetState(true);
                _board[4, 1].SetState(true);
                _board[2, 2].SetState(true);
                _board[2, 1].SetState(true);
                _board[1, 2].SetState(true);
                _board[2, 3].SetState(true);
                _board[3, 2].SetState(true);
            }

            void SetLevelThree()
            {
                _board[1, 1].SetState(true);
                _board[1, 0].SetState(true);
                _board[0, 1].SetState(true);
                _board[1, 2].SetState(true);
                _board[2, 1].SetState(true);

                _board[3, 4].SetState(true);
                _board[3, 3].SetState(true);
                _board[3, 2].SetState(true);
                _board[2, 3].SetState(true);
                _board[4, 3].SetState(true);
            }
        }
    }
}