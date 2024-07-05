using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Enemy
    {
        [SerializeField] internal Transform EnemyTransform;
        [SerializeField] internal Damage EnemyDamageComponent;
        [SerializeField] internal HealthAttribute EnemyHealthAttributeComponent;
        [SerializeField] internal int HealthBase;
        [SerializeField] internal int DamageBase;
        [SerializeField] internal int HealthIncreasePerWave;
        [SerializeField] internal int DamageIncreasePerWave;
    }
    [System.Serializable]
    public class Wave
    {
        [SerializeField] string Name;
        [SerializeField] internal Enemy[] Enemies;
        [SerializeField] internal int EnemyCountBase;
        internal int EnemyCount;
        [SerializeField] internal float RateBase;
        internal float rate;
        [SerializeField] internal int EnemyCountIncrease;
        [SerializeField] internal float RateIncrease;       
    }
    [SerializeField] GameObject Target;
    [SerializeField] Wave wave;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] TextMeshProUGUI TextRoundCounter;
    [SerializeField] TextMeshProUGUI TextWaveCounter;
    [SerializeField] SpawnState state = SpawnState.COUNTING;

    private int _round = 1;
    private float _waveCountdown;
    private float _searchCountdown = 5f;
    
    private void Awake()
    {
        wave.EnemyCount = wave.EnemyCountBase;
        wave.rate = wave.RateBase;
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
       _waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        printWaveNumber();
        if (state == SpawnState.WAITING) 
        {
            if (!enemyIsAlive())
            {
                
                waveCompleted();
            }
            else
            {
                return;
            }
        }
        if (_waveCountdown <= 0)
        {   
            TextRoundCounter.gameObject.SetActive(false);
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(spawnWave(wave));
            }          
        }
        else
        {
            TextRoundCounter.gameObject.SetActive(true);
            printCountdownTimer();
            _waveCountdown -= Time.deltaTime;
        }
    }

    private void printCountdownTimer()
    {
        var text = (int)_waveCountdown;
        TextRoundCounter.text = "Round starts in: " + text.ToString();
    }

    private void printWaveNumber()
    {
        TextWaveCounter.text = "Wave: " + _round.ToString();
    }
    private void waveCompleted()
    {
        Debug.Log("Wave complete");
        state = SpawnState.COUNTING;
        _waveCountdown = timeBetweenWaves;
        increaseDifficultyWave(_round);
        _round++;
    }
    private void increaseDifficultyWave(int waveNumber)
    {
        for (int i = 0; i < wave.Enemies.Length; i++)
        {
            var baseHealth = wave.Enemies[i].HealthBase; 
            var baseDamage = wave.Enemies[i].DamageBase; 
            var healthIncrease = wave.Enemies[i].HealthIncreasePerWave; 
            var damageIncrease = wave.Enemies[i].DamageIncreasePerWave;

            wave.Enemies[i].EnemyHealthAttributeComponent.maxHealth = baseHealth + (healthIncrease * waveNumber);
            wave.Enemies[i].EnemyDamageComponent.DamageValue = baseDamage + (damageIncrease * waveNumber);
        }
        var baseEnemyCount = wave.EnemyCountBase;
        var baseRate = wave.RateBase;
        var enemyCountIncrease = wave.EnemyCountIncrease;
        var rateIncrease = wave.RateIncrease;

        wave.EnemyCount = baseEnemyCount + (enemyCountIncrease * waveNumber);
        wave.rate = baseRate + (rateIncrease * waveNumber);
    }

    private bool enemyIsAlive()
    {
        _searchCountdown -= Time.deltaTime;
        if (_searchCountdown <= 0f)
        {
            _searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        
        return true;
    }

    IEnumerator spawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;
        for(int i = 0; i < wave.EnemyCount; i++)
        {
            spawnEnemy(wave.Enemies[ Random.Range(0, wave.Enemies.Length) ].EnemyTransform);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }
    private void spawnEnemy(Transform enemy)
    {
        Debug.Log("spawn enemy");
        enemy.GetComponent<EnemyRush>().Target = Target;
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
    }
}
