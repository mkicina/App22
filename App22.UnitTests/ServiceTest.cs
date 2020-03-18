using App22.Scoreboard;
using NUnit.Framework;

namespace App22.UnitTests
{
    public class ServiceTest
    {
        [Test]
        public void TestAddPlayerToLeaderboard()
        {
            Leaderboard leaderboard = new Leaderboard();
            Player player1 = new Player("Ondrej");
            Player player2 = new Player("Lubos");
            leaderboard.AddPlayer(player1);
            leaderboard.AddPlayer(player2);
            
            Assert.AreEqual(player1,leaderboard.GetArray()[0]);
            Assert.AreEqual(player2,leaderboard.GetArray()[1]);
        }
        
        
        [Test]
        public void TestPlayerName()
        {
            Player player1 = new Player("Ondrej");
            Player player2 = new Player("Lubos");

            Assert.AreEqual(player1.GetName(),"Ondrej");
            Assert.AreEqual(player2.GetName(),"Lubos");
        }
        
        [Test]
        public void TestPlayerScore()
        {
            Player player1 = new Player("Ondrej");
            Player player2 = new Player("Lubos");
            Score score1 = new Score();
            Score score2 = new Score();
            score1.Points = 5;
            score2.Points = 7;

            player1.Score = score1;
            player2.Score = score2;

            Assert.AreEqual(player1.Score.Points,5);
            Assert.AreEqual(player2.Score.Points,7);
        }
        
        [Test]
        public void TestPlayerRating()
        {
            Player player1 = new Player("Ondrej");
            Player player2 = new Player("Lubos");
            Rating rating1 = new Rating();
            Rating rating2 = new Rating();
            rating1.Stars = 2;
            rating2.Stars = 5;

            player1.Rating = rating1;
            player2.Rating = rating2;
            
            Assert.AreEqual(player1.Rating.Stars,2);
            Assert.AreEqual(player2.Rating.Stars,5);
        }
        
        [Test]
        public void TestPlayerComment()
        {
            Player player1 = new Player("Ondrej");
            Player player2 = new Player("Lubos");
            Comment comment1 = new Comment();
            Comment comment2 = new Comment();
            comment1.Notion =
                "Tato hra sa mi velmi pacila, urcite si ju znova zahram ale az ked si spravim domacu ulohu";
            comment2.Notion = "Hra je onicom, neviem ani jak ju mam ovladat, neodporucam nikomu";

            player1.Comment = comment1;
            player2.Comment = comment2;

            Assert.AreEqual(player1.Comment.Notion,
                "Tato hra sa mi velmi pacila, urcite si ju znova zahram ale az ked si spravim domacu ulohu");
            Assert.AreEqual(player2.Comment.Notion,
                "Hra je onicom, neviem ani jak ju mam ovladat, neodporucam nikomu");
        }
        
    }
}