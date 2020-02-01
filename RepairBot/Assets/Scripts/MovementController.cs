using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed));
        if (Input.GetButtonDown("Jump") && transform.position.y <= 1.5)
        {
            rigid.AddForce(Vector3.up * jumpForce);
        }
    }

    public void setMoveSpeed(float newspeed)
    {
        moveSpeed = newspeed;
    }

    public void setJumpForce(float newjump)
    {
        jumpForce = newjump;
    }
}
