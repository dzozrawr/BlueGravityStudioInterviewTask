using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingBoothTrigger : MonoBehaviour
{
    public BoothCanvas boothCanvas = null;

    private bool isInTrigger = false;

    private void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                boothCanvas.Show(!boothCanvas.IsShown());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTrigger = true;
        //also show the promt: press E to enter shop
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTrigger = false;

        boothCanvas.Show(false);
    }
}
