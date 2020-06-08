using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private OVRInput.Controller m_controller;

    public OVRInput.Button shootingButton;

    public GameObject firePoint;

    public GameObject exhaustPoint;

    [SerializeField]
    private GameObject exhaustEffect;

    private GameObject effectToSpawn;

    private float timeToFire = 0;

    public int maxNumberOfBullets = 100;

    public List<GameObject> vfx = new List<GameObject>();

    public TextMeshProUGUI bulletText;

    //public Text bulletText;

    //public AudioClip shootingAudio;


    // Start is called before the first frame update
    void Start()
    {
        bulletText =  GameObject.Find("BulletTextLeft_Text").GetComponent<TextMeshProUGUI>();

        //maxNumberOfBullets = 100;

        bulletText.text = maxNumberOfBullets.ToString();

        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shootingButton) && maxNumberOfBullets > 0 && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<BulletMove>().fireRate;

            SpawnVFX();

            ExhaustVFX();

            //GetComponent<AudioSource>().PlayOneShot(shootingAudio);

            maxNumberOfBullets--;

            bulletText.text = maxNumberOfBullets.ToString();            

            //bulletText.text = maxNumberOfBullets.ToString();
        }
    }

    void SpawnVFX()
    {
        //GameObject vfx;

        if (firePoint != null)
        {
            Instantiate(effectToSpawn, firePoint.transform.position, firePoint.transform.rotation).GetComponent<Rigidbody>().AddForce(firePoint.transform.forward * effectToSpawn.GetComponent<BulletMove>().speed);                      
        }
        else
        {
            Debug.Log("No fire point found");
        }
    }

    void ExhaustVFX()
    {
        GameObject exhaustVFX;

        if (exhaustPoint != null)
        {
            exhaustVFX = Instantiate(exhaustEffect, exhaustPoint.transform.position, exhaustEffect.transform.rotation);

            Destroy(exhaustVFX, 2f);
        }
        else
        {
            Debug.Log("No exhaust point found");
        }
    }
}
