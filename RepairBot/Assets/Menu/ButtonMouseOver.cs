using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    /* 
     * Setup
     * 
     * Parent (Empty)
     * |- Image
     * |--- Sprite Renderer
     * |--- Animator
     * |- Button
     * |--- Text
     * |--- Button Component
     * |--- This Script
     * The button with text must be on below the image in hierachy or else the text will
     * be rendered behind the image.
     * 
     * Scale the Parent to change the size of the button
     * 
     * Put as many of the buttons as you want into a canvas
     */

    public Sprite defaultSprite;
    public Sprite mouseOverSprite;

    //The image for the gear this script is attached to. This is the one that will be darkened
    public Image targetButton;

    //Array of all gear animators and their corresponding speeds in the gear chain
    //Every other gear should have a negative speed
    public Animator[] targetAnimators;
    public float[] animationSpeeds;



    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        targetButton.sprite = mouseOverSprite;
        
        for(int i = 0; i < targetAnimators.Length; i++)
        {
            targetAnimators[i].SetFloat("Speed", animationSpeeds[i]);
        }
        Debug.Log("Entry");
    }


    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        targetButton.sprite = defaultSprite;
        for (int i = 0; i < targetAnimators.Length; i++)
        {
            targetAnimators[i].SetFloat("Speed", 0.0f);
        }
        Debug.Log("Exit");
    }
}
