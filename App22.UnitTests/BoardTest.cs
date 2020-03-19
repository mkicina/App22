using App22.Game;
using NUnit.Framework;

namespace App22.UnitTests
{
    public class FieldTest
    {
        [Test]
        public void TestRowCount()
        {
            Board board = new Board(5, 5);
            Assert.AreEqual(5, board.RowCount);
        }
        
        [Test]
        public void TestColumnCount()
        {
            Board board = new Board(6, 6);
            Assert.AreEqual(6, board.ColumnCount);
        }
        
        [Test]
        public void TestIfBoardHasLight()
        {
            Board board = new Board(5, 5);
            Light light = new Light(false);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Assert.IsInstanceOf(light.GetType(),board[i,j]);        
                }   
            }
        }
        
        [Test]
        public void TestChangeState()
        {
            Board board = new Board(5, 5);
            Assert.IsFalse(board[2,2].GetState());
            board[2,2].ChangeState();
            Assert.IsTrue(board[2,2].GetState());
        }
        
        [Test]
        public void TestIfBoardIsSolved()
        {
            Board board = new Board(5, 5);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    board[i,j].SetState(false);
                }   
            }
            Assert.IsTrue(board.IsSolved());
        }
    }
}