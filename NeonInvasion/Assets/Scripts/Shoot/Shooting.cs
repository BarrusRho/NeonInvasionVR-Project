using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject projectilePrefab;

    public GameObject projectileCasingPrefab;

    public GameObject muzzleFlashPrefab;

    public Transform barrelLocation;

    public Transform casingExitLocation;

    public float shotPower = 100f;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        
    }
    
    public void ProjectileShoot()
    {
        //  GameObject bullet;
        //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

       GameObject tempFlash;

       Instantiate(projectilePrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

       tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

       //Destroy(tempFlash, 1.5f);

       //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);
       
    }

    public void ProjectileCasingRelease()
    {
        Instantiate(projectileCasingPrefab, casingExitLocation.position, casingExitLocation.rotation);

        //GameObject casing;

        //casing = Instantiate(projectileCasingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;

        //casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);

        //casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
