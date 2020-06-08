using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomingMovementBlue : MonoBehaviour
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
    private GameObject playerEffectPrefab;

    [SerializeField]
    private GameObject swordEffectPrefab;

    [SerializeField]
    private GameObject wallEffectPrefab;

    [SerializeField]
    private GameObject spawnPoint;

    private bool shouldFollow;

    private Rigidbody rb;

    private UIManager uiManager;

    private bool hasEntered;

    [SerializeField]
    private GameObject floatingText;

    void Start()
    {
        uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();

        target = GameObject.FindWithTag("PlayerTarget").transform;

        rb = GetComponent<Rigidbody>();

        shouldFollow = true;

        hasEntered = false;
    }

    /*
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * 2;

        if (transform.position.z <= -32)
        {
            Destroy(this.gameObject);
        }
    }*/

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
        if (other.tag == "Player")
        {
            Instantiate(playerEffectPrefab, transform.position, Quaternion.identity);

            uiManager.PlayerDamageFromEnemy();

            Destroy(this.gameObject);
        }

        if (other.tag == "BlueSaber")
        {
            uiManager.IncreaseScoreForSwords();

            Instantiate(swordEffectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

            ShowFloatingText();

            Destroy(this.gameObject, 0f);
        }

        if (other.tag == "BlueWalls")
        {
            Instantiate(wallEffectPrefab, transform.position, Quaternion.identity);

            Destroy(this.gameObject, 0f);
        }

        if (other.tag == "RedWalls")
        {
            Instantiate(wallEffectPrefab, transform.position, Quaternion.identity);

            Destroy(this.gameObject, 0f);
        }

        /*if (other.tag == "Bullet")
        {
            uiManager.IncreaseScoreForBullets();

            Instantiate(explosionEffectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

            Destroy(this.gameObject, 0f);
        }*/
    }

    private void OnCollisionEnter(Collision collision)
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
    }

    void ShowFloatingText()
    {
        Instantiate(floatingText, transform.position, Quaternion.identity);
    }
}
