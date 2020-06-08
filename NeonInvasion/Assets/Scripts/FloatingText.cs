using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField]
    private float destroyTime = 1.0f;

    private Vector3 offset = new Vector3(0, 0.2f, 0);

    //private Vector3 randomiseIntensity = new Vector3(2f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition += offset;

        //transform.localPosition += new Vector3(Random.Range(-randomiseIntensity.x, randomiseIntensity.x),
        //Random.Range(-randomiseIntensity.y, randomiseIntensity.y),
        //Random.Range(-randomiseIntensity.z, randomiseIntensity.z));

        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
