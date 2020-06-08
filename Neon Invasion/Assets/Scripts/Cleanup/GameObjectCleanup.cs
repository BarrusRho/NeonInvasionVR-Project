using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectCleanup : MonoBehaviour
{
    [SerializeField]
    private float destructionTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destructionTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
