using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellShopItem : ShopItem
{
    protected override void OnClick()
    {

        gameObject.SetActive(false);//remove it from shop

        gameController.AddMoney(price);    //subtract money


        GameController.ItemStatus itemStatus = gameController.FindItemStatus(itemInfo);

        if (itemStatus != null)
        {
            itemStatus.isBought = false;
        }

    }
}
