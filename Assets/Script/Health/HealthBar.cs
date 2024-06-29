using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public HealthAttribute healthAttribute;
    private void Start()
    {
        healthBar.maxValue = healthAttribute.maxHealth;
    }
    private void Update()
    {
        healthBar.maxValue = healthAttribute.maxHealth;
        healthBar.value = healthAttribute.CurrentHealth;
    }
}
