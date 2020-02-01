using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public MeshRenderer doorLightMesh;
    public Light doorLight;
    public Animator doorAnimator;
    public Material closeLight;
    public Material openLight;

    public void Start()
    {
        
    }
    //call to open the door
    IEnumerator openDoor()
    {
        Debug.Log("Opening...");
        doorAnimator.SetBool("Open", true);
        doorAnimator.SetBool("Close", false);
        doorLight.color = openLight.color;
        doorLightMesh.material = openLight;
        yield return null;

    }

    //call to close the door again
    IEnumerator closeDoor()
    {
        doorAnimator.SetBool("Open", false);
        doorAnimator.SetBool("Close", true);
        doorLight.color = closeLight.color;
        doorLightMesh.material = closeLight;
        yield return null;
    }
}
