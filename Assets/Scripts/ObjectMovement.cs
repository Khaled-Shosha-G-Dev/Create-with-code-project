using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Rigidbody objectRb;
    public float speed=100;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward*-speed*Time.deltaTime);
        OutOfRange();
    }
     
    private void OutOfRange()
    {
        if(transform.position.z<-8)
            Destroy(gameObject);
    }
}
