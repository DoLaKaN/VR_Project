using System;
using System.Collections.Generic;
using Script.Character;
using Script.Health;
using UnityEngine;

namespace Script.Exp
{
    public enum Upgrades
    {
        Health, Speed
    }
    
    public class ExpAttribute : MonoBehaviour
    {
        public int expForNextLvl = 100;
        public int currentExp;
        public int level = 1;
        List<Upgrades> upgrades = new List<Upgrades> { Upgrades.Health, Upgrades.Speed };
        private int lastUpgrade = 0;
        public PlayerHealthAttribute healthAttribute;
        public PlayerStats stats;
        public int healthUpgrade = 100;
        public float speedUpgrade = 2;

        public int CurrentExp
        {
            get { return currentExp; }
            set
            {
                currentExp = value;
                if (currentExp >= expForNextLvl)
                {
                    LevelUp();
                }
            }
        }

        public void Start()
        {
            currentExp = 0;
        }

        public void GainExp(int exp)
        {
            CurrentExp += exp;
        }

        private void LevelUp()
        {
            level++;
            currentExp -= expForNextLvl;
            healthAttribute.RenewHealth();

            switch (upgrades[lastUpgrade])
            {
                case Upgrades.Health:
                    stats.maxHealth += healthUpgrade;
                    break;
                case Upgrades.Speed:
                    stats.speed += speedUpgrade;
                    break;
            }

            lastUpgrade = lastUpgrade >= upgrades.Count - 1 ? 0 : lastUpgrade + 1;
        }
    }
}