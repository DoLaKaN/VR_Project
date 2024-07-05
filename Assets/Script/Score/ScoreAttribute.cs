using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Score
{
    public class ScoreAttribute : MonoBehaviour
    {
        private int currentScore = 0;


        public void AddToScore()
        {
            currentScore++;
        }

        public int GetScore()
        {
            return currentScore;
        }

        public void SaveScore()
        {
            PlayerPrefs.SetInt("LastScore", currentScore);
            var hasPreviousScores = PlayerPrefs.HasKey("HighScores");
            if (!hasPreviousScores)
            {
                PlayerPrefs.SetString("HighScores", $"{currentScore},");
            }
            else
            {
                var highScoresString = CreateHighScoreList();
                PlayerPrefs.SetString("HighScores", highScoresString);
            }
        }

        private string CreateHighScoreList()
        {
            var previousListString = PlayerPrefs.GetString("HighScores");
            var previousList = previousListString.Split(",");
            if (previousList.Length < 10)
            {
                var scores = previousList.Where(x => x != "").Select(x => Convert.ToInt32(x));
                scores = scores.Append(currentScore);
                var stringScores = scores.OrderByDescending(x => x).Select(x => x.ToString());
                var list = stringScores.ToSeparatedString(",");
                return list;
            }
            else
            {
                var scores = previousList.Select(x => Convert.ToInt32(x));
                var orderedScores = scores.OrderByDescending(x => x).ToList();
                orderedScores.RemoveAt(9);
                orderedScores.Add(currentScore);
                var list = orderedScores.Select(x => x.ToString()).ToSeparatedString("");
                return list;
            }
        }
    }
}