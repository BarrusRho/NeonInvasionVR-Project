using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootLeftGun : MonoBehaviour
{
    [SerializeField]
    private OVRInput.Controller m_controller;

    public OVRInput.Button shootingButton;

    public OVRInput.Button reloadButton;

    public GameObject firePoint;

    //public GameObject exhaustPoint;

    //[SerializeField]
    //private GameObject exhaustEffect;

    private GameObject effectToSpawn;

    private float timeToFire = 0;

    public int maxNumberOfBullets = 12;

    public List<GameObject> vfx = new List<GameObject>();

    public TextMeshProUGUI bulletText;    

    public AudioClip shootingClip;

    public AudioClip reloadClip;

    private AudioSource shootingAudio;

    private AudioSource reloadAudio;

    private bool isReLoading = false;

    private bool canShoot = true;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        bulletText =  GameObject.Find("BulletTextLeft_Text").GetComponent<TextMeshProUGUI>();        

        maxNumberOfBullets = 12;

        bulletText.text = maxNumberOfBullets.ToString();

        shootingAudio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();

        reloadAudio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();

        effectToSpawn = vfx[0];

        canShoot = true;

        isReLoading = false;

        timeToFire = 0;

        StopCoroutine(Reload());
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shootingButton) && maxNumberOfBullets > 0 && Time.time >= timeToFire && canShoot == true)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<BulletMoveRed>().fireRate;

            SpawnVFX();

            //ExhaustVFX();

            shootingAudio.PlayOneShot(shootingClip);

            //GetComponent<AudioSource>().PlayOneShot(shootingAudio);

            maxNumberOfBullets--;

            bulletText.text = maxNumberOfBullets.ToString();            
        }

        if (OVRInput.GetDown(reloadButton) && isReLoading == false)
        {
            isReLoading = true;

            canShoot = false;

            StartCoroutine(Reload());

            reloadAudio.PlayOneShot(reloadClip);

            //GetComponent<AudioSource>().PlayOneShot(reloadAudio);
        }

        if (maxNumberOfBullets <= 2.0f)
        {
            uiManager.ReloadLeftWarningEnable();
        }
        else
        {
            uiManager.ReloadLeftWarningDisable();
        }
    }

    void SpawnVFX()
    {
        if (firePoint != null)
        {
            Instantiate(effectToSpawn, firePoint.transform.position, firePoint.transform.rotation).GetComponent<Rigidbody>().AddForce(firePoint.transform.forward * effectToSpawn.GetComponent<BulletMoveRed>().speed);                      
        }
        else
        {
            Debug.Log("No fire point found");
        }
    }

    /*void ExhaustVFX()
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
    }*/

    IEnumerator Reload()
    {
        reloadAudio.PlayOneShot(reloadClip);

        yield return new WaitForSeconds(0.6f);        

        maxNumberOfBullets = 12;

        isReLoading = false;

        bulletText.text = maxNumberOfBullets.ToString();

        canShoot = true;
    }

    private void OnEnable()
    {
        isReLoading = true;

        canShoot = false;

        StartCoroutine(Reload());

        //reloadAudio.PlayOneShot(reloadClip);

        //maxNumberOfBullets = 12;

        //bulletText.text = maxNumberOfBullets.ToString();

        //canShoot = true;

        //isReLoading = false;

        timeToFire = 0;
    }
}
