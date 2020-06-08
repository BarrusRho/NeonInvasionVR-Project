using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingOrb : MonoBehaviour
{
    [SerializeField]
    private AudioClip soundFX;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<AudioSource>().PlayOneShot(soundFX);
        }
    }
}
