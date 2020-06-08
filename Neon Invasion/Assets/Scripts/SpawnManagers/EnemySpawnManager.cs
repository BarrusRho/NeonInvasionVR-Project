using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnedEnemy;

    [SerializeField]
    private Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {
            GameObject enemy = Instantiate(spawnedEnemy[Random.Range(0, 8)], spawnPoints[Random.Range(0, 4)]);

            enemy.transform.localPosition = Vector3.zero;

            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }

    }
}
