using UnityEngine;

namespace Script.Character
{
    public class PlayerStats : MonoBehaviour
    {
        public int maxHealth = 100;
        public float speed = 10;

        // staty do broni

        public int damage = 10;
        public float projectalSpeed =30 ;
        public float cooldown = 1f;
        public float LiveTime = 2;
        public float size;
        public int penetration = 1;
    }
}