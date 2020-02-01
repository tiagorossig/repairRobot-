using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isGrounded;
    private float moveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //check to see if the space bar is pressed && box is on ground
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 180); //add force to make the box jump into the air
            isGrounded = false; //the box is no longer on the ground
        }
        //this is the character controller
        //this moves the box in the direction of the axis (left or right and up or down)
        //times Time.deltaTime which allows it to run at a constant frame rate
        //and times our movement speed so it moves more than 1f each time.
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);


    }

    private void OnCollisionEnter(Collision collision) //is called on collision with something
    {
        //checks to see if the box is on the ground after a jump
        if (collision.gameObject.tag == ("Ground") && !isGrounded)
        {
            isGrounded = true; //says that the box is on the ground now
        }

    }
}