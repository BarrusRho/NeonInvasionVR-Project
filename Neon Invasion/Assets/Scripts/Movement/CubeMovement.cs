using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
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
        if (other.tag == "BlueWalls")
        {
            Destroy(this.gameObject, 0f);
        }

        if (other.tag == "RedWalls")
        {
            Destroy(this.gameObject, 0f);
        }
    }
}
