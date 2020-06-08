using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveRed : MonoBehaviour
{
    public float speed;

    public float fireRate;

    public GameObject muzzleFlashPrefab;

    public GameObject hitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if(muzzleFlashPrefab != null)
        {
            var muzzleVFX = Instantiate(muzzleFlashPrefab, transform.position, Quaternion.identity);

            muzzleVFX.transform.forward = gameObject.transform.forward;

            var psMuzzleFlash = muzzleVFX.GetComponent<ParticleSystem>();

            if (psMuzzleFlash != null)
            {
                Destroy(muzzleVFX, psMuzzleFlash.main.duration);
            }
            else
            {
                var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();

                Destroy(muzzleVFX, psChild.main.duration);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            Debug.Log("Speed is set"); //transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("There is no speed variable set");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;

        ContactPoint contact = collision.contacts[0];

        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);

        Vector3 pos = contact.point;

        if(hitPrefab != null)
        {
            var hitVFX = Instantiate(hitPrefab, pos, rot);

            var psHit = hitVFX.GetComponent<ParticleSystem>();

            if (psHit != null)
            {
                Destroy(hitVFX, psHit.main.duration);
            }
            else
            {
                var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();

                Destroy(hitVFX, psChild.main.duration);
            }
        }

        Destroy(this.gameObject);
    }
}
