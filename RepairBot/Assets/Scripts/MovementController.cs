using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int movement;

    [SerializeField] private bool isGrounded;
    [SerializeField] private int walkcount;
    [SerializeField] private bool changedir;

    // Start is called before the first frame update
    void Start()
    {
        movement = 0;
        jumpForce = 100;
        walkcount = 0;
        changedir = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement == 0)
        {
            rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed));
        } else if(movement == 1)
        {
            float vert = Input.GetAxis("Vertical");
            float hori = Input.GetAxis("Horizontal");
            if((vert != 0 || hori != 0) && isGrounded)
            {
                Debug.Log("schmoovin");
                rigid.AddForce(transform.forward * vert * moveSpeed * 1500 + transform.up * 500 + transform.right * hori * moveSpeed * 1500);
                isGrounded = false;
            }
        } else if(movement == 2)
        {
            float vert = Input.GetAxis("Vertical");
            float hori = Input.GetAxis("Horizontal");
            Transform arm = transform.Find("arm");
            Transform arm2 = transform.Find("arm2");
            Transform leg = transform.Find("leg");
            Transform leg2 = transform.Find("leg2");
            rigid.MovePosition(transform.position + (transform.forward * vert * moveSpeed) + (transform.right * hori * moveSpeed));
            if (vert != 0 || hori != 0)
            {
                if (!changedir)
                {
                    arm.Rotate(Vector3.left * 1.3f);
                    arm2.Rotate(Vector3.right * 1.3f);
                    leg.Rotate(Vector3.right * 1.3f);
                    leg2.Rotate(Vector3.left * 1.3f);
                    walkcount++;
                    if (walkcount > 20) changedir = true;
                } else
                {
                    arm.Rotate(Vector3.right * 1.3f);
                    arm2.Rotate(Vector3.left * 1.3f);
                    leg.Rotate(Vector3.left * 1.3f);
                    leg2.Rotate(Vector3.right * 1.3f);
                    walkcount--;
                    if (walkcount < -20) changedir = false;
                }
            }
        }
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

    private void CheckLegs()
    {
       
    }

    public void setMoveSpeed(float newspeed)
    {
        moveSpeed = newspeed;
    }

    public void setJumpForce(float newjump)
    {
        jumpForce = newjump;
    }

    public void setMovement(int setTo)
    {
        movement = setTo;
    }
}
