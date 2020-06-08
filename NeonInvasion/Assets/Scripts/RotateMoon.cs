using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMoon : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 2.0f;

    [SerializeField]
    private float orbitSpeed;

    [SerializeField]
    private GameObject earth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

        transform.RotateAround(earth.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
