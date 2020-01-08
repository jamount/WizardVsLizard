using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class wavesystem : MonoBehaviour
{
    public float adjustmentAngle = 0;
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy1;
        public int count1;
        public float rate1;

        public Transform enemy2;
        public int count2;
        public float rate2;

        public Transform enemy3;
        public int count3;
        public float rate3;

        public Transform enemy4;
        public int count4;
        public float rate4;

        public Transform enemy5;
        public int count5;
        public float rate5;
    }

    public Wave[] waves;
    private int nextWave = 0;
    private int waveCount = 1;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    public Text waveSign;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        
        waveCountdown = timeBetweenWaves;

    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {

                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        waveCount++;
        waveSign.text = "WAVE " + waveCount;
        
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            SceneManager.LoadScene("You Win");
        }
        else
        {
            nextWave++;
        }
        
    }


    bool EnemyIsAlive()
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


    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count1; i++)
        {
            SpawnEnemy(_wave.enemy1);
            yield return new WaitForSeconds(1f / _wave.rate1);

        }

        for (int i = 0; i < _wave.count2; i++)
        {
            SpawnEnemy(_wave.enemy2);
            yield return new WaitForSeconds(1f / _wave.rate2);
        }

        for (int i = 0; i < _wave.count3; i++)
        {
            SpawnEnemy(_wave.enemy3);
            yield return new WaitForSeconds(1f / _wave.rate3);
        }

        for (int i = 0; i < _wave.count4; i++)
        {
            SpawnEnemy(_wave.enemy4);
            yield return new WaitForSeconds(1f / _wave.rate4);
        }

        for (int i = 0; i < _wave.count5; i++)
        {
            SpawnEnemy(_wave.enemy5);
            yield return new WaitForSeconds(1f / _wave.rate5);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy:" + _enemy.name);
        Transform _sp = spawnPoints[Random.Range(0,spawnPoints.Length)];

        
        
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
