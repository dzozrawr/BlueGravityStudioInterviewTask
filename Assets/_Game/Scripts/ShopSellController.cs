using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSellController : ShopController
{
    public override void LoadShop()
    {
        ShopItem shopItem = null;
        foreach (GameController.ItemStatus itemStatus in gameController.itemStatuses)
        {
            if (itemStatus.isBought)
            {
                shopItem = Instantiate(shopItemPrefab, shopElementsParent);
                shopItem.SetItemInfo(itemStatus.itemInfo);
            }
        }
    }
}
