using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnedProbes;

    [SerializeField]
    private GameObject[] spawnedVerticalWalls;

    [SerializeField]
    private GameObject[] spawnedHorizontalWalls;

    [SerializeField]
    private Transform[] spawnPointsProbes;

    [SerializeField]
    private Transform[] spawnPointsVerticalWalls;

    [SerializeField]
    private Transform[] spawnPointsHorizontalWalls;

    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        Invoke("StartWallsSpawn", Random.Range(5f, 10f));

        StartCoroutine(ProbeSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    
    void StartWallsSpawn()
    {
        StartCoroutine(VerticalWallsSpawnRoutine());

        StartCoroutine(HorizontalWallsSpawnRoutine());
    }

    IEnumerator ProbeSpawnRoutine()
    {
        while (true)
        {
            GameObject probes = Instantiate(spawnedProbes[Random.Range(0, 2)], spawnPointsProbes[Random.Range(0, 4)]);

            probes.transform.localPosition = Vector3.zero;

            probes.transform.Rotate(transform.up, 90 * Random.Range(0, 4));

            yield return new WaitForSeconds(Random.Range(gameManager.probeSpawnMin, gameManager.probeSpawnMax));
        }

    }

    IEnumerator VerticalWallsSpawnRoutine()
    {
        while (true)
        {
            GameObject verticalWall = Instantiate(spawnedVerticalWalls[Random.Range(0, 3)], spawnPointsVerticalWalls[Random.Range(0, 2)]);

            verticalWall.transform.localPosition = Vector3.zero;

            yield return new WaitForSeconds(Random.Range(gameManager.verticalWallSpawnMin, gameManager.verticalWallSpawnMax));
        }

    }

    IEnumerator HorizontalWallsSpawnRoutine()
    {
        while (true)
        {
            GameObject horizontalWall = Instantiate(spawnedHorizontalWalls[Random.Range(0, 3)], spawnPointsHorizontalWalls[Random.Range(0, 1)]);

            horizontalWall.transform.localPosition = Vector3.zero;

            yield return new WaitForSeconds(Random.Range(gameManager.horizontalWallSpawnMin, gameManager.horizontalWallSpawnMax));
        }

    }    
}
