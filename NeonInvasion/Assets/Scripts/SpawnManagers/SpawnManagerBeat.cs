using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerBeat : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnedCubes;

    [SerializeField]
    private GameObject[] spawnedVerticalWalls;

    [SerializeField]
    private GameObject[] spawnedHorizontalWalls;

    [SerializeField]
    private Transform[] spawnPointsCubes;

    [SerializeField]
    private Transform[] spawnPointsVerticalWalls;

    [SerializeField]
    private Transform[] spawnPointsHorizontalWalls;

    [SerializeField]
    private float cubeBeat = (60/105) * 2;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartWallsSpawn", Random.Range(5, 10));
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > cubeBeat)
        {
            SpawnCubes();

            //SpawnVerticalWalls();

            //SpawnHorizontalWalls();            
        }
                
        timer += Time.deltaTime;        
    }

    void SpawnCubes()
    {
        GameObject cube = Instantiate(spawnedCubes[Random.Range(0, 2)], spawnPointsCubes[Random.Range(0, 4)]);

        cube.transform.localPosition = Vector3.zero;

        cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));

        timer -= cubeBeat;
    }

    /*void SpawnVerticalWalls()
    {
        GameObject verticalWall = Instantiate(spawnedVerticalWalls[Random.Range(0, 2)], spawnPointsVerticalWalls[Random.Range(0, 2)]);

        verticalWall.transform.localPosition = Vector3.zero;

        //cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));

        timer -= cubeBeat;
    }

    void SpawnHorizontalWalls()
    {
        GameObject horizontalWall = Instantiate(spawnedHorizontalWalls[Random.Range(0, 2)], spawnPointsHorizontalWalls[Random.Range(0, 1)]);

        horizontalWall.transform.localPosition = Vector3.zero;

        //cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));

        timer -= cubeBeat;
    }*/

    void StartWallsSpawn()
    {
        StartCoroutine(VerticalWallsSpawnRoutine());

        StartCoroutine(HorizontalWallsSpawnRoutine());
    }

    IEnumerator VerticalWallsSpawnRoutine()
    {
        while (true)
        {
            GameObject verticalWall = Instantiate(spawnedVerticalWalls[Random.Range(0, 3)], spawnPointsVerticalWalls[Random.Range(0, 2)]);

            verticalWall.transform.localPosition = Vector3.zero;

            yield return new WaitForSeconds(Random.Range(10f, 20f));
        }

    }

    IEnumerator HorizontalWallsSpawnRoutine()
    {
        while (true)
        {
            GameObject horizontalWall = Instantiate(spawnedHorizontalWalls[Random.Range(0, 3)], spawnPointsHorizontalWalls[Random.Range(0, 1)]);

            horizontalWall.transform.localPosition = Vector3.zero;

            yield return new WaitForSeconds(Random.Range(10f, 20f));
        }

    }    
}
