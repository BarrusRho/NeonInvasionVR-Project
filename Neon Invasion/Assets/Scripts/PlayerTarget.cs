using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    public AudioClip glitchClip;

    private AudioSource glitchAudio;

    private TimeManager timeManager;

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private GameObject contactEffectPrefab;

    //private CameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();

        glitchAudio = GameObject.FindGameObjectWithTag("WallAudio").GetComponent<AudioSource>();

        //cameraShake = GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RedWalls")
        {
            //StartCoroutine(cameraShake.Shake(2f, 1f));

            glitchAudio.PlayOneShot(glitchClip);

            timeManager.SlowTime();

            Instantiate(contactEffectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }

        if (other.tag == "BlueWalls")
        {
            //StartCoroutine(cameraShake.Shake(2f, 1f));

            glitchAudio.PlayOneShot(glitchClip);

            timeManager.SlowTime();

            Instantiate(contactEffectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }


}
