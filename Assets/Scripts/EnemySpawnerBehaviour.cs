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
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemies());
	}
	public IEnumerator SpawnEnemies()
    {
        for(int i = 0; i < enemyAmount; i++)
        {
            enemy.playerTransform = playerTransform;
            Instantiate(enemy.gameObject, transform.position, transform.rotation);
            yield return new WaitForSeconds(timer);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
