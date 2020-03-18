namespace App22
{
    public class Board
    {
        private readonly Light[,] _lights;


        public int RowCount { get; private set; }

        public int ColumnCount { get; private set; }



        public Board(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            _lights = new Light[RowCount, ColumnCount];
            Initiliaze();
        }

        public void Initiliaze()
        {
            for (var row = 0; row < RowCount; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    _lights[row, column] = new Light(false);
                }
            }
        }

        public Light GetTile(int row, int column)
        {
            return _lights[row, column];
        }

        public Light this[int row, int column]
        {
            get { return _lights[row, column]; }
        }
        

        public void changeStates(int row, int column)
        {
            var light = GetTile(row, column);
            light.changeState();
            if (row - 1 >= 0)
            {
                GetTile(row-1, column).changeState();   
            }
            if (column - 1 >= 0)
            {
                GetTile(row, column-1).changeState();
            }
            if (row + 1 < RowCount)
            {
                GetTile(row+1, column).changeState();
            }
            if (column + 1 < ColumnCount)
            {
                GetTile(row, column+1).changeState();
            }
        }

        public bool IsSolved()
        {
            for (var row = 0; row < RowCount; row++)
                {
                    for (var column = 0; column < ColumnCount; column++)
                    {
                        if (_lights[row, column].getState())
                        {
                            return false;
                        }
                    }
                }
            return true;
        }
        
    }
}