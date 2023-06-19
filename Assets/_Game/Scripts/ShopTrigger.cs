using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public Canvas shopCanvas = null;

    private bool isInTrigger = false;

    private void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                shopCanvas.gameObject.SetActive(!shopCanvas.gameObject.activeSelf);
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
        shopCanvas.gameObject.SetActive(false);
    }


}
