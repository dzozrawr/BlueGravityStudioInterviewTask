using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance = null;

    public static GameController Instance { get => instance; }
    private static int coinAmount;
    public static int CoinAmount { get => coinAmount; set => coinAmount = value; }
    public PlayerMovement player = null;
    public delegate void GameControllerEvent();

    public GameControllerEvent MoneyAmountChanged;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        CoinAmount = 20;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void AddMoney(int moneyAmountToAdd)
    {
        coinAmount += moneyAmountToAdd;
        //if ((moneyEarnedInLevel + moneyAmountToAdd) < 0) moneyEarnedInLevel = 0; else moneyEarnedInLevel += moneyAmountToAdd;
        MoneyAmountChanged?.Invoke();
    }

}
