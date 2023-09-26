using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float enemySpeed = 3.0f;
    private GameObject player;
    private Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 lockDirection = (player.transform.position - transform.position).normalized;
        playerRb.AddForce(lockDirection * enemySpeed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
