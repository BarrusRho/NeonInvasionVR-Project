using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomingSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnedEnemy;

    [SerializeField]
    private Transform[] spawnPoints;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        StartCoroutine(HomingEnemySpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HomingEnemySpawnRoutine()
    {
        while (true)
        {
            GameObject missile = Instantiate(spawnedEnemy[Random.Range(0, 8)], spawnPoints[Random.Range(0, 8)]);

            missile.transform.localPosition = Vector3.zero;

            yield return new WaitForSeconds(Random.Range(gameManager.enemySpawnMin, gameManager.enemySpawnMax));
        }
              
    }
}
