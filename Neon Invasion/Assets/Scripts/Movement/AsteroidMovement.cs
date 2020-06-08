using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField]
    private float motionSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private GameObject explosionEffectPrefab;

    [SerializeField]
    private GameObject spawnPoint;

    private bool shouldFollow;

    private Rigidbody rb;

    private UIManager uiManager;

    private bool hasEntered;

    void Start()
    {
        uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();

        target = GameObject.FindWithTag("Earth").transform;

        rb = GetComponent<Rigidbody>();

        shouldFollow = true;

        hasEntered = false;
    }    

    private void FixedUpdate()
    {
        if (shouldFollow)
        {
            if (target != null)
            {
                Vector3 direction = target.position - rb.position;

                direction.Normalize();

                Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);

                rb.angularVelocity = rotationAmount * rotationSpeed;

                rb.velocity = transform.forward * motionSpeed;
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Earth")
        {
            uiManager.EarthDamage();

            Instantiate(explosionEffectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

            Destroy(this.gameObject, 0f);
        }

        if (other.tag == "Moon")
        {
            Instantiate(explosionEffectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

            Destroy(this.gameObject, 0f);
        }

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBullet") && !hasEntered)
        {
            hasEntered = true;

            uiManager.IncreaseScoreForBullets();

            Instantiate(explosionEffectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

            ShowFloatingText();

            Destroy(this.gameObject, 0f);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBullet") && hasEntered == true)
        {
            hasEntered = false;
        }
    }*/    
}
