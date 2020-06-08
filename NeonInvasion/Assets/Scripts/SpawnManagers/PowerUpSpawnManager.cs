using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnedPowerUpLeft;

    [SerializeField]
    private GameObject[] spawnedPowerUpRight;

    [SerializeField]
    private Transform[] spawnPointsLeftPowerUp;

    [SerializeField]
    private Transform[] spawnPointsRightPowerUp;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        Invoke("StartPowerUpSpawning", Random.Range(5f, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartPowerUpSpawning()
    {
        StartCoroutine(PowerUpLeftSpawnRoutine());

        StartCoroutine(PowerUpRightSpawnRoutine());
    }

    IEnumerator PowerUpLeftSpawnRoutine()
    {
        while (true)
        {
            GameObject powerUp = Instantiate(spawnedPowerUpLeft[Random.Range(0, 2)], spawnPointsLeftPowerUp[Random.Range(0, 4)]);

            powerUp.transform.localPosition = Vector3.zero;

            //powerUp.transform.Rotate(transform.up, 90 * Random.Range(0, 4));

            yield return new WaitForSeconds(Random.Range(gameManager.powerUpSpawnMin, gameManager.powerUpSpawnMax));
        }

    }

    IEnumerator PowerUpRightSpawnRoutine()
    {
        while (true)
        {
            GameObject powerUp = Instantiate(spawnedPowerUpRight[Random.Range(0, 2)], spawnPointsRightPowerUp[Random.Range(0, 4)]);

            powerUp.transform.localPosition = Vector3.zero;

            //powerUp.transform.Rotate(transform.up, 90 * Random.Range(0, 4));

            yield return new WaitForSeconds(Random.Range(gameManager.powerUpSpawnMin, gameManager.powerUpSpawnMax));
        }

    }
}
