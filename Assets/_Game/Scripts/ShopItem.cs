using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using text

[RequireComponent(typeof(Button))]
public class ShopItem : MonoBehaviour
{
    public GameObject itemPrefab = null;
    public int price;
    public TMP_Text priceText = null;

    private Button button = null;

    private GameController gameController = null;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        priceText.text = price + "";
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
        }
        else
        {
            //play error sound effect maybe
        }

    }
}
