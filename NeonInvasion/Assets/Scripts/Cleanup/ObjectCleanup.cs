using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCleanup : MonoBehaviour
{
    [SerializeField]
    private float timeUntilDestruction = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeUntilDestruction);
    }

}
