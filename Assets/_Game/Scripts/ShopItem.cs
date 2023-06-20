using ClothingItems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using text

[RequireComponent(typeof(Button))]
public abstract class ShopItem : MonoBehaviour
{
    public ClothingItemInfo itemInfo = null;

    public Image itemImage = null;
    public TMP_Text priceText = null;
    public TMP_Text descrText = null;

  //  protected GameObject itemPrefab = null;
    protected int price;


    protected Button button = null;

    protected GameController gameController = null;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        SetItemInfo(itemInfo);
    }

    private void Start()
    {
        gameController = GameController.Instance;
    }
    protected abstract void OnClick();

    public void SetItemInfo(ClothingItemInfo info)
    {
        if (info == null) return;
        itemInfo = info;

        itemImage.sprite = info.sprite;
        descrText.text = info.description;

        price = info.price;
        priceText.text = price + "";

       // itemPrefab = itemInfo.itemPrefab;
    }
}
