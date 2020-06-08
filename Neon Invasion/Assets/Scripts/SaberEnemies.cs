using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberEnemies : MonoBehaviour
{
    [SerializeField]
    private LayerMask layer;
    
    //[SerializeField]
    //private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            Destroy(hit.transform.gameObject);
        }
        //previousPosition = transform.position;
    }   
}
