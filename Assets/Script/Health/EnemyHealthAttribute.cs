using Script.Exp;
using Script.Score;
using UnityEngine;

namespace Script.Health
{
    public class EnemyHealthAttribute : HealthAttribute
    {
        public int expValue = 10;
        public int currentEnemyHealth = 20;
        public ScoreAttribute score;
        
        private void Update()
        {
            if (currentEnemyHealth <= 0)
            {
                KillCharacter();
            }
        }



        public override void Start()
        {
            score = FindObjectOfType<ScoreAttribute>();
            base.Start();
        }

        public override void KillCharacter()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<ExpAttribute>().GainExp(expValue);
            score.AddToScore();
            base.KillCharacter();
            Destroy(this.gameObject);
        }

        public void DealDamage(int damage)
        {
            currentEnemyHealth -= damage;
        }
}
}