using TMPro;
using UnityEngine;

namespace Script.Menu
{
    public class HighScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _leaderboadText;
    
        // Start is called before the first frame update
        void Start()
        {
            if (PlayerPrefs.HasKey("HighScores"))
                GetScoresAndCreateHighScoreTable();
            else
            {
                _leaderboadText.text = "No high scores available";
            }
        }

        private void GetScoresAndCreateHighScoreTable()
        {
            var scores = PlayerPrefs.GetString("HighScores");
            var scoreArray = scores.Split(",");
            var leaderboardContent = "";
            for (int i = 0; i < scoreArray.Length; i++)
            {
                leaderboardContent += $"{i+1}. {scoreArray[i]} <br>";
            }

            _leaderboadText.text = leaderboardContent;
        }
    }
}
