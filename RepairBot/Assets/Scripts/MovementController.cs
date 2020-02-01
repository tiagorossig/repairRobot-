using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 100;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed));
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if("Ground".Equals(other.tag) && !isGrounded)
        {
            isGrounded = true;
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
