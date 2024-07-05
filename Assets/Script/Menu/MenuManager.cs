using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _highScorePanel;
    
        void Start()
        {
            if (!PlayerPrefs.HasKey("GameLost"))
            {
                PlayerPrefs.SetInt("GameLost", 0);
                ShowMenuScreen();
            }
            else
            {
                var gameLost = PlayerPrefs.GetInt("GameLost");
                if (gameLost == 1)
                {
                    PlayerPrefs.SetInt("GameLost", 0);
                    ShowLoseGameScreen();
                }
                else
                {
                    ShowMenuScreen();
                }
            }
        }

        private void ShowLoseGameScreen()
        {
            _menuPanel.SetActive(false);
            _highScorePanel.SetActive(false);
            _gameOverPanel.SetActive(true);
        }

        public void ShowMenuScreen()
        {
            _gameOverPanel.SetActive(false);
            _highScorePanel.SetActive(false);
            _menuPanel.SetActive(true);
        }

        public void ShowHighScoreScreen()
        {
            _gameOverPanel.SetActive(false);
            _menuPanel.SetActive(false);
            _highScorePanel.SetActive(true);
        }

        public void Play()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
