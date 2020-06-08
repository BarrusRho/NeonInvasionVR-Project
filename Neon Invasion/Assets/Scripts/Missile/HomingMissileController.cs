using UnityEngine;
using System.Collections;

public class HomingMissileController : MonoBehaviour
{
    [SerializeField]
	private float motionSpeed;

    [SerializeField]
	private float rotationSpeed;

    [SerializeField]
    private float launchSpeed;

    [SerializeField]
    private GameObject jets;

    [SerializeField]
    private GameObject smoke;

    [SerializeField]
    private GameObject smokeBurst;

    [SerializeField]
    private GameObject jetLight;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float secondsBeforeHoming;

    private bool shouldFollow;

    private Rigidbody rb;
      
    void Start ()
    {
        //GetComponent<HomingMissileController>().enabled = false;

        rb = GetComponent<Rigidbody>();
        
        jets.SetActive(false);

        smoke.SetActive(false);

        smokeBurst.SetActive(false);

        jetLight.SetActive(false);

        StartCoroutine(WaitBeforeHoming());
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

    /*private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.gameObject);

        Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

    private IEnumerator WaitBeforeHoming()
    {
        rb.AddForce(Vector3.forward * launchSpeed, ForceMode.Impulse);

        yield return new WaitForSeconds(secondsBeforeHoming);

        shouldFollow = true;

        jets.SetActive(true);

        smoke.SetActive(true);

        smokeBurst.SetActive(true);

        jetLight.SetActive(true);
    }
}
