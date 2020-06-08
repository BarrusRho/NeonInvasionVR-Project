using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("PlayerTarget").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
