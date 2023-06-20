using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuyController : MonoBehaviour
{

    public ShopItem shopItemPrefab;
    public Transform shopElementsParent;

    private Canvas canvas;
    private GameController gameController;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        gameController = GameController.Instance;
    }

    public void ShowShop(bool shouldShow)
    {
        if (shouldShow)
        {
            LoadShop();
            //load the shop with items
        }
        else
        {
            UnloadShop();
            //remove the items from shop
        }
        canvas.enabled = shouldShow;
        //maybe add a tween for flavor
    }

    public bool IsShown()
    {
        return canvas.enabled;
    }

    public void UnloadShop()
    {
        if (shopElementsParent.childCount <= 0) return;
        for (int i = 0; i < shopElementsParent.childCount; i++)
        {
            Destroy(shopElementsParent.GetChild(i).gameObject);
        }
    }
    public void LoadShop()
    {
        ShopItem shopItem = null;
        foreach (GameController.ItemStatus itemStatus in gameController.itemStatuses)
        {
            if (!itemStatus.isBought)
            {
                shopItem = Instantiate(shopItemPrefab, shopElementsParent);
                shopItem.SetItemInfo(itemStatus.itemInfo);
            }
        }
    }
}
