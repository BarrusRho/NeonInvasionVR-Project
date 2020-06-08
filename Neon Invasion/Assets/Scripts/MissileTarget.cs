﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTarget : MonoBehaviour
{
    [SerializeField]
    private float force;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HomingMissile")
        {            
            Destroy(this.gameObject);
        }
    }
}
