using UnityEngine;
using System.Collections;

public class DumbfireMissileController : MonoBehaviour
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

    //[SerializeField]
    //private Transform target;

    [SerializeField]
    private float secondsBeforeEngines;

    private bool enginesOn;

    private Rigidbody rb;

    [SerializeField]
    private float destructionTime;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        jets.SetActive(false);

        smoke.SetActive(false);

        smokeBurst.SetActive(false);

        jetLight.SetActive(false);

        StartCoroutine(WaitBeforeEngines());
    }
    
    public void LaunchMissle()
    {      
            float delta_speed = Time.deltaTime * motionSpeed;
        
            //transform.position = Vector3.MoveTowards(transform.position, target.position, motionSpeed);

            jets.SetActive(true);
            smoke.SetActive(true);
            smokeBurst.SetActive(true);
            jetLight.SetActive(true);        
    }

    private void FixedUpdate()
    {
        if (enginesOn)
        {
         Vector3 direction = rb.position;
         
         direction.Normalize();

         //Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);

         //rb.angularVelocity = rotationAmount * rotationSpeed;

         rb.velocity = transform.forward * motionSpeed;
        
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.gameObject);

        Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject, 1f);
        }
    }*/

    private IEnumerator WaitBeforeEngines()
    {
        rb.AddForce(Vector3.forward * launchSpeed, ForceMode.Impulse);

        yield return new WaitForSeconds(secondsBeforeEngines);

        enginesOn = true;

        jets.SetActive(true);

        smoke.SetActive(true);

        smokeBurst.SetActive(true);

        jetLight.SetActive(true);

        Invoke("Explosion", destructionTime - 0.1f);

        Destroy(this.gameObject, destructionTime);
    }

    private void Explosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
