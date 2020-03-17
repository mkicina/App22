using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace App22.Scoreboard
{
    public class Leaderboard
    {
        private List<Player> _board;

        public Leaderboard()
        {
            _board = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            _board.Add(player);
        }

        public List<Player> GetArray()
        {
            return _board;
        }

        public void SaveLeaderboard()
        {
            List<string> names = new List<string>();
            List<int> scores = new List<int>();
            List<int> ratings = new List<int>();
            List<string> comments = new List<string>();

            string fullPath = @"Service.txt";
            
            String str="";
            for (int i = 0; i < _board.Count; i++)
            {
                names.Add(_board[i].GetName());
                scores.Add(_board[i].Score.Points);
                ratings.Add(_board[i].Rating.Stars);
                comments.Add(_board[i].Comment.Notion);
            }

            for (int i = 0; i < _board.Count; i++)
            {
                str = str + names[i] + "\n" + scores[i] + "\n" + ratings[i] + "\n" + comments[i] + "\n";
            }
            File.WriteAllText(fullPath,str);
        }

        public void LoadLeaderboard()
        {
            string fullPath = @"Service.txt";
            string[] lines = File.ReadAllLines(fullPath);
            int size = lines.Length / 4;
            int k = 0;
            for (int i = 0; i < size; i++)
            {
                Player player = new Player(lines[k++]);
                _board.Add(player);
                
                Score score = new Score();
                score.Points = int.Parse(lines[k++]);
                player.Score = score;

                Rating rating = new Rating();
                rating.Stars = int.Parse(lines[k++]);
                player.Rating = rating;
                
                Comment comment = new Comment();
                comment.Notion = lines[k++];
                player.Comment = comment;
            }
        }
    }
}