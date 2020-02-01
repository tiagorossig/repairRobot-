using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecter : MonoBehaviour
{

    private bool hasleg1;
    private bool hasleg2;
    private bool hasTorso;

    // Start is called before the first frame update
    void Start()
    {
        hasleg1 = false;
        hasleg2 = false;
        hasTorso = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public bool gotTorso()
    {
        return hasTorso;
    }

    public bool gotleg1()
    {
        return hasleg1;
    }

    public bool gotleg2()
    {
        return hasleg2;
    }


    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    { 
        GameObject other = collision.gameObject;
        if ("Torso".Equals(other.tag))
        {
            Destroy(other);
            Vector3 temp = transform.position;
            transform.position = new Vector3(temp.x, 3f, temp.z);
            transform.FindChild("torso").gameObject.SetActive(true);
            gameObject.GetComponent<Rigidbody>().mass += 3;
            gameObject.GetComponent<MovementController>().setMoveSpeed(0.2f);
            gameObject.GetComponent<MovementController>().setJumpForce(500);
            gameObject.GetComponent<MovementController>().setMovement(1);
            hasTorso = true;
        }
        if (hasTorso)
        {
            if ("Arm".Equals(other.tag))
            {
                Destroy(other);
                transform.FindChild("arm").gameObject.SetActive(true);
            }
            if ("Arm2".Equals(other.tag))
            {
                Destroy(other);
                transform.FindChild("arm2").gameObject.SetActive(true);
            }
            if ("Leg".Equals(other.tag))
            {
                Destroy(other);
                if (!(hasleg1 || hasleg2))
                {
                    Vector3 temp = transform.position;
                    transform.position = new Vector3(temp.x, 4f, temp.z);
                    gameObject.GetComponent<MovementController>().setJumpForce(1000);
                }
                hasleg1 = true;
                if (hasleg1 && hasleg2)
                {
                    gameObject.GetComponent<MovementController>().setJumpForce(1700);
                    gameObject.GetComponent<MovementController>().setMovement(2);
                }
                transform.FindChild("leg").gameObject.SetActive(true);
            }
            if ("Leg2".Equals(other.tag))
            {
                Destroy(other);
                if (!(hasleg1 || hasleg2))
                {
                    Vector3 temp = transform.position;
                    transform.position = new Vector3(temp.x, 4f, temp.z);
                    gameObject.GetComponent<MovementController>().setJumpForce(1000);
                }
                hasleg2 = true;
                if (hasleg1 && hasleg2)
                {
                    gameObject.GetComponent<MovementController>().setJumpForce(1700);
                    gameObject.GetComponent<MovementController>().setMovement(2);
                }
                transform.FindChild("leg2").gameObject.SetActive(true);
            }
        }
    }
}
