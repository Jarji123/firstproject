using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColiders : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public float JumpForce;
    public Rigidbody rb;
    private Vector3 jumpDir;
    private bool isGrounded;
   


    void Update()
    {
        
        
        transform.Translate(0,0,Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0,Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        jumpDir = new Vector3(0, JumpForce, 0);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jumpDir);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        var col = collision.gameObject.GetComponent<BoxCollider>();
        if (collision.gameObject.name == "Ground")
        {


            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {

            isGrounded = false;
        }
       
    }
}


