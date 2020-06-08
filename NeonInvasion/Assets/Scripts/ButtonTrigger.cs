using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject missilePrefab;

    [SerializeField]
    private GameObject homingMissile;

    [SerializeField]
    private GameObject targetPrefab;

    [SerializeField]
    private Transform missileSpawnPoint;

    [SerializeField]
    private Transform targetSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button")
        {
            //Instantiate(targetPrefab, targetSpawnPoint.position, Quaternion.identity);

            Instantiate(missilePrefab, missileSpawnPoint.position, Quaternion.identity);

            if (homingMissile != null)
            {
                homingMissile.SetActive(true);
            }                           

            //Transofrm t = Instantiate(targetPrefab);

            //t.position = targetSpawnPoint.position;

            //Transform m = Instantiate(missilePrefab);

            //m.position = missileSpawnPoint.position;
        }
    }

}
