using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnedMissile;

    [SerializeField]
    private Transform[] spawnPoints;  

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MissileSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MissileSpawnRoutine()
    {
        while (true)
        {
            GameObject missile = Instantiate(spawnedMissile[Random.Range(0, 2)], spawnPoints[Random.Range(0, 5)]);

            missile.transform.localPosition = Vector3.zero;

            yield return new WaitForSeconds(Random.Range(2f, 8f));
        }
              
    }
}
