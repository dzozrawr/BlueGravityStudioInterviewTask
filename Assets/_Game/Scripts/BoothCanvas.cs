using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothCanvas : ShopController
{
    public override void LoadShop()
    {
        ShopItem shopItem = null;
        foreach (GameController.ItemStatus itemStatus in gameController.itemStatuses)
        {
            if (itemStatus.isBought)    //and !isEquipped
            {
                shopItem = Instantiate(shopItemPrefab, shopElementsParent);
                shopItem.SetItemInfo(itemStatus.itemInfo);
            }
        }
    }
}
