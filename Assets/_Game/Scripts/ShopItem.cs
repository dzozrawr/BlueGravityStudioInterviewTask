using ClothingItems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using text

[RequireComponent(typeof(Button))]
public class ShopItem : MonoBehaviour
{
    public ClothingItemInfo itemInfo = null;

    public Image itemImage = null;
    public TMP_Text priceText = null;
    public TMP_Text descrText = null;

    private GameObject itemPrefab = null;
    private int price;


    private Button button = null;

    private GameController gameController = null;

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
    private void OnClick()
    {
        if (GameController.CoinAmount >= price)
        {
            gameController.player.AddClothing(itemPrefab);
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

    public void SetItemInfo(ClothingItemInfo info)
    {
        if (info == null) return;
        itemInfo = info;

        itemImage.sprite = info.sprite;
        descrText.text = info.description;

        price = info.price;
        priceText.text = price + "";

        itemPrefab = itemInfo.itemPrefab;
    }
}
