using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShellMovementBlueLeft : MonoBehaviour
{
    private bool hasEntered;

    [SerializeField]
    private GameObject explosionEffectPrefab;

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private GameObject powerUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.right * 2;

        if (transform.position.x >= 14)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBullet") && !hasEntered)
        {
            hasEntered = true;            

            Instantiate(explosionEffectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

            Instantiate(powerUpPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

            Destroy(this.gameObject, 0f);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBullet") && hasEntered == true)
        {
            hasEntered = false;
        }
    }
}
