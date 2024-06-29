using Script.Character;
using UnityEngine;

public class HealthAttribute : MonoBehaviour
{
    private int currentHealth;
    public int maxHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            if (currentHealth <= 0)
            {
                KillCharacter();
            }
        }
    }
    public virtual void Start()
    {
        currentHealth = maxHealth;
    }


    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

    }

    public virtual void KillCharacter()
    {
        Destroy(gameObject);
    }
}
