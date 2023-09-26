using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float rotateSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalRotate = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up , horizontalRotate * Time.deltaTime * rotateSpeed);
    }
}
