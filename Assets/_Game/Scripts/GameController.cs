using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClothingItems;
using Cinemachine;

public class GameController : MonoBehaviour
{
    private static GameController instance = null;

    public static GameController Instance { get => instance; }

    private static int coinAmount;
    public static int CoinAmount { get => coinAmount; set => coinAmount = value; }

    public delegate void GameControllerEvent();
    public GameControllerEvent MoneyAmountChanged;

    public PlayerMovement player = null;
    public CinemachineVirtualCamera defaultPlayerFollowCamera = null;

    public int initialCoinAmount = 60;

    [System.Serializable]
    public class ItemStatus
    {
        public ClothingItemInfo itemInfo;
        public bool isBought = false;
        public bool isEquipped = false;
    }

    public ItemStatus[] itemStatuses = null;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        CoinAmount = initialCoinAmount;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public ItemStatus FindItemStatus(ClothingItemInfo itemInfo)
    {
        ItemStatus foundItemStatus = null;
        foreach (ItemStatus item in itemStatuses)
        {
            if (item.itemInfo == itemInfo)
            {
                foundItemStatus = item;
                break;
            }
        }

        return foundItemStatus;
    }

    public void AddMoney(int moneyAmountToAdd)
    {
        coinAmount += moneyAmountToAdd;
        //if ((moneyEarnedInLevel + moneyAmountToAdd) < 0) moneyEarnedInLevel = 0; else moneyEarnedInLevel += moneyAmountToAdd;
        MoneyAmountChanged?.Invoke();
    }

}
