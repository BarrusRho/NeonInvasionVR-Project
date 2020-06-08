using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    //public AudioClip glitchClip;

    //private AudioSource glitchAudio;

    private UIManager uiManager;    

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();

        //glitchAudio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
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
        if (other.tag == "Player")
        {
            uiManager.PlayerDamageFromWall();

            //glitchAudio.PlayOneShot(glitchClip);

            //Destroy(this.gameObject, 0f);            
        }      
    }


    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasEntered)
        {
            hasEntered = true;

            uiManager.PlayerDamageFromWall();           

            Destroy(this.gameObject, 0f);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasEntered == true)
        {
            hasEntered = false;
        }
    }*/
}
