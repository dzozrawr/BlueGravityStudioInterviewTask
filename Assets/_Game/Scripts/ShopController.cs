using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopController : MonoBehaviour
{

    public ShopItem shopItemPrefab;
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

#if UNITY_EDITOR
    [ContextMenu("Show the shop")]
    public void ShowTheShop()
    {
        LoadShop();
        canvas.enabled = true;
    }
#endif

    public void Show(bool shouldShow)
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
    public abstract void LoadShop();
}
