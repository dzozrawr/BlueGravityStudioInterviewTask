using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShopItem : ShopItem
{

    protected override void OnClick()
    {
        if (GameController.CoinAmount >= price)
        {
            //gameController.player.AddClothing(itemPrefab);
            gameObject.SetActive(false);//remove it from shop
            //play buying Sound effect
            gameController.AddMoney(-price);    //subtract money


            GameController.ItemStatus itemStatus = gameController.FindItemStatus(itemInfo);

            if (itemStatus != null)
            {
                itemStatus.isBought = true;
            }
        }
        else
        {
            //play error sound effect maybe
        }
    }

}
