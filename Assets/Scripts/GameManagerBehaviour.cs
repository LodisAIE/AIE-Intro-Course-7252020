using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    public List<EnemySpawnerBehaviour> enemySpawners;
    public int waveCount;
    public float spawnDelayTimer;
    bool isSpawning =false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave());
    }
    public IEnumerator SpawnWave()
    {
        isSpawning = true;
        yield return new WaitForSeconds(spawnDelayTimer);
        foreach(EnemySpawnerBehaviour spawner in enemySpawners)
        {
            StartCoroutine(spawner.SpawnEnemies());
        }
        waveCount--;
        isSpawning = false;
    }
    public bool CheckWaveCleared()
    {
        bool waveCleared = true;
        foreach(EnemySpawnerBehaviour spawner in enemySpawners)
        {
            foreach(GameObject enemy in spawner.enemies)
            {
                if(enemy != null)
                {
                    waveCleared = false;
                }
            }
        }
        return waveCleared;
    }
    // Update is called once per frame
    void Update()
    {
        if(CheckWaveCleared() && waveCount > 0 && isSpawning == false)
        {
            StartCoroutine(SpawnWave());
        }
    }
}
