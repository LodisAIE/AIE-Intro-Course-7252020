using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour {
    [SerializeField]
    private EnemyMovementBehaviour enemy;
    [SerializeField]
    private float timer;
    [SerializeField]
    private int enemyAmount;
    [SerializeField]
    private Transform playerTransform;
    public bool isSpawning;
    public List<GameObject> enemies;
	// Use this for initialization
	void Start () {
        enemies = new List<GameObject>();
	}
	public IEnumerator SpawnEnemies()
    {
        isSpawning = true;
        for(int i = 0; i < enemyAmount; i++)
        {
            enemy.playerTransform = playerTransform;
            GameObject enemyObject =Instantiate(enemy.gameObject, transform.position, transform.rotation);
            enemies.Add(enemyObject);
            yield return new WaitForSeconds(timer);
        }
        isSpawning = false;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
