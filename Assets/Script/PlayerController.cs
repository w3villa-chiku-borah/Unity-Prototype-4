using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed;
    private Rigidbody rb;
    private GameObject focalPoint;
    public bool havePowerup = false;
    private float instanceForce = 15.0f;
    public GameObject powerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();
     focalPoint = GameObject.Find("Focal Point");
    }
   

    // Update is called once per frame
    void Update()
    {
        powerupIndicator.transform.position=  transform.position + new Vector3(0,-0.5f, 0 );
        float forwardInput = Input.GetAxis("Vertical");
       // float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(focalPoint.transform.forward * forwardSpeed  * forwardInput);
       // rb.AddForce(transform.right * forwardSpeed  * horizontalInput);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
            {
           // Debug.Log("hihi");
            havePowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerUpCountDOwnRoutine());
            }
    }

    IEnumerator PowerUpCountDOwnRoutine()
    {
        yield return new WaitForSeconds(8);
        powerupIndicator.SetActive(false);
        havePowerup = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && havePowerup)
        {
            Rigidbody enemyrb  = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromThePlayer = collision.gameObject.transform.position - transform.position;
            enemyrb.AddForce(awayFromThePlayer * instanceForce, ForceMode.Impulse);

            // Debug.Log("hiiii");
        }
    }
}
