using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingBoothTrigger : MonoBehaviour
{
    public ClothingBooth boothCanvas = null;

    public Canvas actionPromptCanvas = null;

    private bool isInTrigger = false;

    private void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                boothCanvas.Show(!boothCanvas.IsShown());
                actionPromptCanvas.enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTrigger = true;
        actionPromptCanvas.enabled = true;
        //also show the promt: press E to enter shop
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTrigger = false;

        boothCanvas.Show(false);
        actionPromptCanvas.enabled = false;
    }
}
