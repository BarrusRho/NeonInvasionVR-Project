using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeCounter : MonoBehaviour
{
    private UIManager uiManager;

    [SerializeField]
    public float missedCubesCurrent;

    [SerializeField]
    private float missedCubesTotal;

    [SerializeField]
    private GameObject[] spawnedAsteroid;

    [SerializeField]
    private Transform[] asteroidSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (missedCubesCurrent >= 6.0f)
        {
            SpawnAsteroids();

            StartCoroutine(AsteroidWarningRoutine());

            missedCubesCurrent = 0f;
        }

        if (missedCubesCurrent <= 6.0f)
        {
            StopCoroutine(AsteroidWarningRoutine());            
        }

    }

    void SpawnAsteroids()
    {
        GameObject asteroid = Instantiate(spawnedAsteroid[Random.Range(0, 1)], asteroidSpawnPoints[Random.Range(0, 4)]);

        asteroid.transform.localPosition = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlueCubes")
        {
            missedCubesCurrent = missedCubesCurrent + 0.5f;

            missedCubesTotal = missedCubesTotal + 0.5f;
        }

        if (other.tag == "RedCubes")
        {
            missedCubesCurrent = missedCubesCurrent + 0.5f;

            missedCubesTotal = missedCubesTotal + 0.5f;
        }
    }
    IEnumerator AsteroidWarningRoutine()
    {
        uiManager.AsteroidWarningEnable();

        yield return new WaitForSeconds(2f);

        uiManager.AsteroidWarningDisable();
    }
}
