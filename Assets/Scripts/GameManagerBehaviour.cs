using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagerBehaviour : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject player;
    public HealthBehaviour playerHealth;
    public Text gameOverText;
    public Text healthText;
    public Text waveText;
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
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if(CheckWaveCleared() && waveCount > 0 && isSpawning == false)
        {
            StartCoroutine(SpawnWave());
        }
        if(player == null)
        {
            gameOverText.text = "You Died";
            gameOverText.color = Color.red;
            gameOverScreen.SetActive(true);
        }
        else if(CheckWaveCleared() && waveCount<= 0)
        {
            gameOverText.text = "You won!!";
            gameOverText.color = Color.green;
            gameOverScreen.SetActive(true);
        }
        healthText.text = "Health: " + playerHealth.GetHealth();
        waveText.text = "Waves: " + waveCount;
    }
}
