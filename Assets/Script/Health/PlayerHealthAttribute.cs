using Script.Character;
using Script.Score;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Health
{
    public class PlayerHealthAttribute : HealthAttribute
    {
        public PlayerStats stats;
        public ScoreAttribute score;

        public override void Start()
        {
            score = FindObjectOfType<ScoreAttribute>();
            maxHealth = stats.maxHealth;
            base.Start();
        }

        public void RenewHealth()
        {
            CurrentHealth = stats.maxHealth;
            maxHealth = stats.maxHealth;
        }

        public override void KillCharacter()
        {
            PlayerPrefs.SetInt("GameLost", 1);
            base.KillCharacter();
            score.SaveScore();
            SceneManager.LoadScene("MenuScene");
        }
    }
}