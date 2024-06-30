using Script.Exp;
using UnityEngine;

namespace Script.Health
{
    public class EnemyHealthAttribute : HealthAttribute
    {
        public int expValue = 10;
        public int currentEnemyHealth = 20;


        private void Update()
        {
            if (currentEnemyHealth <= 0)
            {
                KillCharacter();
            }
        }



        public override void Start()
        {
            base.Start();
        }

        public override void KillCharacter()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<ExpAttribute>().GainExp(expValue);
            base.KillCharacter();
            Destroy(this.gameObject);
        }

        public void DealDamage(int damage)
        {
            currentEnemyHealth -= damage;
        }
}
}