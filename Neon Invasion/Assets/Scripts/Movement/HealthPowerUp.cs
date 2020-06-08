using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeField]
    private float motionSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform target;

    private bool shouldFollow;

    private Rigidbody rb;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();

        target = GameObject.FindWithTag("PlayerTarget").transform;

        rb = GetComponent<Rigidbody>();

        shouldFollow = true;
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
        if (other.tag == "Player" && uiManager.currentPlayerHealth < 100f)
        {
            uiManager.HealthPowerUp();

            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
