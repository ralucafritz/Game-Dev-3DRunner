using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Rigidbody variable to be assigned to an object
    public Rigidbody rb;

    //Varibles declared public so they can be changed from the Unity frontend instead of changing directly into the code
    public float forwardForce = 1000f;
    public float sidewayForce = 500f;
    public float jumpForce = 100f;

    //Bool variable that says if the player is or is not touching the ground surface
    private bool playerOnGround = false;

    //Update function that is called once per frame
    void FixedUpdate()
    {
        //Constant forward force activated per frame
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        
        //Right force that is activated per frame when the user is pressing the "D" key
        if(Input.GetKey("d"))
        {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0);
        }

        //Left force that is activated per frame when the user is pressing the "A" key
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0);
        }

        //Jump activated by "W" or"SPACE" key if the player is on the ground
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey("w")) && playerOnGround)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    //Function that detects when the player enter in a collision
    void OnCollisionEnter(Collision collision)
    {
        //If statement that detects if the player is on the ground and changes the variable value to true
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerOnGround = true;
            //Debug.Log("On ground");
        }
        
    }

    //Function that detects when the player exit a collision
    void OnCollisionExit(Collision collision)
    {
        //If statement that detects if the player is not on the ground anymore and changes the variable accordingly
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerOnGround = false;
            //Debug.Log("NOT ON ground");
        }
    }

}
