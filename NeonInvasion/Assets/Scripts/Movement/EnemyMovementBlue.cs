using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBlue : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * 2;

        if (transform.position.z <= -32)
        {
            Destroy(this.gameObject);
        }
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlueSaber")
        {
            Instantiate(effectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

            Destroy(this.gameObject, 0f);
        }

        if (other.tag == "Bullet")
        {
            Instantiate(effectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

            Destroy(this.gameObject, 0f);
        }
    }    
}
