using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ClothingItems;
public class BoothItem : MonoBehaviour
{
    public ClothingItemInfo itemInfo = null;

    public Image itemImage = null;
    public TMP_Text descrText = null;
    public Image checkMarkImage = null;

    protected GameObject itemPrefab = null;
    protected Button button = null;

    protected GameController gameController = null;

    private GameController.ItemStatus itemStatus = null;

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
    protected void OnClick()
    {
        if(itemStatus==null) itemStatus = gameController.FindItemStatus(itemInfo);  //check in gamecontroller if it is already equipped and enable the checkmark if yes
        if (!itemStatus.isEquipped)//if it's not equipped instantiate the clothing item and add it to player's active clothes and mark it as equipped
        {
            gameController.player.AddClothing(itemPrefab);
            itemStatus.isEquipped = true;
        }
        else        //if it is equipped, find it by ID in player's active items and destroy it
        {
            gameController.player.RemoveItem(itemInfo.id);
            itemStatus.isEquipped = false;
        }



        checkMarkImage.enabled = !checkMarkImage.enabled; //toggle the checkmark

    }

    public void SetItemInfo(ClothingItemInfo info)
    {
        if (info == null) return;
        itemInfo = info;

        itemImage.sprite = info.sprite;
        descrText.text = info.description;

        itemPrefab = itemInfo.itemPrefab;

        if (gameController == null) gameController = GameController.Instance;

        itemStatus = gameController.FindItemStatus(itemInfo);  //check in gamecontroller if it is already equipped and enable the checkmark if yes
        checkMarkImage.enabled = itemStatus.isEquipped;
       
    }
}
