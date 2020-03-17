using System.Collections.Generic;
using System.Linq;

namespace App22.Scoreboard
{
    public class ScoreServiceFile : IScoreService
    {
        List<Score> scores = new List<Score>();

        public ScoreServiceFile()
        {
            /*scores.Add(new Score {Player = "Janko", Points = 200});
            scores.Add(new Score {Player = "Zuzka", Points = 100 });*/
        }

        public void AddScore(Score score)
        {
            scores.Add(score);
        }

        public IList<Score> GetTopScores()
        {
            return (from s in scores orderby s.Points 
                descending select s).Take(3).ToList();

            //return scores.OrderByDescending(s => s.Points).Select(s => s).Take(3).ToList();
        }

        public void ClearScores()
        {
            scores.Clear();
        }
    }
}