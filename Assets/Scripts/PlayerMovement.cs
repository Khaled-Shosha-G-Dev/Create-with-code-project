using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRB;
    private float speed=10;
    private float speedUp=60;
    private float zBound=5;
    [SerializeField]private bool isOnGround=true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovements();
        playerBounds();

    }
    //to move a player right , left , forward and backward and jump
    void PlayerMovements()
    {
        float inputHorezontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        playerRB.AddForce(Vector3.forward * speed * inputVertical);
        playerRB.AddForce(Vector3.right * speed * inputHorezontal);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        { 
            playerRB.AddForce(Vector3.up * speedUp ,ForceMode.Impulse);
            isOnGround = false; 
        }
    }
    //to make a bounds to player can skip it 
    void playerBounds()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        else if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            isOnGround=true;
        else if(collision.gameObject.CompareTag("Enemy"))
            Destroy(collision.gameObject);
    }

   
}
