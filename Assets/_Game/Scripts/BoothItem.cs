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
    public void OnClick()
    {
        if (itemStatus == null) itemStatus = gameController.FindItemStatus(itemInfo);  //check in gamecontroller if it is already equipped and enable the checkmark if yes
        if (!itemStatus.isEquipped)//if it's not equipped instantiate the clothing item and add it to player's active clothes and mark it as equipped
        {
            CheckForClothesOfSameType(itemInfo.itemPrefab.GetComponent<ClothingItem>().type);     

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

    private void CheckForClothesOfSameType(ClothingType type)
    {
        foreach (GameController.ItemStatus itemStatus in gameController.itemStatuses)
        {
            if (itemStatus.isEquipped)
            {
                if (itemStatus.itemInfo.itemPrefab.GetComponent<ClothingItem>().type == type)
                {
                    BoothItem curBoothItem = null;
                    for (int i = 0; i < transform.parent.childCount; i++)
                    {
                        curBoothItem = transform.parent.GetChild(i).GetComponent<BoothItem>();
                        if (curBoothItem.itemInfo.id == itemStatus.itemInfo.id)
                        {
                            curBoothItem.OnClick(); //this unequips the equipped item of the same type just by simulating a click on it
                        }
                    }
                    break;
                }
            }
        }
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
