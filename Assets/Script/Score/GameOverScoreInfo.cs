using TMPro;
using UnityEngine;

namespace Script.Score
{
    public class GameOverScoreInfo : MonoBehaviour
    {
        public TextMeshProUGUI scoreInfo;
    
        // Start is called before the first frame update
        void Start()
        {
            var score = PlayerPrefs.GetInt("LastScore");
            scoreInfo.text = $"Score: {score}";
        }
    }
}
