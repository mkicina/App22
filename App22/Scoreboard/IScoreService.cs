using System.Collections.Generic;

namespace App22.Scoreboard
{
    public interface IScoreService
    {
        void AddScore(Score score);

        IList<Score> GetTopScores();

        void ClearScores();
    }
}