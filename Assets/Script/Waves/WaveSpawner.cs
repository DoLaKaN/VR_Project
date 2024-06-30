using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    public GameObject Target;
    [System.Serializable]
    public class Enemy
    {
        public Transform EnemyTransform;
        public Damage EnemyDamageComponent;
        public HealthAttribute EnemyHealthAttributeComponent;
        public int HealthBase;
        public int DamageBase;
        public int HealthIncreasePerWave;
        public int DamageIncreasePerWave;
    }
    [System.Serializable]
    public class Wave
    {
        public string Name;
        public Enemy[] Enemies;
        public int EnemyCountBase;
        internal int EnemyCount;
        public float RateBase;
        internal float rate;
        public int EnemyCountIncrease;
        public float RateIncrease;

        public Wave()
        {
            EnemyCount = EnemyCountBase;
            rate = RateBase;
        }
        
    }
    public Wave wave;
    public Transform[] spawnPoints;
    private int round = 1;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private float searchCountdown = 5f;
    public SpawnState state = SpawnState.COUNTING;
    private void Awake()
    {

        for (int i = 0; i < wave.Enemies.Length; i++)
        {
            wave.Enemies[i].EnemyHealthAttributeComponent.maxHealth = wave.Enemies[i].HealthBase;
            wave.Enemies[i].EnemyDamageComponent.DamageValue = wave.Enemies[i].DamageBase;
        }
    }
    private void Start()
    {
        if(spawnPoints.Length == 0)
        {
            Debug.LogError("There is no spawn points");
        }
       waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == SpawnState.WAITING) 
        {
            if (!EnemyIsalive())
            {
                
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(wave));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave complete");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        //if(nextWave +1 > waves.Length - 1)
        //{
        //    nextWave = 0;
        //    Debug.Log("All waves complete");
        //}
        //else
        //{
        increaseDifficultyWave(round);
        round++;
        //}
        
    }
    void increaseDifficultyWave(int waveNumber)
    {
        for (int i = 0; i < wave.Enemies.Length; i++)
        {
            var baseHealth = wave.Enemies[i].HealthBase; 
            var baseDamage = wave.Enemies[i].DamageBase; 
            var healthIncrease = wave.Enemies[i].HealthIncreasePerWave; 
            var damageIncrease = wave.Enemies[i].DamageIncreasePerWave;

            var healthFormula = baseHealth + (healthIncrease * waveNumber);
            var damageFormula = baseDamage + (damageIncrease * waveNumber);

            wave.Enemies[i].EnemyHealthAttributeComponent.maxHealth = healthFormula;
            wave.Enemies[i].EnemyDamageComponent.DamageValue = damageFormula;
        }
        var baseEnemyCount = wave.EnemyCountBase;
        var baseRate = wave.RateBase;
        var enemyCountIncrease = wave.EnemyCountIncrease;
        var rateIncrease = wave.RateIncrease;

        var enemyCountFormula = baseEnemyCount + (enemyCountIncrease * waveNumber);
        var rateCountFormula = baseRate + (rateIncrease * waveNumber);

        wave.EnemyCount = enemyCountFormula;
        wave.rate = rateCountFormula;
    }

    bool EnemyIsalive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        
        return true;
    }

    IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;
        for(int i = 0; i < wave.EnemyCount; i++)
        {
            SpawnEnemy(wave.Enemies[ Random.Range(0, wave.Enemies.Length) ].EnemyTransform);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform enemy)
    {
        Debug.Log("spawn enemy");
        enemy.GetComponent<EnemyRush>().Target = Target;
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
    }
}
