using Script.Character;

namespace Script.Health
{
    public class PlayerHealthAttribute : HealthAttribute
    {
        public PlayerStats stats;

        public override void Start()
        {
            maxHealth = stats.maxHealth;
            base.Start();
        }

        public void RenewHealth()
        {
            CurrentHealth = stats.maxHealth;
            maxHealth = stats.maxHealth;
        }
    }
}