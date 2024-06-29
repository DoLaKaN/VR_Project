using Script.Exp;
using UnityEngine;

namespace Script.Health
{
    public class EnemyHealthAttribute : HealthAttribute
    {
        public int expValue = 10;

        public override void Start()
        {
            maxHealth = 100;
            base.Start();
        }

        public override void KillCharacter()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<ExpAttribute>().GainExp(expValue);
            base.KillCharacter();
        }
    }
}