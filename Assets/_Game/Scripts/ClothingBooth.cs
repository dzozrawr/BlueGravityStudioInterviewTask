using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingBooth : MonoBehaviour
{

    public BoothItem shopItemPrefab;
    public Transform shopElementsParent;

    protected Canvas canvas;
    protected GameController gameController;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        gameController = GameController.Instance;
    }


    public void Show(bool shouldShow)
    {
        if (shouldShow)
        {
            LoadBooth();
            //load the shop with items
        }
        else
        {
            UnloadBooth();
            //remove the items from shop
        }
        canvas.enabled = shouldShow;
        //maybe add a tween for flavor
    }

    public bool IsShown()
    {
        return canvas.enabled;
    }

    public void UnloadBooth()
    {
        if (shopElementsParent.childCount <= 0) return;
        for (int i = 0; i < shopElementsParent.childCount; i++)
        {
            Destroy(shopElementsParent.GetChild(i).gameObject);
        }
    }
    public void LoadBooth()
    {
        BoothItem boothItem = null;
        foreach (GameController.ItemStatus itemStatus in gameController.itemStatuses)
        {
            if (itemStatus.isBought)    
            {
                boothItem = Instantiate(shopItemPrefab, shopElementsParent);
                boothItem.SetItemInfo(itemStatus.itemInfo);
            }
        }
    }
}
