using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecter : MonoBehaviour
{

    private bool haslegs;
    private bool hasTorso;

    // Start is called before the first frame update
    void Start()
    {
        haslegs = false;
        hasTorso = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    { 
        GameObject other = collision.gameObject;
        if ("Torso".Equals(other.tag))
        {
            Destroy(other);
            Vector3 temp = transform.position;
            transform.position = new Vector3(temp.x, 1.6f, temp.z);
            transform.FindChild("torso").gameObject.SetActive(true);
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
                if (!haslegs)
                {
                    Vector3 temp = transform.position;
                    transform.position = new Vector3(temp.x, 4f, temp.z);
                    haslegs = true;
                }
                transform.FindChild("leg").gameObject.SetActive(true);
            }
            if ("Leg2".Equals(other.tag))
            {
                Destroy(other);
                if (!haslegs)
                {
                    Vector3 temp = transform.position;
                    transform.position = new Vector3(temp.x, 4f, temp.z);
                    haslegs = true;
                }
                transform.FindChild("leg2").gameObject.SetActive(true);
            }
        }
    }
}
