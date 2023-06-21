using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public ShopPrompt shopPrompt = null;
    public ShopController buyShopController = null, sellShopController = null;

    public Canvas actionPromptCanvas = null;

    private bool isInTrigger = false;

    private void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!shopPrompt.IsShown() && !buyShopController.IsShown() && !sellShopController.IsShown())
                {
                    shopPrompt.Show(true);
                }
                else
                {
                    shopPrompt.Show(false);
                    buyShopController.Show(false);
                    sellShopController.Show(false);
                }
                actionPromptCanvas.enabled = false;
                // buyShopController.ShowShop(!buyShopController.IsShown());
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

        shopPrompt.Show(false);
        buyShopController.Show(false);
        sellShopController.Show(false);
        actionPromptCanvas.enabled = false;
    }


}
